using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int playerHp { get; private set; } = 5;
    public float walkSpeed_base { get; } = 7;   
    public float walkSpeed = 7;
    public float runSpeed_base { get; } = 11;
    public float runSpeed = 11;
    public float jumpSpeed_base { get; } = 8;
    public float jumpSpeed = 8;
    [SerializeField]
    private float gravity = 20;
    public Camera playerCamera;
    public GameObject bullet;
    [SerializeField]
    public float lookSpeed = 2;
    [SerializeField]
    private float lookXLimit = 45;
    public GameObject GameOverPanel;
    public GameObject HpPanel;
    public GameObject RestartButton;
    public bool isGameActive = true;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    bool canMove = true;
    Vector3 thePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedZ = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedZ);
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
       
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        

        if (Input.GetMouseButtonDown(0) && isGameActive)
        {
            thePosition = playerCamera.transform.TransformPoint(Vector3.forward * 2);
            Instantiate(bullet, thePosition, bullet.transform.rotation);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerHp -= 1;
            Debug.Log(playerHp);
            HpPanel.GetComponent<TextMeshProUGUI>().text = "Hp: " + playerHp;
        }
        if (playerHp <= 0)
        {
            Debug.Log("GameOver!");
            GameOver();
        }
    }
    //Abstraction
    private void GameOver()
    {

        GameOverPanel.SetActive(true);
        RestartButton.SetActive(true);
        DisableGame();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void DisableGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lookSpeed = 0;
        Time.timeScale = 0;
        isGameActive = false;
    }
    public void EnableGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookSpeed = 4;
        Time.timeScale = 1;
        isGameActive = true;
    }
}
