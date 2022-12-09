using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatistics : MonoBehaviour
{
    [Header("Terrain")]
    [Space(15)]

    [SerializeField] public int bonusAttack;
    [SerializeField] public int bonusDefence;
    [SerializeField] public int bonusVision;
    [SerializeField] public int bonusMovementRange;
    [Space(15)]

    [SerializeField] public int handicapAttack;
    [SerializeField] public int handicapDefence;
    [SerializeField] public int handicapVision;
    [SerializeField] public int handicapMovementRange;
    [Space(25)]


    [Header("Structure")]
    [Space(15)]

    [SerializeField] public int baseCaptureHP;
    [SerializeField] public int captureHP;
    [SerializeField] public int fundPerTurn;
    [SerializeField] public int defencePoints;
    [Space(25)]


    [Header("Unit")]
    [Space(15)]
    [SerializeField] public float baseHealth;
    [SerializeField] public float baseCharacter;
    [SerializeField] public float baseAttack;
    [SerializeField] public float baseDefence;
    [SerializeField] public int baseVision;
    [SerializeField] public int baseMovement;
    [SerializeField] public int baseMana;
    [SerializeField] public int baseStamina;
    [SerializeField] public int baseTurnsBeforeProduced;
    [Space(15)]

    [SerializeField] public float health;
    [SerializeField] public float character;
    [SerializeField] public float attack;
    [SerializeField] public float defence;
    [SerializeField] public int vision;
    [SerializeField] public int movement;
    [SerializeField] public int mana;
    [SerializeField] public int stamina;
    [SerializeField] public int fundCost;
    [SerializeField] public int turnsBeforeProduced;

    public void Start()
    {
        health = baseHealth;
        character= baseCharacter;
        attack = baseAttack;
        defence = baseDefence;
        vision = baseVision;
        movement = baseMovement;
        mana = baseMana;
        stamina = baseStamina;
    }

    public void FixedUpdate()
    {
        if(health > 10) 
        {
            health = 10;
        }

        if (attack < 0)
        {
            attack = 0;
        }

        if (defence > 5)
        {
            defence = 5;
        }

        if (defence < 0)
        {
            defence = 0;
        }

        if (vision < 1)
        {
            vision = 1;
        }

        if(movement< 1) 
        { 
            movement= 1;
        }

        if (mana < 0)
        {
            mana = 0;
        }

        if (stamina > 100)
        {
            stamina = 100;
        }

        if (stamina < 1)
        {
            stamina = 0;
            movement = 1;
        }

        if(movement > stamina)
        {
            movement= stamina;
        }

        if(baseHealth > health)
        {
            float healthlost = baseHealth - health;
            float characterhealthratio = baseHealth / baseCharacter;
            float characterslost = Mathf.FloorToInt(healthlost / characterhealthratio);
            character = baseCharacter - characterslost;
        }

    }
}