using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{

    public string name;
    public float speed;
    public Sprite image;

    public void Walk()
    {
        
    }

}
