using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 40f;
    private GameObject playerCamera;
    private Vector3 bulletDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Camera");
        bulletDirection = playerCamera.transform.TransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDirection * Time.deltaTime * speed);
        float distance = Vector3.Distance(playerCamera.transform.position, transform.position);
        if (distance > 75)
        {
            Destroy(gameObject);
        }
    }

}
