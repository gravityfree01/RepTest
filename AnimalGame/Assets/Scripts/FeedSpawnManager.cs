﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSpawnManager : MonoBehaviour{
    Logic logic = null;
    List<GameObject> feedList;

    private void Start(){
        logic=GameObject.Find("GameManager").GetComponent<Logic>();
        feedList=new List<GameObject>();
    }

    // 피드 소환하는곳.
    private void SpawnFeed(){
        GameObject obj = Resources.Load("Prefabs/Feed") as GameObject;
        feedList.Add(obj);
    }


    // Feed 객체 리스트 전체 지우기
    private void ClearFeedList(){
        for(int i = 0; i< feedList.Count; i++){
            Destroy(feedList[i].gameObject);
        }
        feedList.Clear();
    }




}