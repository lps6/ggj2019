using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelSO : ScriptableObject
{
    public int totalEnemies;
    public float delay;
    public List<GameObject> availableEnemies = new List<GameObject>();
    public List<GameObject> availableRoutes = new List<GameObject>();

}
