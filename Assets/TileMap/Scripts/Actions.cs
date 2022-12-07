using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Actions : MonoBehaviour
{
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

        if (CameraRayCast.TargetHit.layer == 11) //Structure
        {
            StructureHit();
        }

        if (CameraRayCast.TargetHit.layer == 10) //Terrain
        {
            TerrainHit();
        }

    }

    public void ActionHit()
    {
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isMove)
        {

            Debug.Log("MOVING");
            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position = new Vector3(CameraRayCast.TargetHit.gameObject.transform.position.x, CameraRayCast.TargetHit.gameObject.transform.position.y, CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position.z);
            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isMove = false;
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            CameraRayCast.CanSelect = false;
            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

        }

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {

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
        if(ActionMode == false) 
        {
            Debug.Log("unit");
            CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
        }    

 

        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().AttackAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().RefuelAction();
        //CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().VisionAction();

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

        }
    }

    public void StructureHit()
    {
        Debug.Log("Struct");
    }
    public void TerrainHit()
    {
        Debug.Log("Terrain");
    }

    public void AttackHit()
    {
        Debug.Log("hit option");
        //CameraRayCast.TargetHit = CameraRayCast.selectedGameObject;
        CameraRayCast.CanSelect = true;
        CameraRayCast.selectedGameObject.gameObject.GetComponentInParent<UnitDisplay>().AttackAction();
        ActionMode = true;

        Debug.Log(CameraRayCast.CanSelect);
    }
}
