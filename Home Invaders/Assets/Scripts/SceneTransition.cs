using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static event Action OnStartLoad;

    public void Load(int scene) => SceneManager.LoadScene(SceneManager.GetSceneAt(scene).name);

    public void Load(string scene)
    {
        OnStartLoad?.Invoke();
        SceneManager.LoadScene(scene);
    }
}

//using UnityEngine;
//using System.Collections;
//using UnityEngine.SceneManagement;

//public class SceneLoader : MonoBehaviour
//{

//    public void LoadScene(int level)
//    {
//        SceneManager.LoadScene(level);
//    }
//}
