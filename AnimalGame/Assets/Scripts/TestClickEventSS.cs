using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 2021-07-03 박성수 작성
// 게임 좌우 버튼 생성중
public class TestClickEventSS : MonoBehaviour{
    public GameObject btn1;
    public GameObject btn2;
    
    public void OnClickButton1()
    {
       

        btn2.GetComponent<Button>().interactable = true;
        btn1.GetComponent<Button>().interactable = false;
    }

    public void OnClickButton2()
    {
        btn1.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = false;
    }

}
