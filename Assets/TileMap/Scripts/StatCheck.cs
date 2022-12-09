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

    [SerializeField] public int defencePoints;




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
    /*
    public void FixedUpdate()
    {
        this.gameObject.GetComponentInParent<TileStatistics>().attack = this.gameObject.GetComponentInParent<TileStatistics>().baseAttack + bonusAttack - handicapAttack;
        this.gameObject.GetComponentInParent<TileStatistics>().defence = this.gameObject.GetComponentInParent<TileStatistics>().baseDefence + bonusDefence - handicapDefence + defencePoints + this.gameObject.GetComponentInParent<TileStatistics>().bonusDefence;
        this.gameObject.GetComponentInParent<TileStatistics>().vision = this.gameObject.GetComponentInParent<TileStatistics>().baseVision + bonusVision - handicapVision;
        this.gameObject.GetComponentInParent<TileStatistics>().movement = this.gameObject.GetComponentInParent<TileStatistics>().baseMovement + bonusMovementRange - handicapMovementRange;
    }*/

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
            defencePoints = collision.transform.GetComponentInParent<TileStatistics>().defencePoints;
        }
        else
        {
            defencePoints= 0;
        }
        //if climat

        //--------------------------------------------------------CHECK-----------------------------------------------------
        this.gameObject.GetComponentInParent<TileStatistics>().attack = this.gameObject.GetComponentInParent<TileStatistics>().baseAttack + bonusAttack - handicapAttack;
        this.gameObject.GetComponentInParent<TileStatistics>().defence = this.gameObject.GetComponentInParent<TileStatistics>().baseDefence + bonusDefence - handicapDefence + defencePoints + this.gameObject.GetComponentInParent<TileStatistics>().bonusDefence;
        this.gameObject.GetComponentInParent<TileStatistics>().vision = this.gameObject.GetComponentInParent<TileStatistics>().baseVision + bonusVision - handicapVision;
        this.gameObject.GetComponentInParent<TileStatistics>().movement = this.gameObject.GetComponentInParent<TileStatistics>().baseMovement + bonusMovementRange - handicapMovementRange;

    }
}
