using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Player
 * @desc 플레이어 속성 클래스
 * @author  정성호
 * @date  2021-07-09 */

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(x, 0, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    void OnTriggerEnter2D(Collider2D collision)    {
        if (collision.gameObject.tag == "Player")        {
            collision.gameObject.SetActive(false);
        }
    }
}

			 
															   
 

			  
							

											


						
	 
 

					  
					   

 

						  
						

 

				   
												 
																		  
								  
									 

							
 
 
  






