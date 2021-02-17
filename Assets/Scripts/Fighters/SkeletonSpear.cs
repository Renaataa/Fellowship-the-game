using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonSpear : Fighter
{
    public Hero hero;
    public SkeletonSpear()
    {
        maxHealth = currentHealth = 15;
        strength = 3;
    }

    public override void Start()
    {
        slider = progressBar.GetComponent<Slider>();
        slider.value = slider.maxValue = maxHealth;
        slider.minValue = 0;
        progressBar.TextUpdate();
    }

    public override void BleedAttack()
    {
        hero.setBleed(3);
        animator.SetTrigger("attack");
        hero.animator.SetTrigger("hit");
        Debug.Log("Skeleton Spear attack");
    }

    public override void Attack(Fighter target)
    {
        animator.SetTrigger("attack");
        target.TakeDmg(Random.Range(-2, 2) + strength);
        target.animator.SetTrigger("hit");
        Debug.Log("Skeleton Spear attack");
    }
    public override void Turn()
    {
        if (Random.Range(0, 100) < 33.3)
        {
            Debug.Log("Bleed Attack");
            BleedAttack();
        }
        else
        {
            Attack(hero);
        }
        //turnManager.EndTurn();
    }

}
