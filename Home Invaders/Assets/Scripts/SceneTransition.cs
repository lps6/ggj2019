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
