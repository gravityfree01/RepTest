using UnityEngine;

<<<<<<< HEAD
public class Feed : ObjectParent
{
    void Update()
    {
      
=======
public class Feed : MonoBehaviour

/** 
* 사용함수 : 
* @date : 2021-07-09
* @author : 정성호
* @Comment : 

*/


{
    public GameObject feedObject; // feed라는 프리펩 찾기
    public Transform feedLocation; // 이 feed 움직인다.
    public float MoveSpeed; // 속도 지정
    public float feedDelay; // 지연
    public float DestroyPosY = -3f;

    void Update()
    {
        // 매 프레임마다 불이 MoveSpeed 만큼 down방향(Y축 -방향)으로 날라갑니다.
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        // 만약에 불이 위치가 DestroyYPos를 넘어서면
        if (transform.position.y <= DestroyPosY)
            // 불을 제거
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Score.coinAmount += 1; // Score.cs의 coinAmount변수 1씩 증가. (코인 획득시 점수를 1씩 증가)
        if (collision.CompareTag("Player"))
            GetComponent<Collider2D>().enabled = false; // 불 획득시 오브젝트를 삭제
        // Sfx.SoundPlay(); // 불 획득시 효과음 발생
>>>>>>> a0c64e90c755386897b57f47d6442e64f4e1e1e7
    }
}