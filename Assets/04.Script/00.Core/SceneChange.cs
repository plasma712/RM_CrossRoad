using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Singleton<SceneChange>
{
    //첫 시작 -> 메인게임
    public void Start_MainGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
