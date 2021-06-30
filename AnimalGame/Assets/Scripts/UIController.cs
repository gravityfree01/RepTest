using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour{
    Logic logic = null;
    void Start(){
        logic=GameObject.Find("GameManager").GetComponent<Logic>();

    }

    void Update(){
        if (logic == null) return;
        // 로직 스테이트 에 따라 UI 조정.
        switch (logic.state){

            case Logic.GameState.NONE:
                break;
            case Logic.GameState.READY:
                break;
            case Logic.GameState.PLAY:
                break;
            case Logic.GameState.PAUSE:
                break;
            case Logic.GameState.CLEAR:
                break;
            case Logic.GameState.FAIL:
                break;
        }
    }

    public void OnClickPauseMenu(){
        logic.SetState(Logic.GameState.PAUSE);
    }

    public void OnClosePauseMenu(){
        // 상황에 따라 게임 진행중에 멈춤이 진행되었던 경우.
        // 처음화면에서 게임 멈춤이 되었을경우 예외처리.

    }

    // 게임 시작
    public void OnClickGameStart(){
        
    }

    // 종료 버튼
    public void ExitGame(){
#if UNITY_ANDROID
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }



}
