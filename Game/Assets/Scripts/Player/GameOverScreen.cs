using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private Scene scene;
    /*private void Start()
    {
        gameObject.SetActive(false);
    }*/
    public void Setup(Scene importScene)
    {
        gameObject.SetActive(true);
        scene = importScene;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}