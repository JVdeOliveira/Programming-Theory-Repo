using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }

    // POLYMORPHISM
    public virtual void Interact(object whoInteracted)
    {
        Interact();
    }
}
