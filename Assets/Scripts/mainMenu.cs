using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Button button;
    private SavesManager saves;
    private void Awake()
    {
        Debug.Log("Start");
        saves = FindObjectOfType<SavesManager>();
        if (saves)
            button.interactable = true;
        else
            button.interactable = false;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        if(saves)
        {
            saves.Delete();
        }
        SceneManager.LoadScene(1);
    }
    public void ContinueClick()
    {
        SceneManager.LoadScene(1);
    }
}
