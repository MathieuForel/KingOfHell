using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] public GameObject ActionMenu;

    [SerializeField] public GameObject SelectedUnit;

    [SerializeField] public bool HellTurn;

    [SerializeField] private bool ActionMode = false;

    [SerializeField] private bool IsAttacking = false;

    public void TypeHit()
    {

        if (CameraRayCast.TargetHit.layer == 13 && IsAttacking == false) //Action
        {
            Debug.Log("actio");
            ActionHit();
        }

        if (CameraRayCast.TargetHit.layer == 12) //Unit
        {
            Debug.Log("uni");
            UnitHit();
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 12 && IsAttacking)
        {
            Debug.Log("EPIC");
            IsAttacking = false;
            CancelAction();
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 13 && ActionMode)
        {
            Debug.Log("f");
            CancelAction();
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

            Debug.Log("MOVING");
            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position = new Vector3(CameraRayCast.TargetHit.gameObject.transform.position.x, CameraRayCast.TargetHit.gameObject.transform.position.y, CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position.z);
            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isMove = false;
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);

            if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                CameraRayCast.CanSelect = false;
                CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

                ActionMenu.gameObject.SetActive(true);
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
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);


            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
            {
                SelectedUnit = CameraRayCast.selectedGameObject;
            }

            CameraRayCast.CanSelect = true;
            this.gameObject.GetComponent<CameraRayCast>().Update();
            CameraRayCast.CanSelect = false;

            Debug.Log(CameraRayCast.TargetHit.name);
            Debug.Log(CameraRayCast.TargetHit.layer);
            IsAttacking = true;
            ActionMode = true;
            TypeHit();

        }
        
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isRefuel)
        {

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isVision)
        {

        }
    }

    public void UnitHit()
    {
        //                         ------------------------------------------------ATTACK-------------------------------------------------
        /*if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {
            CancelAction();
        }*/
        Debug.Log("PGGGG");
        Debug.Log(ActionMode);
        Debug.Log(IsAttacking);
        Debug.Log(CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHeaven);
        Debug.Log(HellTurn);

        if (ActionMode == true && IsAttacking == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
        {
            Debug.Log("Teaming :(");
            IsAttacking = false;
            CancelAction();
        }

        //MOVEMENT
        if (ActionMode == false && IsAttacking == false && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn) 
        {
            Debug.Log("unit");
            CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && IsAttacking == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHeaven == HellTurn)
        {
            Debug.Log("PLAY ATTACK ANIMATION HERE GGGGG");
            ActionMode = false;
            IsAttacking = false;
            CameraRayCast.CanSelect = true;

            SelectedUnit.transform.GetChild(0).gameObject.SetActive(false);

            if (SelectedUnit.GetComponentInParent<TileState>().isCAC)
            {
                SelectedUnit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
            }
        }

        if (ActionMode == true && IsAttacking == true && (CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn || CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamNeutral))
        {
            Debug.Log("rip");
            IsAttacking = false;
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
        Debug.Log("-------------------------hit option");

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

    public void CancelAction()
    {
        Debug.Log("-------------------------cancel action");
        ActionMode = false;
        CameraRayCast.CanSelect = false;

        SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);


        Debug.Log(SelectedUnit.name);

        ActionMenu.gameObject.SetActive(true);
    }
}
