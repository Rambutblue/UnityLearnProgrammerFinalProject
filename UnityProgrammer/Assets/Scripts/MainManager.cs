using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject howToPlay;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            player.GetComponent<PlayerController>().DisableGame();
        }
    }
    public void Unpause()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<PlayerController>().EnableGame();

    }
    public void ToControlls()
    {
        pauseMenu.SetActive(false);
        howToPlay.SetActive(true);
    }
    public void FromControlls()
    {
        howToPlay.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Exit()
    {
        
    }
}
