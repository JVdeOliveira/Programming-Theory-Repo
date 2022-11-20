using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Enemy> m_enemieList;
    [SerializeField] private float m_maxSpawnTime;

    [SerializeField] private int startEnemyCount;

    private bool m_isSpwaning;

    private int m_wave;
    private int m_currentEnemy;

    private int m_amountEnemysCreate;
    private int m_currentEnemyCreate;

    private void Awake()
    {
        m_isSpwaning = true;
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (m_isSpwaning)
        {
            if (m_currentEnemy <= 0)
            {
                m_wave++;

                m_amountEnemysCreate = m_wave * startEnemyCount;
                m_currentEnemyCreate = 0;
            }

            if (m_currentEnemyCreate < m_amountEnemysCreate)
            {
                SpawnEnemy();
            }

            var spawnTime = Random.Range(m_maxSpawnTime / m_wave, m_maxSpawnTime);
            var minSpawnTime = .5f;

            if (spawnTime < minSpawnTime) spawnTime = minSpawnTime;

            yield return new WaitForSeconds(spawnTime);
        }    
    }

    private void SpawnEnemy()
    {
        var position = Vector3.zero;

        if (Path.Instance)
        {
            position = Path.Instance.Points[0].position;
        }

        var enemyPrefab = m_enemieList[Random.Range(0, m_enemieList.Count)];
        var newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);

        m_currentEnemy++;
        m_currentEnemyCreate++;

        newEnemy.HealthSystem.OnDeaded += HealthSystem_OnDeaded; ;
    }

    private void HealthSystem_OnDeaded(object sender, System.EventArgs e)
    {
        m_currentEnemy--;
    }
}
