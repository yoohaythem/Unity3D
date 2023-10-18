using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;

    public void OnLoginButtonClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        if (username == "admin" && password == "admin")
        {
            //������ת
            SceneManager.LoadScene("TestScene1");
        }
        else
        {
            messageText.text = "�û���������������󣡣���";
            messageText.enabled = true;
            StartCoroutine(HideMessage());
        }

        IEnumerator HideMessage()
        {
            yield return new WaitForSeconds(1);
            print("xxx");
            messageText.enabled = false;
        }
    }


}
