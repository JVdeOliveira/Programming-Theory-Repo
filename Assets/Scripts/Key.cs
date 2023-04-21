using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public override void Interact(object whoInteracted)
    {
        if (whoInteracted is not Player player)
        {
            return;
        }
        
        player.HaveKey = true;
        Destroy(gameObject);
    }
}
