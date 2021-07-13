using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    * @class UIController
    * @author  박성수                  
    * @date  2021-07-11      
    * @sumary 
    * StartScene - StartScene 스타트버튼 클릭시 인게임이동
    * Ingame - Home 버튼 클릭시 StartScene 이동 */

public class UIController : MonoBehaviour
{
   

    public GameObject btn1;
    public GameObject btn2;

    enum Direction { LEFT, RIGHT, PAUSE };
    Direction dir = Direction.LEFT;

    public void OnClickButton1()
    {
        //btn1 왼쪽 방향키
        dir = Direction.LEFT;
    }

    public void OnClickButton2()
    {
        //btn2 오른쪽 방향키
        dir = Direction.RIGHT;
    }


    /**
    * @author  박성수                  
    * @date  2021-07-11        
    * @sumary 
    * 스타트씬에서 스타트버튼 클릭시 인게임 으로 이동
    * 인게임씬에서 홈버튼을 클릭시 스타트신 으로 이동
    *    
    **/
    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    
    public void GoHome(){
        SceneManager.LoadScene(0);
    }
   







}