using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Web : MonoBehaviour
{
    public Button changeSceneButton;
    public Button startButton;

    //public void ButtonUse()
    //{
    //    changeSceneButton.interactable = !changeSceneButton.interactable;
    //    startButton.interactable = !startButton.interactable;
    //    GameObject.Find("/Canvas/Background/RegisterUser/UsernameConflict").SetActive(false);
    //}
    void Start()
    {
       // StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser", "123456"));
    }
     
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_name", username);
        form.AddField("user_password", password);

        using (UnityWebRequest www = UnityWebRequest.Get("https://crystalis.herokuapp.com/forest/getInfo?user_name=" + username + "&user_password=" + password))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Error");
                int rCode = (int)www.responseCode;
                switch (rCode)
                {
                    case 404:
                        Debug.Log("Username does not exist/ Username and password not match");
                        GameObject.Find("/Canvas/Background/Login/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/Login/Inputs/RegisterationButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/Login/WrongInfo").SetActive(true);
                        break;
                    default:
                        Debug.Log("IDK what happen in the Login UI");
                        Debug.Log(rCode);
                        GameObject.Find("/Canvas/Background/Login/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/Login/Inputs/RegisterationButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/Login/DefaultError").SetActive(true);
                        break;
                }
            }
            else
            {
                Debug.Log("success");
                string response = www.downloadHandler.text;
                JObject jobject = JObject.Parse(response);
                GameControl playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();
                playerAttributes.userName = (string)jobject.GetValue("user_name");
                playerAttributes.health = (int)jobject.GetValue("health");
                playerAttributes.level = (int)jobject.GetValue("game_level");
                playerAttributes.attack = (int)jobject.GetValue("attack");
                playerAttributes.money = (int)jobject.GetValue("money");
                playerAttributes.HP = (int)jobject.GetValue("HP");
                playerAttributes.isQuestComplete = (bool)jobject.GetValue("is_quest_complete");
                playerAttributes.QuestCount = (int)jobject.GetValue("quest_count");
                playerAttributes.EnemyKilled = (int)jobject.GetValue("enemy_killed");
                playerAttributes.numComeToStore = (int)jobject.GetValue("num_come_to_store");
                playerAttributes.inQuest = (bool)jobject.GetValue("in_quest");
                Vector3 position;
                position.x = (float)-28;
                position.y = (float)6;
                position.z = 0;
                playerAttributes.position = position;

                SceneManager.LoadScene(sceneName: "StartMenu");
            }
        }
    }

    public IEnumerator Register(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_name", username);
        form.AddField("user_password", password);
        form.AddField("user_email", email);
      //  Debug.Log("5");


        using (UnityWebRequest www = UnityWebRequest.Post("https://crystalis.herokuapp.com/forest/createInfo?user_name=" + username+"&user_password="+password+"&user_email"+email, form))
        {
            yield return www.SendWebRequest();
    

            if (www.isNetworkError || www.isHttpError)
            {
                // Debug.Log(www.responseCode);
                int rCode = (int)www.responseCode;
                switch (rCode)
                {
                    case 409:
                        Debug.Log("Username already exists");
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/UsernameConflict").SetActive(true);
                        break;
                    case 400:
                        Debug.Log("Bad Request");
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/BadRequest").SetActive(true);
                        break;
                    case 405:
                        Debug.Log("Email is not valid");
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/EmailNotFound").SetActive(true);
                        break;
                    case 500:
                        Debug.Log("Internal server");
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/InternalServer").SetActive(true);
                        break;
                    default:
                        Debug.Log("IDK what happen");
                        Debug.Log(rCode);
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
                        GameObject.Find("/Canvas/Background/RegisterUser/DefaultError").SetActive(true);
                        break;
                }

            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                GameControl playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();
                playerAttributes.userName = username;
                playerAttributes.health = 3;
                playerAttributes.level = 1;
                playerAttributes.attack = 1;
                playerAttributes.money = 0;
                playerAttributes.HP = 100;
                playerAttributes.EnemyKilled = 0;

                playerAttributes.QuestCount = 0;
                playerAttributes.isQuestComplete = false;
                playerAttributes.inQuest = false;
                playerAttributes.numComeToStore = 0;
                Vector3 position;
                position.x = (float)-28;
                position.y = (float)6;
                position.z = 0;
                playerAttributes.position = position;

                SceneManager.LoadScene(sceneName: "StartMenu");
            }
        }

    }

}
