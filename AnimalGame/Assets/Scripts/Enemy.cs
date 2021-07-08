using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectParent{

    string playerTag = "Player";

    void Update(){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == playerTag )
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
