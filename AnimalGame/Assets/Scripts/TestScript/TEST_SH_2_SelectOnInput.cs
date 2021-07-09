using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // 이거 안넣으면 The name 'SceneManager' does not exist in the current context 라고 오류뜸

/**
* 사용함수 : eventSystem.SetSelectedGameObject (selectedObject)
* @date : 2021-07-04
* @author : 정성호
* @Comment : 오디오 조절 스크립트
* 
*/

public class SelectOnInput : MonoBehaviour 
{
	public EventSystem eventSystem;
	public GameObject selectedObject;
	private bool buttonSelected;




	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;

		}
	}
	private void onDisable()
	
	{
		buttonSelected = false;
	}
}
