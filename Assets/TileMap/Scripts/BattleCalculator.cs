using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCalculator : MonoBehaviour
{
    [SerializeField] private GameObject AttackingUnit;

    [SerializeField] private GameObject DefendingUnit;

    [SerializeField] private GameObject BattleUI;

    [SerializeField] private float AttackPOWER;

    [SerializeField] private float DefencePOWER;

    [SerializeField] private float RPC;

    [SerializeField] private float Damage;

    [SerializeField] private float AnimationTime;

    [SerializeField] public float COPowerHell;

    [SerializeField] public float COPowerHeaven;

    public void StartBattle()
    {
        AttackingUnit = this.gameObject.GetComponent<Actions>().PreviousUnit;

        DefendingUnit = this.gameObject.GetComponent<Actions>().SelectedUnit;


        AnimationSetup();

        BattleUI.gameObject.SetActive(true);

        Attack();
    }

    public void Attack()
    {
        BattleUI.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);

        AttackPOWER = AttackingUnit.GetComponent<TileStatistics>().attack * (AttackingUnit.GetComponent<TileStatistics>().character / AttackingUnit.GetComponent<TileStatistics>().baseCharacter);

        DefencePOWER = AttackingUnit.GetComponent<TileStatistics>().defence;

        RPCManagement();

        Damage = Mathf.FloorToInt((AttackPOWER * RPC - DefencePOWER) * 10) / 10;

        Debug.Log(Damage);

        DefendingUnit.GetComponent<TileStatistics>().health -= Damage/2;

        if (DefendingUnit.GetComponent<TileStatistics>().health <= 0)
        {
            DefendingUnit.SetActive(false);
        }

        if(AttackingUnit.GetComponent<TileState>().teamHell) 
        {
            COPowerHell += Damage / 2;
        }

        if (AttackingUnit.GetComponent<TileState>().teamHeaven)
        {
            COPowerHeaven += Damage / 2;
        }
    }

    public void RPCManagement()
    {
        //--------------------------------------------------------NEUTRAL------------------------------------------------
        RPC = 1;
        //--------------------------------------------------------STRONG------------------------------------------------
        if(AttackingUnit.GetComponent<TileState>().isStrongVsCAC && DefendingUnit.GetComponent<TileState>().isCAC)
        {
            RPC += 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isStrongVsTALD && DefendingUnit.GetComponent<TileState>().isTALD)
        {
            RPC += 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isStrongVsT && DefendingUnit.GetComponent<TileState>().isT)
        {
            RPC += 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isStrongVsS && DefendingUnit.GetComponent<TileState>().isS)
        {
            RPC += 0.5f;
        }
        //--------------------------------------------------------WEAK------------------------------------------------
        if (AttackingUnit.GetComponent<TileState>().isWeakVsCAC && DefendingUnit.GetComponent<TileState>().isCAC)
        {
            RPC *= 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isWeakVsTALD && DefendingUnit.GetComponent<TileState>().isTALD)
        {
            RPC *= 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isWeakVsT && DefendingUnit.GetComponent<TileState>().isT)
        {
            RPC *= 0.5f;
        }
        if (AttackingUnit.GetComponent<TileState>().isWeakVsS && DefendingUnit.GetComponent<TileState>().isS)
        {
            RPC *= 0.5f;
        }
    }



    public void CounterAttack()
    {
        Debug.Log("you did it, you counter attacked! What a move!");

        BattleUI.transform.GetChild(5).GetChild(2).gameObject.SetActive(true);

        AttackPOWER = DefendingUnit.GetComponent<TileStatistics>().attack * (DefendingUnit.GetComponent<TileStatistics>().character / DefendingUnit.GetComponent<TileStatistics>().baseCharacter);

        DefencePOWER = DefendingUnit.GetComponent<TileStatistics>().defence;

        RPCManagement();

        Damage = Mathf.FloorToInt((AttackPOWER * RPC - DefencePOWER) * 10) / 10;

        Debug.Log(Damage);

        if (DefendingUnit.activeInHierarchy)
        {
            AttackingUnit.GetComponent<TileStatistics>().health -= Damage / 2;
        }


        if (AttackingUnit.GetComponent<TileStatistics>().health <= 0)
        {
            AttackingUnit.SetActive(false);
        }

        if (AttackingUnit.GetComponent<TileState>().teamHell)
        {
            COPowerHell += Damage;
        }

        if (AttackingUnit.GetComponent<TileState>().teamHeaven)
        {
            COPowerHeaven += Damage;
        }
    }

    public void AnimationSetup()
    {

        //---------------------------------------------------------------------ATTACK SETUP---------------------------------------
        BattleUI.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        BattleUI.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        BattleUI.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        BattleUI.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

        if (AttackingUnit.GetComponent<TileState>().isCAC)
        {
            BattleUI.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        if (AttackingUnit.GetComponent<TileState>().isTALD)
        {
            BattleUI.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        }
        if (AttackingUnit.GetComponent<TileState>().isT)
        {
            BattleUI.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        }
        if (AttackingUnit.GetComponent<TileState>().isS)
        {
            BattleUI.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }

        BattleUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = "PV" + AttackingUnit.GetComponentInChildren<TextMesh>().text;


        BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().maxValue = AttackingUnit.GetComponent<TileStatistics>().baseHealth;
        BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().minValue = 0;
        BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value = float.Parse(AttackingUnit.GetComponentInChildren<TextMesh>().text);

        BattleUI.transform.GetChild(3).GetChild(3).GetComponent<Text>().text = AttackingUnit.name;



        //---------------------------------------------------------------------DEFENCE SETUP---------------------------------------
        BattleUI.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        BattleUI.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        BattleUI.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        BattleUI.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);

        if (DefendingUnit.GetComponent<TileState>().isCAC)
        {
            BattleUI.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        }
        if (DefendingUnit.GetComponent<TileState>().isTALD)
        {
            BattleUI.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
        if (DefendingUnit.GetComponent<TileState>().isT)
        {
            BattleUI.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        }
        if (DefendingUnit.GetComponent<TileState>().isS)
        {
            BattleUI.transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
        }

        BattleUI.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "PV" + DefendingUnit.GetComponentInChildren<TextMesh>().text;

        BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().maxValue = DefendingUnit.GetComponent<TileStatistics>().baseHealth;
        BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().minValue = 0;
        BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value = float.Parse(DefendingUnit.GetComponentInChildren<TextMesh>().text);


        BattleUI.transform.GetChild(4).GetChild(3).GetComponent<Text>().text = DefendingUnit.name;

        AnimationTime = 2;

    }



    public void Update()
    {
        if(AnimationTime > 0)
        {
            AnimationTime -= Time.deltaTime;



            BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value -= (float.Parse(DefendingUnit.GetComponentInChildren<TextMesh>().text) * Time.fixedDeltaTime);

            BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value = Mathf.Floor(BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value * 10) / 10;
            
            if(BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value <= float.Parse(DefendingUnit.GetComponentInChildren<TextMesh>().text))
            {
                BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value = float.Parse(DefendingUnit.GetComponentInChildren<TextMesh>().text);
            }

            BattleUI.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = $"PV : {BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value}";




            BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value -= (float.Parse(AttackingUnit.GetComponentInChildren<TextMesh>().text) * Time.fixedDeltaTime);

            BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value = Mathf.Floor(BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value * 10) / 10;
            
            if (BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value <= float.Parse(AttackingUnit.GetComponentInChildren<TextMesh>().text))
            {
                BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value = float.Parse(AttackingUnit.GetComponentInChildren<TextMesh>().text);
            }

            BattleUI.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = $"PV : {BattleUI.transform.GetChild(3).GetChild(2).GetComponent<Slider>().value}";



            BattleUI.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = $"PV : {BattleUI.transform.GetChild(4).GetChild(2).GetComponent<Slider>().value}";

        }
        else
        {
            BattleUI.gameObject.SetActive(false);
        }
    }
}
