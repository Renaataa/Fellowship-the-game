using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonArcher : Fighter
{
    public Hero hero;

    public override void Start()
    {
        maxHealth = currentHealth = 10;
        strength = 8;
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
        Debug.Log("Skeleton archer attack");
    }
    public override void Turn()
    {
        Attack(hero);
    }

}
