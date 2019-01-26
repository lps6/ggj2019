using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public FriendSO friend;
    public float speed = .3f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = friend.image;

        print(friend.name);
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
        int dir = CompareTag("Enemy") ? -1 : 1;
        transform.position += new Vector3(dir, 0, 0);
    }
}
