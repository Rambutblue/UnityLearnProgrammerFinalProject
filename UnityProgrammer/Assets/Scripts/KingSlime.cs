using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlime : Slime
{
     

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 20;
        jumpSpeed = 50;
        jumpCooldown = 5;
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();

    }

    


}
