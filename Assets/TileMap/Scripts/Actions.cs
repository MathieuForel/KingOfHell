using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] public GameObject ActionMenu;

    [SerializeField] public GameObject SelectedUnit;

    [SerializeField] public GameObject PreviousUnit;

    [SerializeField] public bool HellTurn;

    [SerializeField] public bool ActionMode = false;

    [SerializeField] public bool IsAttacking = false;

    [SerializeField] public bool IsRefueling = false;

    public void TypeHit()
    {
        //                         ------------------------------------------------ATTACK & REFUEL-------------------------------------------------
        if (CameraRayCast.TargetHit.layer == 13 && IsAttacking == false && IsRefueling == false) //Action
        {
            Debug.Log("action Attack");
            ActionHit();
        }

        if (CameraRayCast.TargetHit.layer == 12) //Unit
        {
            Debug.Log("uni");
            UnitHit();
        }

        //                         ------------------------------------------------ATTACK & REFUEL-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 12 && (IsAttacking || IsRefueling))
        {
            Debug.Log("EPIC");
            IsAttacking = false;
            IsRefueling = false;
            CancelAction();
        }

        //                         ------------------------------------------------ACTION-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 13 && ActionMode)
        {
            Debug.Log("f");
            CancelAction();
        }

        //                         ------------------------------------------------MOVE-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 13 && SelectedUnit.GetComponentInParent<TileState>().isMove == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().isUnit == false)
        {
            Debug.Log("stopmove");
            SelectedUnit.transform.parent.GetChild(1).gameObject.SetActive(false);
        }

        if (CameraRayCast.TargetHit.layer == 11) //Structure
        {
            Debug.Log("L");
            StructureHit();
        }

        if (CameraRayCast.TargetHit.layer == 10) //Terrain
        {
            Debug.Log("epicL");
            TerrainHit();
        }



    }

    public void ActionHit()
    {


        // MOVEMENT
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isMove)
        {
            if(CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "CanMove" || CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isCAC)
            {
                Debug.Log("MOVING");
                CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position = new Vector3(CameraRayCast.TargetHit.gameObject.transform.position.x, CameraRayCast.TargetHit.gameObject.transform.position.y, CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position.z);
                CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isMove = false;
                CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);

                if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    CameraRayCast.CanSelect = false;
                    CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

                    if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "CanMove")
                    {
                        ActionMenu.gameObject.SetActive(true);
                    }

                    if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "HasMoved")
                    {
                        CameraRayCast.CanSelect = true;
                    }

                }
            }
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack && ActionMode)
        {
            Debug.Log("ATTACKING");

            CameraRayCast.CanSelect = false;
            IsAttacking = true;
            ActionMode = true;

            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isAttack = false;
            //CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);


            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
            {
                SelectedUnit = CameraRayCast.selectedGameObject;
            }

            PreviousUnit = SelectedUnit;

            CameraRayCast.CanSelect = true;
            this.gameObject.GetComponent<CameraRayCast>().Update();
            CameraRayCast.CanSelect = false;

            SelectedUnit = PreviousUnit;
            CameraRayCast.selectedGameObject = PreviousUnit;

            Debug.Log(CameraRayCast.TargetHit.name);
            Debug.Log(CameraRayCast.TargetHit.layer);
            IsAttacking = true;
            ActionMode = true;
            TypeHit();
        }

        //                         ------------------------------------------------REFUEL-------------------------------------------------

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isRefuel && ActionMode)
        {
            Debug.Log("REFUELING");

            CameraRayCast.CanSelect = false;
            IsRefueling = true;
            ActionMode = true;

            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isRefuel = false;
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            SelectedUnit.transform.GetChild(3).gameObject.SetActive(false);


            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
            {
                SelectedUnit = CameraRayCast.selectedGameObject;
            }

            PreviousUnit = SelectedUnit;

            CameraRayCast.CanSelect = true;
            this.gameObject.GetComponent<CameraRayCast>().Update();
            CameraRayCast.CanSelect = false;

            SelectedUnit = PreviousUnit;
            CameraRayCast.selectedGameObject = PreviousUnit;

            Debug.Log(CameraRayCast.TargetHit.name);
            Debug.Log(CameraRayCast.TargetHit.layer);
            IsRefueling = true;
            ActionMode = true;
            TypeHit();
        }

        /*
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isVision)
        {

        }*/
    }

    public void UnitHit()
    {
        //                         ------------------------------------------------ATTACK-------------------------------------------------
        /*if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {
            CancelAction();
        }*//*
        Debug.Log("PGGGG");
        Debug.Log(ActionMode);
        Debug.Log(IsAttacking);
        Debug.Log(CameraRayCast.TargetHit.trandform.parent.name);
        Debug.Log(HellTurn);*/
        Debug.Log(CameraRayCast.TargetHit.transform.parent.name);
        if (ActionMode == true && IsAttacking == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
        {
            Debug.Log("Teaming :(");
            CameraRayCast.TargetHit.transform.GetChild(1).gameObject.SetActive(false);
            IsAttacking = false;
            CancelAction();
        }

        if (ActionMode == true && IsRefueling == true && CameraRayCast.TargetHit.transform.parent.GetComponent<TileState>().teamHell != HellTurn)
        {
            Debug.Log("Ani-Teaming :(");
            CameraRayCast.TargetHit.transform.GetChild(1).gameObject.SetActive(false);
            IsRefueling = false;
            CancelAction();
        }


        //                         ------------------------------------------------MOVE-------------------------------------------------
        if (SelectedUnit != null)
        {
            if (SelectedUnit.GetComponentInParent<TileState>().isMove)
            {
                Debug.Log("stopUNITmove");
                SelectedUnit.transform.parent.GetChild(1).gameObject.SetActive(false);
                CameraRayCast.TargetHit.transform.parent.gameObject.SetActive(true);
                CameraRayCast.CanSelect = true;
            }
        }

        if (ActionMode == false && IsAttacking == false && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn && CameraRayCast.TargetHit.transform.parent.tag == "CanMove") 
        {
            Debug.Log("unit");
            CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
            SelectedUnit = CameraRayCast.selectedGameObject;
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && IsAttacking == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHeaven == HellTurn)
        {
            Debug.Log("PLAY ATTACK ANIMATION HERE GGGGG");
            ActionMode = false;
            IsAttacking = false;
            CameraRayCast.CanSelect = true;

            SelectedUnit.tag = "HasMoved";
            SelectedUnit.GetComponentInParent<TileStatistics>().mana -= 1; // contre attaque :(

            if (SelectedUnit.GetComponentInParent<TileState>().isCAC)
            {
                Debug.Log("CACMOVE");
                SelectedUnit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
            }
        }

        //                         ------------------------------------------------REFUEL-------------------------------------------------

        if (ActionMode == true && IsRefueling == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
        {
            Debug.Log("Teaming REFUELING :D (cool!)");
            ActionMode = false;
            IsRefueling = false;
            CameraRayCast.CanSelect = true;

            CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().stamina += 10;

            CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().mana = CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().baseMana;

            if (SelectedUnit.GetComponentInParent<TileState>().isT)
            {
                CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().bonusDefence = 3;
            }

            if (SelectedUnit.GetComponentInParent<TileState>().isS)
            {
                CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().health += 2;

                if (SelectedUnit.GetComponentInParent<TileStatistics>().mana > 0)
                {
                    SelectedUnit.GetComponentInParent<TileStatistics>().mana -= 1;
                    CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().health += 2;
                }
            }
        }


        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && IsAttacking == true && (CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn || CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamNeutral))
        {
            Debug.Log("rip");
            IsAttacking = false;
            CancelAction();
        }

        //                         ------------------------------------------------REFUEL-------------------------------------------------
        if (ActionMode == true && IsRefueling == true && (CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHeaven == HellTurn || CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamNeutral))
        {
            Debug.Log("rip");
            IsRefueling = false;
            CancelAction();
        }
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().AttackAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().RefuelAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().VisionAction();



    }
    
    public void StructureHit()
    {
        Debug.Log("Struct");
    }
    public void TerrainHit()
    {
        Debug.Log("Terrain");
    }
    


    //                         ------------------------------------------------ATTACK-------------------------------------------------
    public void AttackHit()
    {
        Debug.Log("-------------------------hit ATTACK option");

        //CameraRayCast.TargetHit = CameraRayCast.selectedGameObject;
        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit = CameraRayCast.selectedGameObject;
        }


        Debug.Log(SelectedUnit.name);

        CameraRayCast.CanSelect = true;
        SelectedUnit.gameObject.GetComponentInParent<UnitDisplay>().AttackAction();
        ActionMode = true;

        Debug.Log(CameraRayCast.CanSelect);

        ActionMenu.gameObject.SetActive(false);
    }

    public void RefuelHit()
    {
        Debug.Log("-------------------------hit REFUEL option");

        //CameraRayCast.TargetHit = CameraRayCast.selectedGameObject;
        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit = CameraRayCast.selectedGameObject;
        }


        Debug.Log(SelectedUnit.name);

        CameraRayCast.CanSelect = true;
        SelectedUnit.gameObject.GetComponentInParent<UnitDisplay>().RefuelAction();
        ActionMode = true;

        Debug.Log(CameraRayCast.CanSelect);

        ActionMenu.gameObject.SetActive(false);
    }

    public void CancelAction()
    {
        Debug.Log("-------------------------cancel action");
        ActionMode = false;
        CameraRayCast.CanSelect = false;

        SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);
        SelectedUnit.transform.GetChild(3).gameObject.SetActive(false);

        Debug.Log(SelectedUnit.name);

        ActionMenu.gameObject.SetActive(true);
    }

    public void Wait()
    {
        Debug.Log("-------------------------Wait");
        ActionMode = false;
        IsAttacking = false;
        IsRefueling = false;
        CameraRayCast.CanSelect = true;

        ActionMenu.gameObject.SetActive(false);

        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit = CameraRayCast.selectedGameObject;
        }

        if (SelectedUnit.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit.tag = "HasMoved";
        }
        else
        {
            CameraRayCast.selectedGameObject.tag = "HasMoved";
        }
    }
}
