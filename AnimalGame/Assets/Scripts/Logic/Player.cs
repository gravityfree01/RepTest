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
    {
        int width = Screen.width;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (width / 2 > touch.position.x)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }

            if (width / 2 < touch.position.x)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하도록함
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
