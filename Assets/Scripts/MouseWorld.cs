using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoBehaviour
{
    // ENCAPSULATION
    public static Vector3 Position
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Camera.main.farClipPlane))
            {
                return hitInfo.point;
            }
            return Vector3.zero;
        }
    }
}
