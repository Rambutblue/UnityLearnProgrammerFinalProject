using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingSlime : Slime
{
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 3;
        jumpSpeed = 4;
        jumpCooldown = 1;
        specialAbilityRange = 10;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }
    protected override void SpecialAbility()
    {
        player.GetComponent<PlayerController>().jumpSpeed = 0;
    }
    protected override void SpecialAbilityDisable()
    {
        player.GetComponent<PlayerController>().jumpSpeed = player.GetComponent<PlayerController>().jumpSpeed_base;
        
    }
}
