using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/** 
* 사용함수 : public class UIController
* @date : 2021-07-01
* @author : 정성호
* @Comment : 2020-07-03 UI컨트롤러 정성호 작성중
* 현재까지 작업된것 : 스크립트 파일에 일시정지, 계속하기 기능 추가 테스트(현재 임시로 랭킹 버튼 클릭시 일시정지 기능 작동, 계속하기버튼클릭시 다시 제계 정상 작동 확인)
* 참고 : 
*/


public class UIController : MonoBehaviour{
    Logic logic; //     2021-07-03 Logic logic = null;
    private GameObject menuUI;
    void Start(){
        logic=GameObject.Find("GameManager").GetComponent<Logic>();
        // SH 게임매니저 오브젝트 찾기
        menuUI = GameObject.FindWithTag("Menu"); // SH 2021-07-03
    }

    void Update(){
        if (logic == null) return;
        // 로직 스테이트 에 따라 UI 조정.
        // SH 게임매니저라는 오브젝트(프리팹)를 못찾을때 예외처리
        switch (logic.state){

            case Logic.GameState.NONE:
                Initialize(); // SH 2021-07-03
                break;
            case Logic.GameState.READY:
                /////
                break;
            case Logic.GameState.PLAY:
                /////
                break;
            case Logic.GameState.PAUSE:
                ShowMenu();
                break; // SH 2021-07-03
            case Logic.GameState.RESUME: // SH 2021-07-03
                Resume(); // SH 2021-07-03
                break;
            case Logic.GameState.CLEAR:
                /////
                break;
            case Logic.GameState.FAIL:
                /////
                break;
        }
    } // SH 어떤 상황이 생겼을때 어떤 행동을 취해야할지

    public void OnClickPauseMenu() // SH 일시정지버튼 비활성화
    {
        logic.SetState(Logic.GameState.PAUSE);
    } //
    public void OnClickResumeMenu()  // SH 2021-07-03
    {
        logic.SetState(Logic.GameState.RESUME);
    }



    // SH 일시정지버튼 비활성화
    public void OnClosePauseMenu(){ 
        // 상황에 따라 게임 진행중에 멈춤이 진행되었던 경우.
        // 처음화면에서 게임 멈춤이 되었을경우 예외처리.

    }


    /*
     * @date : 2021-07-03
     * @author : 정성호
     * 새로운 게임으로 진행하는 버튼 이벤트 함수
     * 
     * 현재는 디버그 모드 상태임 로그만 찍힘
     * https://www.youtube.com/watch?v=LooUj77MVSU&t=126s 참고
     * 
     */

    // 게임 시작
    public void OnClickGameStart()
    {
        Debug.Log("게임시작");
    }

    // 랭킹 - 현재 로드로 작성했지만 테스트 완료후 수정 예정
    public void OnClickaRnking()
    {
        Debug.Log("랭킹");
    }

    // 옵션
    public void OnClickOption()
    {
        Debug.Log("옵션");
    }


    // 종료 버튼

    public void ExitGame() {
#if UNITY_ANDROID
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }
    // SH 안드로이드에선 꺼짐.유니티에디터에선 로그남김

    private void Initialize() // SH 2021-07-03
    {
        menuUI.SetActive(false);
    }
    private void ShowMenu() // SH 2021-07-03
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
    }
    private void Resume() // SH 2021-07-03
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
    }



}
