﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float speed = 9;
    public Enemy enemyTest;
    public int friend;
    public int friendDmg;
    public int enemyHP;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //o que acontece com o cara 

            enemyHP = collision.GetComponent<Enemy>().enemy.hp;
            print("hp inimigo" + enemyHP);
            if (enemyHP > 0)
            {
                enemyHP -= friendDmg;
                print("hp inimigo" + enemyHP);
                Destroy(gameObject);
            }

            else
            {

                Destroy(collision.gameObject); // inimigo
                Destroy(gameObject); //bala
            }
        }

        else
        {
            print("ta colidindo com gato");
            //shooterFriend.damage = collision.GetComponent<Friend>().damage;
            friendDmg = collision.GetComponent<Friend>().friend.damage;
        }

        Destroy(collision.gameObject); // inimigo
        Destroy(gameObject); //bala
    }

}
