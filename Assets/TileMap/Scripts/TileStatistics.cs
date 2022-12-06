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
    [SerializeField] public int bonusAttackRange;
    [SerializeField] public int bonusMovementRange;
    [SerializeField] public int bonusRefuelRange;
    [Space(15)]

    [SerializeField] public bool forCAC;
    [SerializeField] public bool forCACL;
    [SerializeField] public bool forDT;
    [SerializeField] public bool forH;
    [Space(25)]


    [Header("Structure")]
    [Space(15)]

    [SerializeField] public int captureHP;
    [SerializeField] public int fundPerTurn;
    [SerializeField] public int defencePoints;
    [Space(25)]


    [Header("Unit")]
    [Space(15)]
    [SerializeField] public float baseHealth;
    [SerializeField] public float baseAttack;
    [SerializeField] public float baseDefence;
    [SerializeField] public int baseVision;
    [SerializeField] public int baseMovement;
    [SerializeField] public int baseMana;
    [SerializeField] public int baseStamina;
    [Space(15)]

    [SerializeField] public float health;
    [SerializeField] public float attack;
    [SerializeField] public float defence;
    [SerializeField] public int Vision;
    [SerializeField] public int Movement;
    [SerializeField] public int mana;
    [SerializeField] public int stamina;
    [SerializeField] public int turnsBeforeProduced;
    [SerializeField] public int fundCost;
}