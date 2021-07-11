using System.Collections;
using UnityEngine;

/*
 * @class ItemSpawn
 * @desc 아이템 기능 정보를 담는 클래스
 * @author  정성호
 * @date  2021-07-11
 */

public class ItemSpawn : MonoBehaviour
{
    public Item item;

    private MemoryPool memoryPool;           // 메모리 풀
    private GameObject[] itemArray;  // 메모리 풀과 연동하여 사용할 Feed 배열
    private int itemMaxPool = 1;
    private SpriteRenderer spriteRenderer;
    private float time = 0f;

    void Start()
    {
        memoryPool = new MemoryPool();
        memoryPool.Create(item.itemObject, itemMaxPool);
        itemArray = new GameObject[itemMaxPool];

        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SpawnItem();
        GodMode();
    }

    private void SpawnItem()
    {
        StartCoroutine(ItemCycleControl());

        for (int i = 0; i < itemMaxPool; i++)
        {
            if (itemArray[i] == null)
            {
                itemArray[i] = memoryPool.NewItem();

                Vector2 vector = Vector2.zero;
                vector.x = Random.Range(-2f, 2f);
                vector.y = 5f;

                item.itemLocation.transform.position = vector;
                itemArray[i].transform.position = item.itemLocation.transform.position;

                break;
            }
        }

        for (int i = 0; i < itemMaxPool; i++)
        {
            if (itemArray[i])
            {
                if (itemArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    itemArray[i].GetComponent<Collider2D>().enabled = true;
                    memoryPool.RemoveItem(itemArray[i]);
                    itemArray[i] = null;
                }
            }
        }
    }

    private void GodMode()
    {
        if (Item.isEnabled) // 무적 아이템을 먹으면
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            Debug.Log(Item.isEnabled + " 활성화됨.");

            // 이 부분에 무적이 됐을 때 어떻게 처리할 것인지 추가

            time += Time.deltaTime;
            if (time >= 5f) // 무적 시간 종료되면
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                Item.isEnabled = false;
                time = 0;
            }
        }
    }

    IEnumerator ItemCycleControl()
    {
        yield return new WaitForSeconds(3f);
    }
}