using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Transform m_target;

    [Header("Target and Range")]
    [SerializeField] protected LayerMask m_enemyLayer;
    [SerializeField] protected float m_range;

    [Header("Shoot")]
    [SerializeField] protected Transform m_projectilePrefab;
    [SerializeField] protected Transform m_shootPosition;
    [SerializeField] protected float m_delayShoot;

    private float m_timeShoot;

    protected virtual void Update()
    {
        Rotate();
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (m_target == null) return;

        m_timeShoot += Time.deltaTime;

        if (m_timeShoot > m_delayShoot)
        {
            m_timeShoot = 0;
            Shoot();
        }
    }

    protected abstract void Shoot(); 

    protected virtual void Rotate()
    {
        if (m_target == null) return;

        float rotateSpeed = 50f;

        transform.forward = Vector3.Lerp(transform.forward, GetTargetDirection(), rotateSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    protected virtual void FixedUpdate()
    {
        CheckTargetExitRange();
        GetTarget();
    }

    protected void GetTarget()
    {
        if (m_target != null) return;

        Collider[] colliderArray = Physics.OverlapSphere(transform.position, m_range, m_enemyLayer);

        if (colliderArray.Length > 0)
        {
            m_target = colliderArray[0].transform;
        }
    }

    protected void CheckTargetExitRange()
    {
        if (m_target == null) return;

        var range = m_range + .5f;
        if (Vector3.Distance(transform.position, m_target.position) > range)
        {
            m_target = null;
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_range);

        if (m_target)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_target.position, .5f);
        }
    }

    protected Vector3 GetTargetDirection()
    {
        if (m_target == null) return Vector3.zero;

        return (m_target.position - transform.position).normalized;
    }
}
