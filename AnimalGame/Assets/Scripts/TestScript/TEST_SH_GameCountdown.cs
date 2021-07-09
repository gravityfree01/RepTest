﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_SH_GameCountdown : MonoBehaviour
{ 

    private int Timer = 0;
    public GameObject Num_A;   //1번
    public GameObject Num_B;   //2번
    public GameObject Num_C;   //3번
    public GameObject Num_GO;   //시작 이미지

    void Start()
    {
        //시작시 카운트 다운 초기화, 게임 시작 false 설정
        Timer = 0;
        // 나머지 (카운트다운 이미지) 안보이기
        Num_A.SetActive(false);
        Num_B.SetActive(false);
        Num_C.SetActive(false);
        Num_GO.SetActive(false);
    }



    void Update()
    {
        //게임 시작시 정지
        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
        }
        //Timer 가 90보다 작거나 같을경우 Timer 계속증가
        if (Timer <= 150)
        {
            Timer++;

            // Timer가 60보다 클경우 튜토리얼 끄고 3켜기
            if (Timer > 60)
            {
                Num_C.SetActive(true);
            }
            // Timer가 90보다 작을경우 3끄고 2켜기
            if (Timer > 90)
            {
                Num_C.SetActive(false);
                Num_B.SetActive(true);
            }
            // Timer 가 120보다 클경우 2끄고 1켜기
            if (Timer > 120)
            {
                Num_B.SetActive(false);
                Num_A.SetActive(true);
            }
            // Timer 가 150보다 크거나 같을 경우 1끄고 시작 켜기 LoadingEnd () 코루틴호출
            if (Timer >= 150)
            {
                Num_A.SetActive(false);
                Num_GO.SetActive(true);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //게임시작
            }
        }
    }

    IEnumerator LoadingEnd()
    {
        yield return new WaitForSeconds(1.0f);
        Num_GO.SetActive(false);
    }

}

