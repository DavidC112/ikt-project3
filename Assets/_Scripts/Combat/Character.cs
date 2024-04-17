using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public Player player;
    public int maxHealth;
    public int currentHealth;
    public int maxPP;
    public int currentPP;
    public Slider hpSlider;
    public Slider ppSlider;

    private void Start()
    {
        maxHealth = player.vigor * 2;
        currentHealth = maxHealth;

        maxPP = (player.intelligence + player.endurance) * 2;
        currentPP = maxPP;

        hpSlider.maxValue = maxHealth;
        ppSlider.maxValue = maxPP;
        SetHP(maxHealth);
        SetPP(maxPP);
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetPP(int pp)
    {
        ppSlider.value = pp;
    }

    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 ) 
            return true;
        else 
            return false;
    }

    public void Heal(int healingAmount)
    {
        if (currentHealth + healingAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
            currentHealth += healingAmount;

        SetHP(currentHealth);
    }

    public void AddPP(int addPP)
    {
        if (currentPP + addPP > maxPP)
        {
            currentPP = maxPP;
        }
        else
            currentPP += addPP;

        SetPP(currentPP);
    }
}
