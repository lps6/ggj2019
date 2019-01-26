using UnityEngine;

[CreateAssetMenu(fileName = "New Friend", menuName = "Friend")]
public class FriendSO : ScriptableObject
{
    public string name;
    public float speed;
    public Sprite image;
    public int damage;
    public int hp;
}
