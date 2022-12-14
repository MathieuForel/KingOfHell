using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCheck : MonoBehaviour
{
    [SerializeField] public bool CAC;
    [SerializeField] public bool TALD;
    [SerializeField] public bool T;
    [SerializeField] public bool S;

    [Header("Terrain")]
    [Space(15)]

    [SerializeField] public float bonusAttack;
    [SerializeField] public float bonusDefence;
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

    [SerializeField] public int defencePoints;

    [SerializeField] public GameObject structureGameObject;


    public void Start()
    {
        if (this.gameObject.GetComponentInParent<TileState>().isCAC)
        {
            CAC= true;
        }
        if (this.gameObject.GetComponentInParent<TileState>().isTALD)
        {
            TALD= true;
        }
        if (this.gameObject.GetComponentInParent<TileState>().isT)
        {
            T = true;
        }
        if (this.gameObject.GetComponentInParent<TileState>().isS)
        {
            S = true;
        }
    }
    
    public void FixedUpdate()
    {
        this.gameObject.GetComponentInParent<TileStatistics>().attack = this.gameObject.GetComponentInParent<TileStatistics>().baseAttack + bonusAttack - handicapAttack + this.gameObject.GetComponentInParent<TileStatistics>().bonusAttack;
        this.gameObject.GetComponentInParent<TileStatistics>().defence = this.gameObject.GetComponentInParent<TileStatistics>().baseDefence + bonusDefence - handicapDefence + defencePoints + this.gameObject.GetComponentInParent<TileStatistics>().bonusDefence;
        this.gameObject.GetComponentInParent<TileStatistics>().vision = this.gameObject.GetComponentInParent<TileStatistics>().baseVision + bonusVision - handicapVision + this.gameObject.GetComponentInParent<TileStatistics>().bonusVision;
        this.gameObject.GetComponentInParent<TileStatistics>().movement = this.gameObject.GetComponentInParent<TileStatistics>().baseMovement + bonusMovementRange - handicapMovementRange + this.gameObject.GetComponentInParent<TileStatistics>().bonusMovementRange;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //--------------------------------------------------------LAYER-TERRAIN-----------------------------------------------------



        if (collision.gameObject.layer == 10)
        {

            bonusAttack = 0;
            bonusDefence = 0;
            bonusMovementRange = 0;
            bonusVision = 0;

            handicapAttack = 0;
            handicapDefence = 0;
            handicapMovementRange = 0;
            handicapVision = 0;

            //--------------------------------------------CAC-------------------------------------------------------

            if (CAC)
            {
                if (collision.transform.GetComponentInParent<TileState>().isStrongVsCAC)
                {
                    bonusAttack = collision.transform.GetComponentInParent<TileStatistics>().bonusAttack;
                    bonusDefence = collision.transform.GetComponentInParent<TileStatistics>().bonusDefence;
                    bonusMovementRange = collision.transform.GetComponentInParent<TileStatistics>().bonusMovementRange;
                    bonusVision = collision.transform.GetComponentInParent<TileStatistics>().bonusVision;
                }

                //---------Handicaps----------

                if (collision.transform.GetComponentInParent<TileState>().isWeakVsCAC)
                {
                    handicapAttack = collision.transform.GetComponentInParent<TileStatistics>().handicapAttack;
                    handicapDefence = collision.transform.GetComponentInParent<TileStatistics>().handicapDefence;
                    handicapMovementRange = collision.transform.GetComponentInParent<TileStatistics>().handicapMovementRange;
                    handicapVision = collision.transform.GetComponentInParent<TileStatistics>().handicapVision;
                }
            }

            //--------------------------------------------TALD-------------------------------------------------------

            if (TALD)
            {
                if (collision.transform.GetComponentInParent<TileState>().isStrongVsTALD)
                {
                    bonusAttack = collision.transform.GetComponentInParent<TileStatistics>().bonusAttack;
                    bonusDefence = collision.transform.GetComponentInParent<TileStatistics>().bonusDefence;
                    bonusMovementRange = collision.transform.GetComponentInParent<TileStatistics>().bonusMovementRange;
                    bonusVision = collision.transform.GetComponentInParent<TileStatistics>().bonusVision;
                }

                //---------Handicaps----------

                if (collision.transform.GetComponentInParent<TileState>().isWeakVsTALD)
                {
                    handicapAttack = collision.transform.GetComponentInParent<TileStatistics>().handicapAttack;
                    handicapDefence = collision.transform.GetComponentInParent<TileStatistics>().handicapDefence;
                    handicapMovementRange = collision.transform.GetComponentInParent<TileStatistics>().handicapMovementRange;
                    handicapVision = collision.transform.GetComponentInParent<TileStatistics>().handicapVision;
                }
            }

            //--------------------------------------------T-------------------------------------------------------

            if (T)
            {
                if (collision.transform.GetComponentInParent<TileState>().isStrongVsT)
                {
                    bonusAttack = collision.transform.GetComponentInParent<TileStatistics>().bonusAttack;
                    bonusDefence = collision.transform.GetComponentInParent<TileStatistics>().bonusDefence;
                    bonusMovementRange = collision.transform.GetComponentInParent<TileStatistics>().bonusMovementRange;
                    bonusVision = collision.transform.GetComponentInParent<TileStatistics>().bonusVision;
                }

                //---------Handicaps----------

                if (collision.transform.GetComponentInParent<TileState>().isWeakVsT)
                {
                    handicapAttack = collision.transform.GetComponentInParent<TileStatistics>().handicapAttack;
                    handicapDefence = collision.transform.GetComponentInParent<TileStatistics>().handicapDefence;
                    handicapMovementRange = collision.transform.GetComponentInParent<TileStatistics>().handicapMovementRange;
                    handicapVision = collision.transform.GetComponentInParent<TileStatistics>().handicapVision;
                }
            }

            //--------------------------------------------S-------------------------------------------------------

            if (S)
            {
                if (collision.transform.GetComponentInParent<TileState>().isStrongVsS)
                {
                    bonusAttack = collision.transform.GetComponentInParent<TileStatistics>().bonusAttack;
                    bonusDefence = collision.transform.GetComponentInParent<TileStatistics>().bonusDefence;
                    bonusMovementRange = collision.transform.GetComponentInParent<TileStatistics>().bonusMovementRange;
                    bonusVision = collision.transform.GetComponentInParent<TileStatistics>().bonusVision;
                }

                //---------Handicaps----------

                if (collision.transform.GetComponentInParent<TileState>().isWeakVsS)
                {
                    handicapAttack = collision.transform.GetComponentInParent<TileStatistics>().handicapAttack;
                    handicapDefence = collision.transform.GetComponentInParent<TileStatistics>().handicapDefence;
                    handicapMovementRange = collision.transform.GetComponentInParent<TileStatistics>().handicapMovementRange;
                    handicapVision = collision.transform.GetComponentInParent<TileStatistics>().handicapVision;
                }
            }
        }

        //--------------------------------------------------------LAYER-STRUCTURE-----------------------------------------------------
        /* Debug.Log("-------------------------------------------------------");
         Debug.Log(this.gameObject.transform.parent.gameObject.name);
         Debug.Log(collision.gameObject.transform.parent.gameObject.name);*/



        if (collision.gameObject.layer == 11)
        {
            structureGameObject = collision.transform.parent.gameObject;
            defencePoints = collision.transform.GetComponentInParent<TileStatistics>().defencePoints;
            Debug.Log(structureGameObject.GetComponent<TileState>().teamHell);

            if (this.gameObject.GetComponentInParent<TileState>().teamHell == false && this.gameObject.GetComponentInParent<TileState>().teamHeaven == false /*&& this.gameObject.GetComponentInParent<TileState>().teamNeutral == false*/)
            {

                if (structureGameObject.GetComponent<TileState>().teamHell)
                {
                    this.gameObject.GetComponentInParent<TileState>().teamHell = true;
                }

                if (structureGameObject.GetComponent<TileState>().teamHeaven)
                {
                    this.gameObject.GetComponentInParent<TileState>().teamHeaven = true;
                }

                this.gameObject.GetComponentInParent<TileState>().TeamColorUpdate();

                this.gameObject.GetComponentInParent<TileStatistics>().turnsBeforeProduced = this.gameObject.GetComponentInParent<TileStatistics>().baseTurnsBeforeProduced;
            }


        }
        else
        {
            defencePoints = 0;
        }
        //if climat

        //--------------------------------------------------------CHECK-----------------------------------------------------
        this.gameObject.GetComponentInParent<TileStatistics>().attack = this.gameObject.GetComponentInParent<TileStatistics>().baseAttack + bonusAttack - handicapAttack;
        this.gameObject.GetComponentInParent<TileStatistics>().defence = this.gameObject.GetComponentInParent<TileStatistics>().baseDefence + bonusDefence - handicapDefence + defencePoints + this.gameObject.GetComponentInParent<TileStatistics>().bonusDefence;
        this.gameObject.GetComponentInParent<TileStatistics>().vision = this.gameObject.GetComponentInParent<TileStatistics>().baseVision + bonusVision - handicapVision;
        this.gameObject.GetComponentInParent<TileStatistics>().movement = this.gameObject.GetComponentInParent<TileStatistics>().baseMovement + bonusMovementRange - handicapMovementRange;

    }
}
