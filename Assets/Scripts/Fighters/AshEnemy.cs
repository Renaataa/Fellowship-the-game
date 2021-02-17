using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AshEnemy : Fighter
{
    public Hero hero;
    public AshEnemy()
    {
        maxHealth = currentHealth = 19;
        strength = 12;
    }

    public override void Start()
    {
        slider = progressBar.GetComponent<Slider>();
        slider.value = slider.maxValue = maxHealth;
        slider.minValue = 0;
        progressBar.TextUpdate();
    }

    public override void Attack(Fighter target)
    {
        animator.SetTrigger("attack");
        target.TakeDmg(Random.Range(-2, 2) + strength);
        target.animator.SetTrigger("hit");
        Debug.Log("Ash attack");
    }
    public override void Turn()
    {
        Attack(hero);
        //turnManager.EndTurn();
    }

}
