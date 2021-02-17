using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private SavesManager saves;
    void Awake()
    {
        saves = FindObjectOfType<SavesManager>();
    }

    public void ButtonClick()
    {
        saves.Delete();
        SceneManager.LoadScene(0);
    }
}
