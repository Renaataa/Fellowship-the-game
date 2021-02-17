using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public Hero hero;
    public Fighter enemy1;
    public Fighter enemy2;

    private bool stopped = true;
    private int index = 0;
    private List<Fighter> fighters = new List<Fighter>();
    private SavesManager saves;
    public void ToMenu()
    {
        saves.level++;
        SceneManager.LoadScene(1);
    }
    private void Awake()
    {
        fighters.Add(hero);
        fighters.Add(enemy1);
        if(enemy2 != null)
            fighters.Add(enemy2);
        saves = FindObjectOfType<SavesManager>();
    }

    private void Update()
    {
        if (stopped)
            NextTurn();     
    }
    public void NextTurn()
    {
        Debug.Log("Turn of: " + fighters[index].ToString());
        fighters[index].Turn();
        stopped = false;
        index++;
        if (index >= fighters.Count)
        {
            index = 0;
            hero.Bleed();
        }
    }
    public void EndTurn()
    {
        stopped = true;
    }
    public void CheckEndFight()
    {
        if (hero.getHealth() <= 0)
            SceneManager.LoadScene(6); //przegrałeś
        else if(enemy1.getHealth()<=0)
        {
            if (enemy2 != null)
            {
                if (enemy2.getHealth() <= 0)
                    ToMenu(); //win
            }else
                ToMenu(); 
        }
    }
    public void Kick(int id)
    {
        for(int i = 0; i<=fighters.Count;i++)
        {
            if(fighters[i].GetInstanceID() == id)
            {
                Debug.Log(fighters.ToString() + " deleted");
                fighters.RemoveAt(i);
                if (index >= fighters.Count || index < 0)
                    index = 0;
                break;
            }
        }
    }
}
