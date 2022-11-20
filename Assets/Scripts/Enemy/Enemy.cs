using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveInPath m_moveInPath;
    private HealthSystem m_healthSystem;

    [SerializeField] private float m_height;
    [SerializeField] private float m_speed;
    [SerializeField] private int m_health;

    public HealthSystem HealthSystem => m_healthSystem;

    private void Awake()
    {
        m_moveInPath = GetComponent<MoveInPath>();
        m_healthSystem = new HealthSystem(m_health);
        
        SetHeight();
    }

    private void SetHeight()
    {
        var position = transform.position;
        position.y = m_height;
        transform.position = position;
    }

    private void Start()
    {
        m_moveInPath.OnFinishedPath += MoveInPath_OnFinishedPath;
        m_healthSystem.OnDeaded += HealthSystem_OnDeaded;
    }

    #region Events
    private void MoveInPath_OnFinishedPath(object sender, EventArgs e)
    {
        m_healthSystem.Dead();
    }

    private void HealthSystem_OnDeaded(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
    #endregion

    private void Update()
    {
        m_moveInPath.Move(m_speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_healthSystem.Damage(25);
        }
    }
}