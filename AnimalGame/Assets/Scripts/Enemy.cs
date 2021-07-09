using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectParent{

    // 2021-07-08 박성수 작성
    // Enemy tag를 이용한 스크립작성
    // Enemy가 떨어지는 속도 작성
    string playerTag = "Player";

    void Update(){
        Destroy(this.gameObject);
        if (this.transform.position.y > 0)
        {
            this.transform.position -= new Vector3(0.15f * Time.fixedDeltaTime, 0, 0);
    }
    }

    // 2021-07-08 박성수 작성
    // Enemy 가 Player와 충돌시 사라지는 코드작성
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == playerTag )
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
