using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelSO level;

    float currentEnemyDelay = 0f;

    int totalEnemies = 0;

    private List<GameObject> routes = new List<GameObject>();

    void Start()
    {
        LoadRoutes();
        StartCoroutine(LoadEnemiesRoutine());
    }

    void LoadRoutes()
    {
        foreach (GameObject route in level.availableRoutes)
        {
            routes.Add(Instantiate(route));
        }
    }

    public IEnumerator LoadEnemiesRoutine()
    {
        LoadEnemies();
        yield return new WaitForSeconds(level.delay + currentEnemyDelay);
        if (totalEnemies < level.totalEnemies)
        {
            StartCoroutine(LoadEnemiesRoutine());
        }
    }

    void LoadEnemies()
    {
        GameObject enemy;
        int enemyRandomIndex = Random.Range(0, level.availableEnemies.Count);
        int routeRandomIndex = Random.Range(0, level.availableRoutes.Count);
        enemy = Instantiate(level.availableEnemies[enemyRandomIndex], routes[routeRandomIndex].transform);
        currentEnemyDelay = enemy.GetComponent<Enemy>().enemy.delay;
        totalEnemies++;
    }
}
