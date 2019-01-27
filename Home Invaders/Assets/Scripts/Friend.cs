using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public FriendSO friend;
    //public float speed = .3f;

    public int damage = 4;
    public int hp = 5;
    //public float freio = 0.00f;
    //public bool canMove = true;

    //public int damage;
    //public int hp = 5;
    //public float freio = 0.00f;



    public float Vec { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = friend.image;
        

        print(friend.name);
        //StartCoroutine(MoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {

        //print(friend.name);
        //StartCoroutine(MoveRoutine());

    }

    private void OnTriggerEnter2D(Collider2D collision2)
    {

        if (collision2.CompareTag("Enemy") == false)
        {
            print("colide com bala");
            Destroy(collision2.gameObject);
        }



        else
        {
            MoveRoutine();
            Destroy(gameObject);
        }


    }

    public IEnumerator MoveRoutine()
    {
        yield return new WaitForSeconds(3);


    }


}



