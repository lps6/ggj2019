using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemy;

    public float speed = .3f;
    public int damage;
    public int hp = 4;

    //public float speed = .3f;
    //public int damage;
    //public int hp = 5;


    public bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.image;
        StartCoroutine(MoveRoutine());
    }

    public IEnumerator MoveRoutine()
    {
        Move();
        yield return new WaitForSeconds(1/2);
        StartCoroutine(MoveRoutine());
    }

    public IEnumerator BlockRoutine(GameObject go)
    {
        canMove = false;
        yield return new WaitForSeconds(3f);
        Destroy(go);
        canMove = true;
    }

    public void Move()
    {
        if (canMove)
        {
            int dir = CompareTag("Enemy") ? -1 : 1;
            transform.localPosition += new Vector3(dir, 0, 0) * enemy.speed/100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.CompareTag("Friend"))
        { 
            StartCoroutine(BlockRoutine(collision2.gameObject));
        }
    }

    public static implicit operator Enemy(Collider2D v)
    {
        throw new NotImplementedException();
    }
}
