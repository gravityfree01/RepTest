using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Logic
 * @desc 로직 클래스
 * @author  정성호
 * @date  2021-07-09 */

public class Logic : MonoBehaviour
{

    // 생명력.
    private int hp = 3;

    // 게임 전체적인 상태값을 가지고 있는 공용체
    public enum GameState { NONE = 0, READY, PLAY, PAUSE, RESUME, CLEAR, FAIL, SETTINGS, LANGUAGE, SOUND, VIBRATION, AUTOSAVE }
    public GameState state = GameState.NONE;

    // 게임 스코어
    private int gameScore = 0;
    private float gameTimer = 0f;


void Start()
{
}

void Update()
{
    GameLogic();
}

private void Init()
{
    state = GameState.NONE;
    gameScore = 0;
    InitHp();

}

// 실질적인 게임로직 함수.
private void GameLogic()
{
    switch (state)
    {
        case GameState.NONE:
            Init();
            break;
        case GameState.READY:
            break;
        case GameState.PLAY:
            break;
        case GameState.PAUSE:
            break;
        case GameState.RESUME:
            break;
        case GameState.CLEAR:
            break;
        case GameState.FAIL:
            break;
        case GameState.SETTINGS:
            break;
        case GameState.LANGUAGE:
            break;
        case GameState.SOUND:
            break;
        case GameState.VIBRATION:
            break;
        case GameState.AUTOSAVE:
            break;
    }
}

// 상태값 바꿔주는 함수.
public void SetState(Logic.GameState state)
{
    if (state < 0 || state > GameState.AUTOSAVE) return;
    this.state = (GameState)state;
}

public int Hp
{
    get
    {
        return this.hp;
    }
}

// 플레이어가 어딘가에 충돌했을때 
public void CollisionPlayer()
{
    if (hp <= 0) SetState(Logic.GameState.FAIL);

    hp -= 1;
}

public void InitHp()
{
    hp = 3;
}
}
