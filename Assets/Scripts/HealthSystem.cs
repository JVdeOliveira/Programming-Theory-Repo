using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private readonly int m_maxHealth;
    private int m_health;

    public int Health => m_health;
    public int MaxHealth => m_maxHealth;

    public event EventHandler<HealthSystemEventArgs> OnHealthChanged;
    public event EventHandler OnDeaded;

    public HealthSystem(int maxHealth)
    {
        m_maxHealth = maxHealth;
        m_health = maxHealth;
    }

    public void Damage(int amountDamage)
    {
        if (amountDamage > m_health) amountDamage = m_health;

        m_health -= amountDamage;

        OnHealthChanged?.Invoke(this, new HealthSystemEventArgs(m_health, m_maxHealth));

        if (m_health <= 0) Dead();
    }

    public void Heal(int amountHeal)
    {
        var newHealth = amountHeal + m_health;

        if (newHealth > m_maxHealth)
            m_health = m_maxHealth;
        else
            m_health = newHealth;

        OnHealthChanged?.Invoke(this, new HealthSystemEventArgs(m_health, m_maxHealth));
    }

    public void Dead()
    {
        OnDeaded?.Invoke(this, new HealthSystemEventArgs(m_health, m_maxHealth));
    }

    public class HealthSystemEventArgs : EventArgs
    {
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public HealthSystemEventArgs(int health, int maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
        }
    }
}
