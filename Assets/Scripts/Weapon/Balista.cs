using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : Weapon
{
    protected override void Shoot()
    {
        var projectile = Instantiate(m_projectilePrefab, m_shootPosition.position, Quaternion.identity);
        projectile.forward = transform.forward;
    }
}
