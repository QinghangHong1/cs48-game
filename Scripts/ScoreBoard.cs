using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreBoard;
    public Text loadText;
    private string userName;
    private int money;
    private int health;
    private int attack;
    private int HP;
    private int gameLevel;
    private bool finished;
    private bool isQuestComplete;
    private int questCount;
    private int enemyKilled;
    private int numComeToStore;
    private bool inQuest;
    void Start()
    {
        finished = false;
        GameControl playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();
        userName = playerAttributes.userName;
        money = playerAttributes.money;
        health = playerAttributes.health;
        attack = playerAttributes.attack;
        HP = playerAttributes.HP;
        gameLevel = playerAttributes.level;
        isQuestComplete = playerAttributes.isQuestComplete;
        questCount = playerAttributes.QuestCount;
        enemyKilled = playerAttributes.EnemyKilled;
        numComeToStore = playerAttributes.numComeToStore;
        inQuest = playerAttributes.inQuest;

        StartCoroutine(UpdateInfo());
        StartCoroutine(GetScoreBoard());

    }

    public IEnumerator UpdateInfo()
    {


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
                loadText.text = "connection failed during updating your game data\n";
            }
            else
            {

            }
            finished = true;
            //scoreBoard.text = resultText;
        }
    }
    public IEnumerator GetScoreBoard()
    {
        yield return new WaitUntil(() => finished);
        using (UnityWebRequest www = UnityWebRequest.Get("https://crystalis.herokuapp.com/forest/getScoreBoard"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                loadText.text = "OOPS, connection failed during retrieving data\n";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                byte[] results = www.downloadHandler.data;
                string resultText = System.Text.Encoding.UTF8.GetString(results);
                JArray jarray = JArray.Parse(resultText);
                int rank = 0;
                Debug.Log("success");
                bool skip = false;
                loadText.GetComponent<Text>().enabled = false;
                scoreBoard.text = string.Format("<color=#00ffffff>{0, -20} {1, -20} {2, -20}\n\n</color>", "RANK", "USER NAME", "GAME LEVEL");
                foreach (JObject item in jarray)
                {

                    string itemUserName = (string)item.GetValue("user_name");
                    string itemGameLevel = (string)item.GetValue("game_level");
                    rank++;
                    string msg = "";
                    if (rank > 10 && itemUserName != userName)
                    {
                        skip = true;
                        continue;
                    }
                    if (itemUserName == userName)
                    {
                        if (skip && rank > 11)
                        {
                            msg += string.Format("{0, -20} {1, -20} {2, -20}\n", ".", ".", ".");
                        }
                        msg += string.Format("<color=#ff0000ff>{0, -20} {1, -20} {2, -20}\n</color>", rank, itemUserName, itemGameLevel);
                        if (skip)
                        {


                            scoreBoard.text = scoreBoard.text + msg;
                            //scoreBoard.text += string.Format("{0, -20} {1, -20} {2, -20}\n", ".", ".", ".");
                            scoreBoard.text += string.Format("{0, -20} {1, -20} {2, -20}\n", ".", ".", ".");

                            break;
                        }

                    }
                    else
                    {
                        msg = string.Format("{0, -20} {1, -20} {2, -20}\n", rank, itemUserName, itemGameLevel);
                    }
                    scoreBoard.text = scoreBoard.text + msg;
                    if(rank >= 10)
                    {
                       //scoreBoard.text += string.Format("{0, -20} {1, -20} {2, -20}\n", ".", ".", ".");

                    }

                }
            }
        }
    }

}

