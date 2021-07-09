using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 이거 안넣으면 The name 'SceneManager' does not exist in the current context 라고 오류뜸


/**
* 사용함수 : SceneManager.LoadScene (sceneIndex)
* @date : 2021-07-04
* @author : 정성호
* @Comment : 게임 시작 클릭시 
* 
* 
* 
*/





public class loadSceneOnclick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
