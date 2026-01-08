using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSystem : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private ParticleSystem footstepParticles;

    [Header("Audio")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private float stepInterval = 0.5f;

    private AudioSource audioSource;
    private float stepTimer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1f; // 3D
    }

    private void Update()
    {
        if (!CanPlayFootstep())
        {
            stepTimer = 0f;
            return;
        }

        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            PlayFootstep();
            stepTimer = 0f;
        }
    }

    private bool CanPlayFootstep()
    {
        return playerMovement != null
            && playerMovement.IsMoving
            && playerMovement.IsGrounded;
    }

    private void PlayFootstep()
    {
        // Son
        if (footstepClips.Length > 0)
        {
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        // Particules
        if (footstepParticles != null && !footstepParticles.isPlaying)
        {
            footstepParticles.Play();
        }
    }
}
