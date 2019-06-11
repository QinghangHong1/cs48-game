using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button loadButton;
    public Button exitButton;
    public string newGameSceneName;

    public GameObject loadGameMenu;

    public void Awake()
    {
        newGameButton.onClick.AddListener(NewGame);

        exitButton.onClick.AddListener(ExitGame);
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(newGameSceneName, LoadSceneMode.Single);
        SceneManager.LoadScene("Forest");
    }

    public void ExitGame()
    {
        Debug.Log("trying to exit game. Doesn't work in editor");
        Application.Quit();
    }
}
