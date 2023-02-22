using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    private string _scene;

    /// <summary>
    /// Change de scène
    /// selon le string donner dans
    /// l'inspector de Unity
    /// </summary>
    /// <param name="scene"></param>
    public void NextScene(string scene) {
        _scene = scene;
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Permet de quitter
    /// l'application
    /// </summary>
    public void Quit()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }
}
