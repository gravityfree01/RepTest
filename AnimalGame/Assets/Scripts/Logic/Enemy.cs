using UnityEngine;

/*
 * @class Enemy
 * @desc  적군 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class Enemy : MonoBehaviour
{
    private Life life;

    public GameObject enemyObject;
    public Transform enemyLocation;

    private float DestroyPosY = -3f;

    private void Start()
    {
        life = GameObject.Find("LifeText").GetComponent<Life>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime);

        if (transform.position.y <= DestroyPosY)
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;

            if (!Item.isEnabled)
                life.LifeDecrease();

            if (life.HasDied())
                life.Dead();
        }
    }
}