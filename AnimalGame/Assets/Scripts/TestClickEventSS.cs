using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 2021-07-03 박성수 작성
// 게임 좌우 버튼 생성중
public class TestClickEventSS : MonoBehaviour{
    public GameObject btn1;
    public GameObject btn2;
    
    private GameObject obj;

    private void Start(){
        if (FindObject())
        {
            Debug.Log("Find Object");
        }
        else
        {
            Debug.Log("Don't");
        }
    }

    private bool FindObject()
    {
        if (obj == null) { 
       obj =GameObject.Find("Player").gameObject;
            return true;
        }
        return false;
    }



    public void OnClickButton1()
    {
       

        btn2.GetComponent<Button>().interactable = true;
        btn1.GetComponent<Button>().interactable = false;
        btn2.GetComponent<Image>().color = Color.red;
        btn1.GetComponent<Image>().color = Color.white;

        btn1.gameObject.SetActive(false);

        if (!obj.gameObject.activeSelf) return;
        obj.gameObject.SetActive(false);
    }

    public void OnClickButton2()
    {
        btn1.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = false;
        btn1.GetComponent<Image>().color = Color.red;
        btn2.GetComponent<Image>().color = Color.white;

        btn2.gameObject.SetActive(false);

        if (obj.gameObject.activeSelf) return;
        obj.gameObject.SetActive(true);
    }

}
