using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;
    
    // Start is called before the first frame update
    public void ConnectToInternet()
    {
        if (UsernameInput.text == "" || PasswordInput.text == "")
        {
            Debug.Log("Should write something");
            GameObject.Find("/Canvas/Background/Login/Inputs/LoginButton").GetComponent<Button>().interactable = false;
            GameObject.Find("/Canvas/Background/Login/Inputs/RegisterationButton").GetComponent<Button>().interactable = false;
            GameObject.Find("/Canvas/Background/Login/EmptyBox1").SetActive(true);
        }
        else
        {
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
        }


        //LoginButton.onClick.AddListener(() =>
        //{

        //});
    }

}
