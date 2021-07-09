using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSHMainMenu : MonoBehaviour
{

    void Start()
    {

    }

    // 20210701 정성호 작성버튼 작동
    // 참고 : https://www.youtube.com/watch?v=LooUj77MVSU&t=247s
    void Update()
    {

    }
    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
    }

    public void OnClickLoad()
    {
        Debug.Log("랭킹");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying=false;

#else
        application.Quit();

#endif
    }
}