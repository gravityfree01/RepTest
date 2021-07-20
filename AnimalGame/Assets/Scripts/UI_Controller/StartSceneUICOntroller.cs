using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUICOntroller : MonoBehaviour {
    // 스타트씬
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    // 인게임씬
    public void IngameScene()
    {
        SceneManager.LoadScene(1);
    }
    // 게임오버
    public void FailScene()
    {
        SceneManager.LoadScene(2);
    }
    // 헬프씬
    public void HelpScene()
    {
        SceneManager.LoadScene(3);
    }

}
