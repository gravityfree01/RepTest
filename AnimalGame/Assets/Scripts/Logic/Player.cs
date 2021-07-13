using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Player
 * @desc 플레이어 속성 클래스
 * @author  정성호
 * @date  2021-07-09 */

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 이동속도
    public Vector3 moveDirection = Vector3.zero; // 이동방향

    void Update()

    // 플레이어 이동
    /* @author 정성호
     * @date 2021-07-14
     * @summary 상하 이동관련 함수 제거     */
    {
        float x = Input.GetAxisRaw("Horizontal"); // 방향값 추출(좌우)

        // 이동방향 설정
        moveDirection = new Vector3(x, 0, 0);

        //새로운 위치 = 현재 위치 + ( 방향 * 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록함
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        Vector3 curPos = transform.position; // 현재 위치 가져오기
        Vector3 nextPos = new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
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