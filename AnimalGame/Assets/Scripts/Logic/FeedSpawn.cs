using System.Collections;
using UnityEngine;


/** 
* 사용함수 : 
* @date : 2021-07-09
* @author : 정성호
* @Comment : 
*/

public class FeedSpawn : MonoBehaviour{
    public Feed feed; // 객체 생성

    private MemoryPool memoryPool;           // 메모리 풀
    private GameObject[] feedArray;  // 메모리 풀과 연동하여 사용할 Feed 배열
    private int feedMaxPool = 10;
    private bool isEndPoint = false;
    private float posX = 0f;

    private void OnApplicationQuit()
    {
        // 메모리 풀을 비웁니다.
        memoryPool.Dispose();
    }

    void Start()
    {
        // 메모리 풀을 초기화합니다.
        memoryPool = new MemoryPool();
        // feedMaxPool만큼 생성합니다.
        memoryPool.Create(feed.feedObject, feedMaxPool);
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        feedArray = new GameObject[feedMaxPool];
    }

    void Update()
    {
        // 매 프레임마다 GenerateFeed 함수를 체크한다.
        SpawnFeed();
    }

    private void SpawnFeed()
    {
        // 코루틴 "FeedCycleControl"이 실행되며
        StartCoroutine(FeedCycleControl());

        // Feed 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
        for (int i = 0; i < feedMaxPool; i++)
        {
            // 만약 Feed배열[i]가 비어있다면
            if (feedArray[i] == null)
            {
                // 메모리풀에서 Feed 가져온다.
                feedArray[i] = memoryPool.NewItem();

                // 지그재그로 Feed 발사하기
                Vector2 vector = Vector2.zero;
                if (posX < 2f && isEndPoint == false)
                    posX += 1.0f;
                else
                    isEndPoint = true;

                if (isEndPoint == true)
                    posX -= 1.0f;

                if (posX < -2f)
                    isEndPoint = false;
                vector.x = posX;
                vector.y = 5f;
                feed.feedLocation.transform.position = vector;

                // 해당 Feed 위치를 Feed 발사지점으로 맞춘다.
                feedArray[i].transform.position = feed.feedLocation.transform.position;
                // 발사 후에 for문을 바로 빠져나간다.
                break;
            }
        }

        // Feed 발사될때마다 Feed를 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < feedMaxPool; i++)
        {
            // 만약 Feed[i]가 활성화 되어있다면
            if (feedArray[i])
            {
                // Feed[i]의 Collider2D가 비활성 되었다면
                if (feedArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // 다시 Collider2D를 활성화 시키고
                    feedArray[i].GetComponent<Collider2D>().enabled = true;
                    // Feed를 메모리로 돌려보내고
                    memoryPool.RemoveItem(feedArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    feedArray[i] = null;
                }
            }
        }
    }

    // 코루틴 함수
    IEnumerator FeedCycleControl()
    {
        // FireDelay초 후에
        yield return new WaitForSeconds(feed.feedDelay);
    }
}