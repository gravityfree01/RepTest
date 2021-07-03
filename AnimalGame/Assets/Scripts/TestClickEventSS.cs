using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestClickEventSS : MonoBehaviour{
    public GameObject btn1;
    public GameObject btn2;
    private GameObject obj = null;

    
    enum Direction { LEFT, RIGHT, PAUSE};
    Direction dir = Direction.LEFT;

    // 2021-07-03 박성수 작성
    // 게임 방향키클릭식 Player 스프라이트의 움직이는 스피드조절값
    public float speed = 0.2f;

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
    private void Update()
    {
        // 2021-07-03 박성수 작성
        // 게임 방향키클릭으로 Player 스프라이트의 움직임의 속도 조절
        if (dir == Direction.LEFT)
        {
            obj.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        else if(dir == Direction.RIGHT)
        {
            obj.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
    }


    public void OnClickButton1()
    {
        //btn1 왼쪽 방향키

        //obj.transform.position -= new Vector3(0.15f,0,0);
        dir = Direction.LEFT;

        /*
        btn2.GetComponent<Button>().interactable = true;
        btn1.GetComponent<Button>().interactable = false;
        btn2.GetComponent<Image>().color = Color.red;
        btn1.GetComponent<Image>().color = Color.white;

        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);

        if (!obj.gameObject.activeSelf) return;
        obj.gameObject.SetActive(false);
        */
    }

    public void OnClickButton2()
    {
        //btn2 오른쪽 방향키
        //obj.transform.position += new Vector3(0.15f, 0, 0);
        dir = Direction.RIGHT;
        /*
        btn1.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = false;
        btn1.GetComponent<Image>().color = Color.red;
        btn2.GetComponent<Image>().color = Color.white;

        btn2.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);

        if (obj.gameObject.activeSelf) return;
        obj.gameObject.SetActive(true);
        */
    }

    // 2021-07-03 박성수 작성
    // UICanvs 에 PAUSE 버튼 생성
    public void Pause()
    {
        dir = Direction.PAUSE;
    }

}
