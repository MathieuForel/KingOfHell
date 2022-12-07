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

    [SerializeField] public bool ActionMode;

    public void TypeHit()
    {

        if (CameraRayCast.TargetHit.layer == 13) //Action
        {
            ActionHit();
        }

        if (CameraRayCast.TargetHit.layer == 12) //Unit
        {
            UnitHit();
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode)
        {
            Debug.Log("f");
            ActionMode = false;
            CameraRayCast.CanSelect = false;

            SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);


            Debug.Log(SelectedUnit.name);

            ActionMenu.gameObject.SetActive(true);
        }
        /*
        if (CameraRayCast.TargetHit.layer == 11) //Structure
        {
            StructureHit();
        }

        if (CameraRayCast.TargetHit.layer == 10) //Terrain
        {
            TerrainHit();
        }
        */
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
            CameraRayCast.CanSelect = false;
            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            ActionMenu.gameObject.SetActive(true);
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {
            Debug.Log("ATTACKING");
            //CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isAttack = false;
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);

            CameraRayCast.CanSelect = false;
            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            this.gameObject.GetComponent<CameraRayCast>().Update();

            TypeHit();
        }
        /*
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isRefuel)
        {

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isVision)
        {

        }*/
    }

    public void UnitHit()
    {
        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {
            Debug.Log("MENU MENU MENU");

            CameraRayCast.CanSelect = false;
            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            ActionMenu.gameObject.SetActive(true);
        }

        //MOVEMENT
        if (ActionMode == false && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn) 
        {
            Debug.Log("unit");
            CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell != HellTurn)
        {
            Debug.Log("PLAY ATTACK ANIMATION HERE GGGGG");
            ActionMode = false;

        }

        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
        {
            Debug.Log("NO TEAM KILL");
            //ActionMode = false;
        }









        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().AttackAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().RefuelAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().VisionAction();
        /*
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isCAC)
        {
            Debug.Log("cac");

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isTALD)
        {
            Debug.Log("tal");

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isT)
        {
            Debug.Log("ttttt");

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isS)
        {
            Debug.Log("sssssoiiii");

        }*/
    }
    /*
    public void StructureHit()
    {
        Debug.Log("Struct");
    }
    public void TerrainHit()
    {
        Debug.Log("Terrain");
    }
    */


    //                         ------------------------------------------------ATTACK-------------------------------------------------
    public void AttackHit()
    {
        Debug.Log("hit option");

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
}
