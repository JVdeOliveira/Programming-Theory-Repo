using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Interactable _targetInteractable;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (TryMoveToInteract())
            {
                return;
            }

            if (TryMoveToCursor())
            {
                return;
            }
        }

        TryInteract();
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

    private bool TryMoveToInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hitInfo, Camera.main.farClipPlane))
        {
            return false;
        }

        if (!hitInfo.transform.TryGetComponent(out Interactable interactable))
        {
            _targetInteractable = null;
            return false;
        }

        _targetInteractable = interactable;
        MoveTo(hitInfo.transform.position);
        
        return true;
    }

    private bool TryInteract()
    {
        if (_targetInteractable == null)
        {
            return false;
        }

        float minDistanceToInteract = 2f;
        if (Vector3.Distance(transform.position, _targetInteractable.transform.position) > minDistanceToInteract)
        {
            return false;
        }

        _agent.isStopped = true;

        _targetInteractable.Interact();
        _targetInteractable = null;

        return true;
    }
}
