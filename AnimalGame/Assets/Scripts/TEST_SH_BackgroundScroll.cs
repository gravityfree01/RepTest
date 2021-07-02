using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/** 
* 사용함수 : public class TEST_SH_BackgroundScroll
* @date : 2021-07-01
* @author : 정성호
* @Comment : 2020-07-01  정성호 작성
* 배경스크롤 스크립트
* 참고 : https://www.youtube.com/watch?v=asraLkuR3Jg
*/





public class TEST_SH_BackgroundScroll : MonoBehaviour





{
    private MeshRenderer render; // MeshRenderer 변수 선언

    public float speed; // speed를 이용해 스크롤 속도 조절. speed float형 변수 선언
    private float offset; // offest folat형 변수 생성


    void Start()
    {
        render = GetComponent <MeshRenderer>(); 
    // Start함수에서 GetComponent로 MeshRenderer를 초기화

        
    }

    void Update()
    {
        offset += Time.deltaTime * speed; // offest을 deltatime을 이용해 계속 증가 시킴
        render.material.mainTextureOffset = new Vector2( 0 , offset); 
    // Update함수에서  머티리얼의 offset을 변경해줌
    // new Vector( offset, 0 ) x값 움직임
    // new Vector( 0, offset ); 으로 y값 움직임
    }
}
