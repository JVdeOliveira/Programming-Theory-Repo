using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }

        TryMoveToCursor();
    }

    private void MoveTo(Vector3 destination)
    {
        _agent.destination = destination;
    }

    // ABSTRACTION
    private bool TryMoveToCursor()
    {
        Vector3 destination = MouseWorld.Position;

        if (destination == Vector3.zero)
        {
            //Invalid destination
            return false;
        }

        MoveTo(MouseWorld.Position);
        return true;
    }
}
