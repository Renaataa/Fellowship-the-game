using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HidingButtonsSystem : MonoBehaviour
{
    public Button[] buttons = new Button[3];
    private SavesManager saves;
    public static HidingButtonsSystem Instance = null;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        saves = FindObjectOfType<SavesManager>();

        switch (saves.level)
        {
            case 0:
                buttons[0].interactable = true;
                buttons[1].interactable = false;
                buttons[2].interactable = false;
                break;
            case 1:
                buttons[0].interactable = false;
                buttons[1].interactable = true;
                buttons[2].interactable = false;
                break;
            case 2:
                buttons[0].interactable = false;
                buttons[1].interactable = false;
                buttons[2].interactable = true;
                break;
            case 3:
                //saves.Delete();
                SceneManager.LoadScene(5);
                break;
            default:
                Debug.LogError("That shouldnt happen");
                break;
        }
    }
}
