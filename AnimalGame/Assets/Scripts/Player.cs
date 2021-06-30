using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

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
