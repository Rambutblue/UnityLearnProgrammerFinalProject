using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlime : Slime
{
    
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 5;
        jumpSpeed = 5;
        jumpCooldown = 1.5f;
        specialAbilityRange = 8;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }
    protected override void SpecialAbility()
    {
        player.GetComponent<PlayerController>().walkSpeed = 4;
        player.GetComponent<PlayerController>().runSpeed = 5;
    }
    protected override void SpecialAbilityDisable()
    {
        player.GetComponent<PlayerController>().walkSpeed = player.GetComponent<PlayerController>().walkSpeed_base;
        player.GetComponent<PlayerController>().runSpeed = player.GetComponent<PlayerController>().runSpeed_base;
    }



}
