using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform targetTeleporter;
    [SerializeField] private float exitOffset = 1.5f;
    [SerializeField] private float cooldown = 0.3f;
    [SerializeField] private bool resetVelocity = true;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;
        if (!other.CompareTag("Player")) return;

        CharacterController controller = other.GetComponent<CharacterController>();
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (controller == null || playerMovement == null)
            return;

        StartCoroutine(TeleportPlayer(controller, playerMovement, other.transform));
    }

    private IEnumerator TeleportPlayer(CharacterController controller, PlayerMovement playerMovement, Transform playerTransform)
    {
        canTeleport = false;
        
        // Désactiver le script PlayerMovement (arrête la coroutine Moving)
        playerMovement.enabled = false;
        
        // Attendre la fin de la frame actuelle
        yield return new WaitForEndOfFrame();
        
        // Désactiver le CharacterController
        controller.enabled = false;

        // Calculer la position cible
        Vector3 targetPosition = targetTeleporter.position + targetTeleporter.forward * exitOffset;

        // Téléportation directe via Transform
        playerTransform.position = targetPosition;
        
        // Optionnel : aligner la rotation du joueur avec le téléporteur de sortie
        // playerTransform.rotation = targetTeleporter.rotation;

        // Réinitialiser la vélocité de gravité si nécessaire
        if (resetVelocity)
        {
            playerMovement.GravityVelocity = 0f;
        }

        // Réactiver le CharacterController
        controller.enabled = true;
        
        // Réactiver le PlayerMovement (redémarre la coroutine Moving via OnEnable)
        playerMovement.enabled = true;

        // Désactiver le téléporteur de destination temporairement
        if (targetTeleporter.TryGetComponent<Teleporter>(out Teleporter targetTeleporterScript))
        {
            targetTeleporterScript.canTeleport = false;
            targetTeleporterScript.Invoke(nameof(ResetTeleport), cooldown);
        }

        // Cooldown pour ce téléporteur
        yield return new WaitForSeconds(cooldown);
        canTeleport = true;
    }

    private void ResetTeleport()
    {
        canTeleport = true;
    }
}