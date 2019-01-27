using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemy;
    public float speed = .3f;
    public int damage;
    public int hp = 5;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.image;

        print(enemy.name);
        StartCoroutine(MoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {


    }

    public IEnumerator MoveRoutine()
    {
        Move();
        yield return new WaitForSeconds(1);
        StartCoroutine(MoveRoutine());
    }

    public void Move()
    {
        if (canMove)
        {
            int dir = CompareTag("Enemy") ? -1 : 1;
            transform.position += new Vector3(dir, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2)
    {

        if (collision2.CompareTag("Friend"))
        {
            canMove = false;
        }

    }

    public static implicit operator Enemy(Collider2D v)
    {
        throw new NotImplementedException();
    }
}
