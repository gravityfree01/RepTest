using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * @class  ObjectParent                       // 클래스 이름
 * @desc       //클래스 설명
 * @author                         // 작성자
 * @date  2021-07-??        //클래스 작성일자
 */

public class ObjectParent : MonoBehaviour{

    public enum Type { UNDEFINDED =0 ,ENEMY, FEED}
    public Type objectType = Type.UNDEFINDED;


    void Start(){
        if(objectType == Type.FEED){
            // 코인 , 먹이
        }
        else{
            // 적 Enemy 일경우.
        }
    }

}
