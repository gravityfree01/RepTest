using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @class UIController                         // 클래스 이름
 * @desc UI 기능 작동 관련 클래스      //클래스 설명
 * @author  정성호                       // 작성자
 * @date  2021-07-01        //클래스 작성일자
 */

public class UIController : MonoBehaviour
{
    Logic logic = null;
    private GameObject menuUI; // 은닉 권한 게임오브젝트 메뉴UI
    private GameObject settingsUI;

    void Start()
    {
        logic = GameObject.Find("GameManager").GetComponent<Logic>();
        // SH 게임매니저 오브젝트 찾기
        menuUI = GameObject.FindWithTag("Menu"); // SH 2021-07-03
        settingsUI = GameObject.FindWithTag("Settings");
    }

    void Update()
    {
        if (logic == null) return;
        // 로직 스테이트 에 따라 UI 조정.
        // SH 게임매니저라는 오브젝트(프리팹)를 못찾을때 예외처리
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
            case Logic.GameState.SETTINGS:
                ShowSettings();
                break;
            case Logic.GameState.LANGUAGE:

                break;
            case Logic.GameState.SOUND:
                ToggleAudioVolume();
                break;
            case Logic.GameState.VIBRATION:
                Vibrate(true);
                break;
            case Logic.GameState.AUTOSAVE:

                break;
        }
    } 





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


    // 
    /*
 * @date : 2021-07-06
 * @author : 정성호
 * 옵션 - 메인메뉴 , 일시정지메뉴 작동
 */

    public void OnClickSettings()
    {
        logic.SetState(Logic.GameState.SETTINGS);
    }


    public void OnClickLanguage()
    {
        logic.SetState(Logic.GameState.LANGUAGE);
    }

    public void OnClickSound()
    {
        logic.SetState(Logic.GameState.SOUND);
    }

    public void OnClickVibration()
    {
        logic.SetState(Logic.GameState.VIBRATION);
    }

    public void OnClickAutoSave()
    {
        logic.SetState(Logic.GameState.AUTOSAVE);
    }


    /*
 * @date : 2021-07-03
 * @author : 정성호
 * 현재는 디버그 모드 상태임 로그만 찍힘
 */

    public void OnClickMainMenu()
    {
        Debug.Log("메인메뉴이동버튼");
    }


    // 일시정지버튼 비활성화
    public void OnClosePauseMenu()
    {
        {
            logic.SetState(Logic.GameState.RESUME);
        }
        // 상황에 따라 게임 진행중에 멈춤이 진행되었던 경우.
        // 처음화면에서 게임 멈춤이 되었을경우 예외처리.

    }



    /*
     * @date : 2021-07-03
     * @author : 정성호
     * 새로운 게임으로 진행하는 버튼 이벤트 함수
     * 현재는 디버그 모드 상태임 로그만 찍힘
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


    /*
 * @date : 2021-07-03
 * @author : 정성호
 */

    public void ExitGame()
    {
#if UNITY_ANDROID
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }




    /*
 * @date : 2021-07-03
 * @author : 정성호
 */

    private void Initialize()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    private void ShowMenu()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
    }

    private void ShowSettings()
    {
        settingsUI.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
    }


    /*
 * @date : 2021-07-03
 * @author : 정성호
 * 진동
 */
    private void Vibrate(bool state)
    {
#if UNITY_ANDROID
            if (state)
                Handheld.Vibrate();

            if (!state)
                Handheld.Vibrate();
#endif
    }

    private void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}