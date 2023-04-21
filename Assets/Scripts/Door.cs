using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        const string OPEN = "Open";
        _animator.SetTrigger(OPEN);
    }
}
