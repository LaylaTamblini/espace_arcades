using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    [Header("SCENE")]
    [SerializeField][Tooltip("Nom de la scène où on veut transitionner.")] private string _nameScene;

    [Header("ANIMATOR")]
    [SerializeField][Tooltip("L'Animator du go qui fait la transition.")] private Animator _animTransition;

    [Header("TIME")]
    [SerializeField][Tooltip("Temps avant de changer de scène.")] private float _transitionTime = 1f;

    /// <summary>
    /// Déclanche la coroutine qui change
    /// la scène.
    /// </summary>
    public void NextScene() {
        StartCoroutine(LoadLevel(_nameScene));
    }

    /// <summary>
    /// Permet de quitter l'application.
    /// </summary>
    public void Quit()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }

    /// <summary>
    /// Coroutine qui permet
    /// d'attendre le temps selon la variable _transitionTime
    /// avant de change de scène. On lui donne également la scène
    /// donnée en paramètre dans l'inspector Unity.
    /// </summary>
    /// <param name="scene"></param>
    /// <returns></returns>
    IEnumerator LoadLevel(string scene){
        _animTransition.SetTrigger("End");
        yield return new WaitForSeconds(_transitionTime);
        _nameScene = scene;
        SceneManager.LoadScene(scene);
    }
}
