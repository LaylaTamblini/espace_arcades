using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private string _scene;

    public void NextScene(string scene) {
        _scene = scene;
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }
}
