using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleFightButtons : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayGame_Fight1()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayGame_Fight2()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayGame_Fight3()
    {
        SceneManager.LoadScene(4);
    }
   
}
