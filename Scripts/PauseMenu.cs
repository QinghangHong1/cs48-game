using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string ScoreBoard;

    public GameObject pauseMenuUI;
    // Update is called once per frame


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadScoreBoard()
    {
        Resume();
        SceneManager.LoadScene(ScoreBoard);
    }



    public void QuitGame()
    {

        Debug.Log("Quitting game..");
        StartCoroutine(UpdateInfo());
       
    }
    public IEnumerator UpdateInfo()
    {
        GameControl playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();

        string userName = playerAttributes.userName;
        int money = playerAttributes.money;
        int health = playerAttributes.health;
        int attack = playerAttributes.attack;
        int HP = playerAttributes.HP;
        int gameLevel = playerAttributes.level;
        bool isQuestComplete = playerAttributes.isQuestComplete;
        int questCount = playerAttributes.QuestCount;
        int enemyKilled = playerAttributes.EnemyKilled;
        int numComeToStore = playerAttributes.numComeToStore;
        bool inQuest = playerAttributes.inQuest;

        WWWForm form = new WWWForm();
        form.AddField("user_name", userName);
        using (UnityWebRequest www = UnityWebRequest.Post("https://crystalis.herokuapp.com/forest/updateInfo?user_name=" + userName
                                                          + "&money=" + money.ToString()
                                                          + "&health=" + health.ToString()
                                                          + "&attack=" + attack.ToString()
                                                          + "&HP=" + HP.ToString()
                                                          + "&game_level=" + gameLevel.ToString()
                                                          + "&quest_count=" + questCount.ToString()
                                                          + "&is_quest_complete=" + isQuestComplete.ToString()
                                                          + "&enemy_killed=" + enemyKilled
                                                          + "&num_come_to_store=" + numComeToStore
                                                          + "&in_quest=" + inQuest
                                                          , form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Application.Quit();
               
            }
            else
            {
                Debug.Log("Update the information successfully");
                Application.Quit();
            }
           
            //scoreBoard.text = resultText;
        }
    }
}

