using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Damager
{

    public float speed = .3f;
    public Enemy enemyTest;


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
            collision.GetComponent<Enemy>().hp--;


            //O que acontece com o cara
            Destroy(gameObject);
        }

    }
}

public class Damager : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}