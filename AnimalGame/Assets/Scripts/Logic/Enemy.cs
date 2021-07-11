using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @class Enemy                         // 클래스 이름
 * @desc 적 클래스정보를 담는 클래스      //클래스 설명
 * @author  양동건                       // 작성자
 * @date  2021-07-09        //클래스 작성일자
 */
 
public class Enemy : ObjectParent
{
    /**
    * @author  박성수                  
    * @date  2021-07-08        
    * @sumary 
    *    Enemy tag를 이용한 스크립작성
    *    Enemy가 떨어지는 속도 작성
    */
    string playerTag = "Player";

    void Update(){
        Destroy(this.gameObject);
        if (this.transform.position.y > 0)
        {
            this.transform.position -= new Vector3(0.15f * Time.fixedDeltaTime, 0, 0);
        }
    }

    /**
     * @author  박성수                       // 작성자
     * @date  2021-07-08        //클래스 작성일자
     * @sumary Enemy 가 Player와 충돌시 사라지는 코드작성     // 작성한 내용
     */
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == playerTag )
        {
            Destroy(this.gameObject);
            //Destroy(col.gameObject);
        }
    }

    /**
     * @function foo(int a, GameObject obj)
     * @param1 {int} a 정수값들어옴
     * @param2 {GameObject} obj 게임오브젝트 객체 추가
     * @author  박성수                     
     * @date  2021-07-08        
     * @sumary Enemy 가 Player와 충돌시 사라지는 코드작성    
     */
    private void foo(int a, GameObject obj)
    {


    }
}
