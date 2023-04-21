using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // ABSTRACTION
    public override void Interact(object whoInteracted)
    {
        if (whoInteracted is not Player player)
        {
            return;
        }

        if (player.HaveKey)
        {
            const string OPEN = "Open";
            animator.SetTrigger(OPEN);
        }
    }
}
