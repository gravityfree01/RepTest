using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


/** 
* 사용함수 : 
* @date : 2021-07-09
* @author : 정성호
* @Comment : 
* 회장님께서 작성해주신거 현재 잠시 주석처리

*/


// 회장님께서 작성해주셨던것
/*
 * 
 private Logic logic = null;

private float boostGage = 0f;
private bool isBoosted = false;

public void IncreaseBoost(){
    if (isBoosted) return;

    if (boostGage>=100f){
        isBoosted=true;
        // 부스터 발동.
    }
    else{
        boostGage+=10f*Time.fixedDeltaTime;
    }
}

void Start(){
    logic=GameObject.Find("GameManager").GetComponent<Logic>();
}

void Update(){
    if (logic==null) return;

    if(logic.state == Logic.GameState.PLAY){


        IncreaseBoost();
    }
}

// 왼쪽으로 이동
public void MoveLeft(){

}

// 오른쪽으로 이동.
public void MoveRight(){

}

// 충돌했을때 
private void OnCollisionEnter2D(Collision2D col){
    // 태그값으로 체크 하거나, 객체의 이름으로 해도됨.
    //if(col.gameObject.tag == ??)
    //if(col.gameObject.name == "??")

    logic.CollisionPlayer();
}
}
*/



/** 
* 사용함수 : 
* @date : 2021-07-09
* @author : 정성호
* @Comment : 
* 플레이어 이동, 화면범위밖 이동방지 스크립트

*/




{
    public float moveSpeed = 1.0f; // 이동속도
    public Vector3 moveDirection = Vector3.zero; // 이동방향

    void Update()
    // 플레이어 이동
    {
        /* Negative left, a : -1
         * Positive right, d :1
         * Non : 0
         * 
         */
        float x = Input.GetAxisRaw("Horizontal"); // 방향값 추출(좌우)
        float y = Input.GetAxisRaw("Vertical"); //  방향값 추출(상하)
        
        // 이동방향 설정
        moveDirection = new Vector3(x, y, 0);

        //새로운 위치 = 현재 위치 + ( 방향 * 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;



        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록함
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);


        Vector3 curPos = transform.position; // 현재 위치 가져오기
        Vector3 nextPos = new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        // tranfom 이동에는 Time.DeltaTime를 꼭 사용

        transform.position = curPos + nextPos;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Tag가 player일 때
        if (collision.gameObject.tag == "Player")
        {
            //Deactive player
            collision.gameObject.SetActive(false);
        }
    }

}




