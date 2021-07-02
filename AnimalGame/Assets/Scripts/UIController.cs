using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/** 
* 사용함수 : public class UIController
* @date : 2021-07-01
* @author : 정성호
* @Comment : 2020-07-02 UI컨트롤러 정성호 작성
* ex.) 메인메뉴에 들어가는 버튼 로직을 관리하는 스크립트
* 참고 : 
*/


public class UIController : MonoBehaviour{ 
    Logic logic = null;
    void Start(){
        logic=GameObject.Find("GameManager").GetComponent<Logic>();
        // SH 게임매니저 오브젝트 찾기
    }

    void Update(){
        if (logic == null) return;
        // 로직 스테이트 에 따라 UI 조정.
        // SH 게임매니저라는 오브젝트(프리팹)를 못찾을때 예외처리
        switch (logic.state){

            case Logic.GameState.NONE:
                /////
                break;
            case Logic.GameState.READY:
                /////
                break;
            case Logic.GameState.PLAY:
                /////
                break;
            case Logic.GameState.PAUSE:
                /////
                break;
            case Logic.GameState.CLEAR:
                /////
                break;
            case Logic.GameState.FAIL:
                /////
                break;
        }
    } // SH 어떤 상황이 생겼을때 어떤 행동을 취해야할지

    public void OnClickPauseMenu(){
        logic.SetState(Logic.GameState.PAUSE); // SH 일시정지버튼을 활성화
    }

    public void OnClosePauseMenu(){ // SH 일시정지버튼 비활성화
        // 상황에 따라 게임 진행중에 멈춤이 진행되었던 경우.
        // 처음화면에서 게임 멈춤이 되었을경우 예외처리.

    }

    // 게임 시작
    public void OnClickGameStart(){
        
    }

    // 종료 버튼
    public void ExitGame(){
#if UNITY_ANDROID // 안드로이드에선 꺼짐.유니티에디터에선 로그남김
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }



}
