using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Door _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (TryMoveToDoor())
            {
                return;
            }

            if (TryMoveToCursor())
            {
                return;
            }
        }

        TryOpenDoor();
    }

    private void MoveTo(Vector3 destination)
    {
        _agent.isStopped = false;
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

    private bool TryMoveToDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hitInfo, Camera.main.farClipPlane))
        {
            return false;
        }

        if (!hitInfo.transform.TryGetComponent(out Door door))
        {
            _target = null;
            return false;
        }

        _target = door;
        MoveTo(hitInfo.transform.position);
        
        return true;
    }

    private bool TryOpenDoor()
    {
        if (_target == null)
        {
            return false;
        }

        float minDistanceToInteract = 2f;
        if (Vector3.Distance(transform.position, _target.transform.position) > minDistanceToInteract)
        {
            return false;
        }

        _target.Open();
        return true;
    }
}
