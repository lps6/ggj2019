using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision2)
    {
        Destroy(collision2.gameObject);
        levelManager.EnemyDamage();
    }
}
