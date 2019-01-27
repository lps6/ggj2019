using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelSO level;

    void Start()
    {
        LoadWaves();
    }

    void LoadWaves()
    {
        foreach (GameObject route in level.availableRoutes)
        {
            StartCoroutine(LoadEnemies(Instantiate(route)));
        }
    }

    IEnumerator LoadEnemies(GameObject route)
    {
        foreach (GameObject enemy in level.availableEnemies)
        {
            GameObject current_enemy = Instantiate(enemy);
            current_enemy.transform.parent = route.transform;
            yield return new WaitForSeconds(level.delay + enemy.GetComponent<Enemy>().enemy.delay);
        }
    }
}
