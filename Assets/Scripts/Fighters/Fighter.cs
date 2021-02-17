using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Fighter : MonoBehaviour
{
    protected int maxHealth;
    protected int currentHealth;
    protected int strength;
    protected int shield;
    protected int bleed;

    protected Slider slider;

    public ProgressBar progressBar;

    protected TurnManager turnManager;
    public Animator animator;

    public virtual void Start() { }

    public void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        animator = GetComponent<Animator>();
    }
    public virtual void Attack(Fighter fighter) { }

    public virtual void BleedAttack() { }

    public virtual void Turn() { }

    public virtual void Die()
    {
        animator.enabled = false;
        turnManager.CheckEndFight();
    }
    public virtual void TakeDmg(int dmg)
    {
        Debug.Log(this.ToString() + " take dmg");
        currentHealth -= dmg;
        slider.value = currentHealth;
        progressBar.TextUpdate();
        if (currentHealth <= 0)
        {
            Debug.Log(this.ToString() + " died");
            turnManager.Kick(this.GetInstanceID());
            animator.SetTrigger("die");
        }
    }
    public int getHealth()
    {
        return currentHealth;
    }

    public void EndTurnTrigger()
    {
        turnManager.EndTurn();
    }
}
