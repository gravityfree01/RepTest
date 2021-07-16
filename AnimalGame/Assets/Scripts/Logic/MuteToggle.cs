using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @class MuteToggle
 * @desc  오디오 무음 토글스위치 클래스
 * @author 정성호
 * @date  2021-07-13
 */
[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    Toggle myToggle;

    void Start()
    {
        myToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 0)
        {
            myToggle.isOn = false;
        }
    }

    public void ToggleAuioOnValueChange(bool audioIn)
    {
        if(audioIn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    void Update()
    {
        
    }
}
