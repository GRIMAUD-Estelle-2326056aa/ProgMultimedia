using UnityEngine;
using System;



public class AnimatableTrophy : MonoBehaviour
{
    public event Action OnAnimationEnded;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false); // caché par défaut
    }

    public void Animate()
    {
        gameObject.SetActive(true);          // apparition
        animator.Play("Appear", 0, 0f);       // lance l’animation
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnAnimationFinished()
    {
            Debug.Log("ANIMATION TERMINÉE");

        gameObject.SetActive(false);
        OnAnimationEnded?.Invoke();
    }

}
