using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public static SavesManager Instance = null;
    public int level;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
