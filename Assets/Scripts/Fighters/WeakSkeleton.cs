using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeakSkeleton : Fighter
{
    public Hero hero;

    public override void Start()
    {
        maxHealth = currentHealth = 20;
        strength = 10;
        slider = progressBar.GetComponent<Slider>();
        slider.value = slider.maxValue = maxHealth;
        slider.minValue = 0;
        progressBar.TextUpdate();
    }
    public override void Attack(Fighter target)
    {
        animator.SetTrigger("attack");
        target.animator.SetTrigger("hit");
        target.TakeDmg(Random.Range(-2, 2) + strength);
        Debug.Log("Weak skeleton attack");
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
    }
    public override void BleedAttack()
    {
        hero.setBleed(3);
        animator.SetTrigger("attack");
        hero.animator.SetTrigger("hit");
        Debug.Log("Skeleton Spear attack");
    }
}
