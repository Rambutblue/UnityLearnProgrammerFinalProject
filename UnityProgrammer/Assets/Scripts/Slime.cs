using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Inheritance
public abstract class Slime : MonoBehaviour
{
    private bool _isAbilityActive = false;
    public bool isAbilityActive { 
        get { return _isAbilityActive; }
        set 
        { 
            _isAbilityActive = value;
            if (_isAbilityActive)
            {
                SpecialAbility();
            }
            else
            {
                SpecialAbilityDisable();
            }
        }
    }
    protected int maxHp;
    protected int jumpSpeed;
    protected float jumpCooldown;
    protected int specialAbilityRange;
    private static int _score;
    //Encapsulation
    public static int score { 
        get { return _score; } 
        protected set 
        {
            _score = value;
            GameObject.Find("Canvas").transform.Find("ScorePanel").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        } 
    }
    protected bool hasJumpReady = true;
    protected GameObject player;
    protected Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasJumpReady)
        {
            Jump();
            hasJumpReady = false;
            StartCoroutine(JumpCoolDown());
        }
        if ((player.transform.position - transform.position).magnitude < specialAbilityRange)
        {
            isAbilityActive = true;
        }
        else
        {
            isAbilityActive = false;
        }
        
    }
    void Jump()
    {

        Vector3 vectorToPlayer = player.transform.position - transform.position;
        vectorToPlayer.Normalize();
        rb.AddForce(vectorToPlayer * jumpSpeed, ForceMode.VelocityChange);
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
    }
    
    IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        hasJumpReady = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        maxHp -= 1;
        if (maxHp <= 0)
        {
            score += 50;
            SpecialAbilityDisable();
            Destroy(gameObject);
        }
    }
    //Polymorphism
    protected abstract void SpecialAbility();

    protected abstract void SpecialAbilityDisable();


}
