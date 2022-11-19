using System;
using UnityEngine;

public class MoveInPath : MonoBehaviour
{
    private int m_currentPointIndex;
    private Vector3 m_currentPointPosition;

    public event EventHandler OnFinishedPath;

    private void Start()
    {
        m_currentPointPosition = Path.Instance.GetPoint(m_currentPointIndex).position;
    }

    private void Update()
    {
        if (CheckCurrentPointReached())
        {
            UpdateCurrentPointPosition();
        }
    }

    public void Move(float speed)
    {
        var directionTarget = (m_currentPointPosition - transform.position).normalized;
        transform.position += speed * Time.deltaTime * directionTarget;
    }

    private bool CheckCurrentPointReached()
    {
        var stoppingDistance = .1f;

        return Vector3.Distance(transform.position, m_currentPointPosition) < stoppingDistance;
    }

    private void UpdateCurrentPointPosition()
    {
        if (!Path.Instance) return;

        if (m_currentPointIndex < Path.Instance.Points.Count - 1)
        {
            m_currentPointIndex++;
            m_currentPointPosition = Path.Instance.GetPoint(m_currentPointIndex).position;
        }
        else
        {
            OnFinishedPath?.Invoke(this, EventArgs.Empty);
        }
    }
}
