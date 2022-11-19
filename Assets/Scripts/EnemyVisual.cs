using UnityEngine;
using TMPro;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private TextMeshPro m_healthText;

    private void Start()
    {
        var healthSystem = GetComponentInParent<Enemy>().HealthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

        m_healthText.text = healthSystem.Health.ToString();
    }

    private void HealthSystem_OnHealthChanged(object sender, HealthSystem.HealthSystemEventArgs e)
    {
        m_healthText.text = e.Health.ToString();
    }
}
