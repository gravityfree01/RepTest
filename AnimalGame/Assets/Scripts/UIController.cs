using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/** 
* 사용함수 : public class UIController
* @date : 2021-07-01
* @author : 정성호
* @Comment : 2020-07-06 UI컨트롤러 정성호 작성중
* 현재까지 작업된것 : 스크립트 파일에 일시정지, 계속하기 기능 추가 테스트(현재 임시로 랭킹 버튼 클릭시 일시정지 기능 작동, 계속하기버튼클릭시 다시 제계 정상 작동 확인)
* 작업중 : 카운트다운 3초, 랭킹, 언어, 소리, 진동, 현재 버전 표시, 
* 참고 : 
*/


public class UIController : MonoBehaviour{
    Logic logic = null;
    private GameObject menuUI; // 은닉 권한 게임오브젝트 메뉴UI
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





    /*
 * @date : 2021-07-04
 * @author : 정성호
 * 게임중 일시정지 버튼 터치하여 메뉴뜨는 함수 
 * 현재는 디버그 모드 상태임 로그만 찍힘
 */




    /* 2021-07-04 정성호 작성
     * 게임중 일시정지 버튼 터치하여 메뉴뜨는 함수 https://magatron.tistory.com/28
     * 현재는 디버그 모드 상태임 로그만 찍힘
 */
    public void OnClickPauseMenu() // SH 일시정지버튼 활성화
    {
        logic.SetState(Logic.GameState.PAUSE);
    }

    // 2021-07-04 정성호 작성
    // 일시정지메뉴에서 해제후 이어서 시작하는 함수
    // 현재는 디버그 모드 상태임 로그만 찍힘
    public void OnClicktGameContinue()
    {
        Debug.Log("계속하기");
    }

    // 2021-07-04 정성호 작성
    // 일시정지메뉴에서 해제및 리겜하는 함수
    // 현재는 디버그 모드 상태임 로그만 찍힘

    public void OnClickGameRestart()
    {
        Debug.Log("다시시작");
    }
    /*
{
    SpawnManager.instance.ClearEnemies(); // SpawnManager에서 적을 모두 사라지게 함

    score = 0;
    scoreText.text = string.Empty;

    TextContrl.instance.Restart(); // TextContrl에서 게임재시작

    lnvoke("RetryGame", 3f); // 3초후 게임재시작


}

// 게임중 일시정지 버튼누른후 다시시작눌러 재시작하는 함수 https://magatron.tistory.com/28
void RetryGame()
{
    StartGame();
    player.SetActive(true);
}

*/




    // SH 일시정지버튼 비활성화
    public void OnClickMainMenu()
    {
        Debug.Log("메인메뉴이동버튼");
    }


    // SH 일시정지버튼 비활성화
    public void OnClosePauseMenu(){
        {
            logic.SetState(Logic.GameState.RESUME);   // SH 2021-07-03
        }
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

    // 옵션 - 메인메뉴 , 일시정지메뉴 작동
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




    /*
 * @date : 2021-07-03
 * @author : 정성호
 * 
 * 
 * 
 * 
 * 
 */

    private void Initialize() // SH 2021-07-03 초기값 설정
    {
        menuUI.SetActive(false);
    }
    private void ShowMenu() // SH 2021-07-03 메뉴를 보여준다
    {
        Time.timeScale = 0f; // 일시정지
        menuUI.SetActive(true);
    }
    private void Resume() // SH 2021-07-03 게임 다시시작
    {
        Time.timeScale = 1f; // 1배속 다시 제계
        menuUI.SetActive(false);
    }



}
