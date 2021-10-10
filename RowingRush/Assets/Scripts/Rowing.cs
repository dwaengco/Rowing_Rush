using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{

    public void SceneChange1()
    {
        SceneManager.LoadScene("Rowing");

    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Ranking");

    }

    public void Onclick(int TargetDistance){
        PlayerPrefs.SetInt("TargetDistance", TargetDistance);
    }

    
}