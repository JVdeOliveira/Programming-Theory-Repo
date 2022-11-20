using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    [SerializeField] private float m_speed;
    [SerializeField] private int m_damage;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        m_rigidbody.AddForce(transform.forward * m_speed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.HealthSystem.Damage(m_damage);
        }

        Destroy(gameObject);
    }
}
