using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    public GameObject nameSlot;
    public GameObject startMenu;
    public GameObject highscore;
    public GameObject highscoreText1;
    public GameObject highscoreText2;
    public void Play()
    {
        MenuManager.instance.currentName = nameSlot.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }
    public void SeeHighscore()
    {
        startMenu.SetActive(false);
        highscore.SetActive(true);
        MenuManager.instance.LoadData();
        if(MenuManager.instance.score != 0)
        {
            highscoreText1.GetComponent<TextMeshProUGUI>().text = "The highscore is: " + MenuManager.instance.score;
            highscoreText2.GetComponent<TextMeshProUGUI>().text = "And was achieved by: " + MenuManager.instance.playerName;
        }
        else
        {
            highscoreText1.GetComponent<TextMeshProUGUI>().text = "This place is yet to be claimed!";
        }
    }
    public void BackHighscore()
    {
        highscore.SetActive(false);
        startMenu.SetActive(true);
    }
}
