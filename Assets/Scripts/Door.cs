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

    public override void Interact()
    {
        Player player = FindObjectOfType<Player>();

        if (player.HaveKey)
        {
            const string OPEN = "Open";
            animator.SetTrigger(OPEN);
        }
    }
}
