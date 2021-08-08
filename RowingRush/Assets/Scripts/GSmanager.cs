using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;


public class GSmanager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbxc5R_Y7zTad80LiUs_O-6wE889DjIquIuirMARMTgOFqGOdsJ3/exec";
    public InputField IDInput, PassInput;
    public TextMeshProUGUI message, myID;
    string id, pass;
   // static string[] a;
    //int i = 0;



    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("value", "값");
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);

        //myID.text = a[i];
    }

    bool SetIDPass()
    {
        id = IDInput.text.Trim();
        pass = PassInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }
    public void Register()
    {
        if (!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비어있습니다");
            message.text = "ID or password is blank";
            return;
        }

        WWWForm form = new WWWForm();
        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }

    public void Login()
    {
        if (!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비어있습니다");
            message.text = "ID or password is blank";
            return;
        }

        WWWForm form = new WWWForm();

        form.AddField("order", "login");
        form.AddField("id", id);
        form.AddField("pass", pass);

        //myID.text = a[i];

        StartCoroutine(Post(form));

    }

    void OnApplicationQuit()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "logout");

        StartCoroutine(Post(form));
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                string[] data = www.downloadHandler.text.Split(new char[] { '"' });
                print(www.downloadHandler.text);
                message.text = data[data.Length - 2];
                string S1 = www.downloadHandler.text;
                string S2 = "log in succeed";

                if (S1.Contains(S2))
                {
                    SceneManager.LoadScene("third");
                    //DontDestroyOnLoad(gameObject);
                    //a[i]= id;
                    //myID.text = a[i];
                    //i++;
                }
            }
            else
            {
                print("웹의 응답이 없습니다.");
                message.text = "No response from the web.";
            }
        }
    }


    public void SC_login()
    {
        SceneManager.LoadScene("login");

    }
    public void SC_signup()
    {
        SceneManager.LoadScene("signup");

    }

}
