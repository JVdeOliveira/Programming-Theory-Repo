using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public override void Interact()
    {
        Player player = FindObjectOfType<Player>();
        player.HaveKey = true;

        Destroy(gameObject);
    }
}
