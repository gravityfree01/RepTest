using UnityEngine;

/*
 * @class Feed
 * @desc  Feed 속성 클래스
 * @author   정성호
 * @date  2021-07-09
 */
public class Feed : MonoBehaviour
{
    public GameObject feedObject; // feed라는 프리펩 찾기
    public Transform feedLocation; // 이 feed 움직인다.
    public float feedDelay; // 지연
    public float DestroyPosY = -3f;

    private float moveSpeed; // 속도 지정

    void OnEnable()
    {
        moveSpeed = Random.Range(0, 10);

        Debug.Log("오브젝트 속도: " + moveSpeed);
    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (transform.position.y <= DestroyPosY)
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false; // 불 획득시 오브젝트를 삭제
            Score.score += 10;
        }
        // Sfx.SoundPlay(); // 불 획득시 효과음 발생

    }
}