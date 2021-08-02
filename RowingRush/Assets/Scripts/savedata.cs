using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class savedata : MonoBehaviour
{
    public InputField ID_in;
   // public InputField ID_in2;
    public TextMeshProUGUI ID_out;
    public TextMeshProUGUI keynumber;
    public TextMeshProUGUI warning;
    public InputField KeyNum;
    //public Scene login;
    List<string> id = new List<string>();
    int i;
   // List<int> i = new List<int>();
    //string realID = "";

    //회원가입 창
    public void myID()
    {
        ID_out.text = ID_in.text;
    }
    
    public void Save()
    {
        PlayerPrefs.SetString("ID", ID_in.text);
        id.Add( PlayerPrefs.GetString("ID")) ;
        keynumber.text = string.Format("key number : {0}",id.IndexOf(PlayerPrefs.GetString("ID")));
        i = id.IndexOf(PlayerPrefs.GetString("ID"));
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("login");
    }


    //로그인 창

    public void Check()
    {
        
        int a = int.Parse(KeyNum.text);
        if (a== i)
        {
            SceneManager.LoadScene("third");
        }
        else
        {
            warning.text = /*PlayerPrefs.GetString("ID") + id+*/  "The ID or KN you entered is incorrect.";
        }
    }
      /* public void myID2()
    {
        ID_out.text = ID_in2.text;
        DontDestroyOnLoad(ID_out);
    }
 public void Save()
    {
        
        PlayerPrefs.SetString("ID",ID_in.text);
        id[i] = "ID";
        ID_out.text = "ID";
        
    }
    public void saved()
    {
        keynumber.text = string.Format("key number : {0}",i);
        i++;
    }




    public void Recent()
    {
        if(PlayerPrefs.HasKey("ID"))
        {
            ID_out.text = PlayerPrefs.GetString("ID");
        }
    }



    public void Check()
    {
        int a = int.Parse(KeyNum.text);
        if(id[a]==ID_in.text)
        {
            ID_out.text = id[a];
        }
    }

    public void keepID()
    {
       ID_out = login.ID_in;
    }*/
}
