using System.Collections.Generic;
using UnityEngine;

public class LightButton : Interactable // INHERITANCE
{
    protected Animator animator;
    [SerializeField] private List<GameObject> _lights;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        foreach (var light in _lights)
        {
            light.SetActive(!light.activeSelf);
        }

        const string USE_BUTTON = "UseButton";
        animator.SetTrigger(USE_BUTTON);
    }
}
