using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_2 : MonoBehaviour
{
    Logic logic;
    private GameObject menuUI;
    void Start()
    {
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
        menuUI = GameObject.FindWithTag("Menu");
    }

    void Update()
    {
        if (logic == null) return;
        // 로직 스테이트 에 따라 UI 조정.
        switch (logic.state)
        {
            case Logic.GameState.NONE:
                Initialize();
                break;
            case Logic.GameState.READY:
                break;
            case Logic.GameState.PLAY:
                break;
            case Logic.GameState.PAUSE:
                ShowMenu();
                break;
            case Logic.GameState.RESUME:
                Resume();
                break;
            case Logic.GameState.CLEAR:
                break;
            case Logic.GameState.FAIL:
                break;
        }
    }

    public void OnClickPauseMenu()
    {
        logic.SetState(Logic.GameState.PAUSE);
    }

    public void OnClickResumeMenu()
    {
        // 상황에 따라 게임 진행중에 멈춤이 진행되었던 경우.
        // 처음화면에서 게임 멈춤이 되었을경우 예외처리.
        logic.SetState(Logic.GameState.RESUME);
    }

    // 게임 시작
    public void OnClickGameStart()
    {
        Debug.Log("Game Start!");
    }

    // 종료 버튼
    public void ExitGame()
    {
        #if UNITY_ANDROID
                Application.Quit();
        #elif UNITY_EDITOR
                Debug.Log("Game Quit");
        #endif
    }

    private void Initialize()
    {
        menuUI.SetActive(false);
    }

    private void ShowMenu()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
    }

}
