using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2021-07-08 gate 4개에서 Enemy 가 떨어지는 것
// 박성수 작성
public class EnemySpawnManager : MonoBehaviour
{
    public GameObject gate_1;
    public GameObject gate_2;
    public GameObject gate_3;
    public GameObject gate_4;

    public GameObject enemy;

    float gate_1_timer = 0.0f;
    float gate_2_timer = 0.0f;
    float gate_3_timer = 0.0f;
    float gate_4_timer = 0.0f;
    void Update()
    {
        // 2021-07-08 gate 4개에서 시간차별로 Enemy 가 떨어지는 것
        // 박성수 작성 
        gate_1_timer += Time.fixedDeltaTime;
        gate_2_timer += Time.fixedDeltaTime;
        gate_3_timer += Time.fixedDeltaTime;
        gate_4_timer += Time.fixedDeltaTime;

        if (gate_1_timer >=3f)
        {
            //생성
            Instantiate(enemy, gate_1.transform.position,Quaternion.identity, gate_1.transform);
            gate_1_timer = 0f;
        }

        if(gate_2_timer >= 5f)
        {
            //생성
            Instantiate(enemy, gate_2.transform.position, Quaternion.identity, gate_2.transform);
            gate_2_timer = 0f;
        }

        if (gate_3_timer >= 6f)
        {
            //생성
            Instantiate(enemy, gate_3.transform.position,Quaternion.identity, gate_3.transform);
            gate_3_timer = 0f;
        }

        if (gate_4_timer >= 7f)
        {
            //생성
            Instantiate(enemy, gate_4.transform.position,Quaternion.identity, gate_4.transform);
            gate_4_timer = 0f;
        }
    }
}
