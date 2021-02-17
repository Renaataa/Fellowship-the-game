using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FightHandler : MonoBehaviour
{
    public Hero hero;
    public Fighter fighter1;
    public Fighter fighter2;

    public Button buttonTrg1;
    public Button buttonTrg2;

    private SavesManager saves;

    private void Awake()
    {
        saves = FindObjectOfType<SavesManager>();
    }
    public void ToMenu()
    {
        saves.level++;
        SceneManager.LoadScene(1);
    }
    public void Attack(Fighter target)
    {
        hero.Attack(target);
        buttonTrg1.interactable = false;
        if(buttonTrg2!= null)
            buttonTrg2.interactable = false;
    }

    public void AttackClick()
    {
        hero.DisableButtons();
        if (fighter1.getHealth() > 0)
            buttonTrg1.interactable = true;
        if (buttonTrg2 != null)
            if (fighter2 != null && fighter2.getHealth() > 0)
                buttonTrg2.interactable = true;
    }

    public void WideAttackClick()
    {
       hero.WideAttack(fighter1, fighter2);
    }
    public void ShieldClick()
    {
        hero.ShieldUp();
    }
}
