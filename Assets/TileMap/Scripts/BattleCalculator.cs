using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalculator : MonoBehaviour
{
    [SerializeField] private GameObject AttackingUnit;

    [SerializeField] private GameObject DefendingUnit;

    [SerializeField] private float AttackPOWER;

    [SerializeField] private float DefencePOWER;

    [SerializeField] private float RPC;

    [SerializeField] private float Damage;

    public void StartBattle()
    {
        AttackingUnit = this.gameObject.GetComponent<Actions>().PreviousUnit;

        DefendingUnit = this.gameObject.GetComponent<Actions>().SelectedUnit;


        Attack();
    }

    public void Attack()
    {

        AttackPOWER = AttackingUnit.GetComponent<TileStatistics>().attack * (AttackingUnit.GetComponent<TileStatistics>().character / AttackingUnit.GetComponent<TileStatistics>().baseCharacter) + Random.Range(-0.1f, 0.1f);

        DefencePOWER = AttackingUnit.GetComponent<TileStatistics>().defence;

        RPCManagement();

        Damage = Mathf.FloorToInt((AttackPOWER * RPC - DefencePOWER) * 10) / 10;

        Debug.Log(Damage);

        DefendingUnit.GetComponent<TileStatistics>().health -= Damage/2;

        if (DefendingUnit.GetComponent<TileStatistics>().health <= 0)
        {
            DefendingUnit.SetActive(false);
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
        Debug.Log("you did it, you counter attacked what a move!");

        AttackPOWER = DefendingUnit.GetComponent<TileStatistics>().attack * (DefendingUnit.GetComponent<TileStatistics>().character / DefendingUnit.GetComponent<TileStatistics>().baseCharacter) + Random.Range(-0.1f, 0.1f);

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
    }
}
