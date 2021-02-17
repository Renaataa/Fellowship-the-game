using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Fighter
{
    public Button[] buttons;
    public RawImage bloodIcon;
    public RawImage shieldIcon;
    public override void Start()
    {
        maxHealth = currentHealth = 30;
        strength = 5;
        slider = progressBar.GetComponent<Slider>();
        slider.value = slider.maxValue = maxHealth;
        slider.minValue = 0;
        bloodIcon.enabled = false;
        shieldIcon.enabled = false;
        progressBar.TextUpdate();
    }

    public override void Attack(Fighter target)
    {
        Debug.Log("Hero attack");
        DisableButtons();
        target.animator.SetTrigger("hit");
        animator.SetTrigger("attack");
        target.TakeDmg(Random.Range(-2,2) + strength);
    }

    public void WideAttack(Fighter target1, Fighter target2)
    {
        Debug.Log("Hero wide attack");
        DisableButtons();
        if (target1 != null)
        {
            target1.animator.SetTrigger("hit");
            target1.TakeDmg(Random.Range(-1,1) + strength / 2);
        }
        if (target2 != null)
        {
            target2.animator.SetTrigger("hit");
            target2.TakeDmg(Random.Range(-1, 1) + strength / 2);
        }
        animator.SetTrigger("wideAttack");
    }

    public void ShieldUp()
    {
        Debug.Log("Hero Shield Up");
        DisableButtons();
        shieldIcon.enabled = true;
        shield = 20;
        animator.SetTrigger("shield");
    }

    public void setBleed(int bleed)
    {
        bloodIcon.enabled = true;
        this.bleed = bleed;
    }

    public void Bleed()
    {
        if (bleed > 0)
        {
            TakeDmg(bleed);
            bleed--;
            animator.SetTrigger("hit");
        }
        if (bleed <= 0)
        {
            bloodIcon.enabled = false;
        }   
    }

    public override void Turn()
    {
        EnableButtons();
    }
    public void EnableButtons()
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }
    }
    public void DisableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public override void TakeDmg(int dmg)
    {
        Debug.Log(this.ToString() + " take dmg");
        if(shield >= dmg)
        {
            shield -= dmg;
        }
        else if(shield > 0 && shield < dmg )
        {
            currentHealth -= (dmg - shield);
            shield = 0;
            shieldIcon.enabled = false ;
            slider.value = currentHealth;
            progressBar.TextUpdate();
        }
        else
        {
            currentHealth -= dmg;
            slider.value = currentHealth;
            progressBar.TextUpdate();
        }
        if (currentHealth <= 0)
        {
            Debug.Log(this.ToString() + " died");
            //turnManager.Kick(this.GetInstanceID());
            animator.SetTrigger("die");
        }

    }



}
