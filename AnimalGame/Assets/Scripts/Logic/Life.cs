using UnityEngine;
using UnityEngine.UI;

/*
 * @class Life
 * @desc  목숨 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class Life : MonoBehaviour
{
    public int lifeCount = 3;
    public Text lifeText;

    void Update()
    {
        lifeText.text = lifeCount.ToString();
        Debug.Log("라이프 개수: " + lifeCount);
    }

    public void LifeDecrease()
    {
        lifeCount--;
    }
}