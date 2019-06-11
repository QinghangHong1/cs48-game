using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class Register : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField EmailInput;
    //public Button LoginButton;

    // Start is called before the first frame update
    //void Start()
    //{
    //    LoginButton.onClick.AddListener(() =>
    //    {
    //        StartCoroutine(Main.Instance.Web.Register(UsernameInput.text, PasswordInput.text, EmailInput.text));
    //     //   Debug.Log("1");
    //    });
    //}

    public void ConnectToInternet()
    {
        if (UsernameInput.text == "" || PasswordInput.text == "" || EmailInput.text == "")
        {
            Debug.Log("Should write something");
            GameObject.Find("/Canvas/Background/RegisterUser/Inputs/LoginButton").GetComponent<Button>().interactable = false;
            GameObject.Find("/Canvas/Background/RegisterUser/Inputs/BackToLoginButton").GetComponent<Button>().interactable = false;
            GameObject.Find("/Canvas/Background/RegisterUser/EmptyBox").SetActive(true);
        }
        else
        {
            StartCoroutine(Main.Instance.Web.Register(UsernameInput.text, PasswordInput.text, EmailInput.text));
        }
    }


}