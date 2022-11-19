using UnityEngine;
using TMPro;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private Transform m_healthBar;

    private void Start()
    {
        var healthSystem = GetComponentInParent<Enemy>().HealthSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, HealthSystem.HealthSystemEventArgs e)
    {
        var scale = m_healthBar.localScale;
        scale.x = e.Health / (float)e.MaxHealth;
        m_healthBar.localScale = scale;
    }
}
