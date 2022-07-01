using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    
    protected int maxHp;
    protected int jumpSpeed;
    protected int jumpCooldown;
    //Encapsulation
    public static int score { get; protected set; }
    protected bool hasJumpReady = true;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
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
        
    }
    public void Jump()
    {

        Vector3 vectorToPlayer = player.transform.position - transform.position;
        vectorToPlayer.Normalize();
        rb.AddForce(vectorToPlayer * jumpSpeed);
        rb.AddForce(Vector3.up * jumpSpeed / 3);

        //Vector3 axis = Vector3.Cross(vectorToPlayer, new Vector3(1, 0, 1));
        //gameObject.GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(55, axis) * vectorToPlayer * jumpSpeed, ForceMode.Impulse);
    }
    
    public IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        hasJumpReady = true;
        yield return null;
    }

}
