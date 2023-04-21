using UnityEngine;

public class LightButton : Interactable // INHERITANCE
{
    protected Animator animator;
    [SerializeField] private GameObject _light;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _light.SetActive(!_light.activeSelf);

        const string USE_BUTTON = "UseButton";
        animator.SetTrigger(USE_BUTTON);
    }
}
