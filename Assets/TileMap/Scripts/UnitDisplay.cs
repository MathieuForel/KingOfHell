using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDisplay : MonoBehaviour
{

    [SerializeField] public GameObject SmartMoveTile;

    [SerializeField] public GameObject SmartMoveTimeInstantiated;

    public void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
/*
        for (int i = 1; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }*/

    }

    public void MoveAction()
    {
        Debug.Log("Action worked");

        this.gameObject.GetComponent<TileState>().isMove = true;

        for(int i = 0; i < this.transform.GetChild(1).childCount; i++)
        {
            Destroy(this.gameObject.transform.GetChild(1).GetChild(i).gameObject);
        }

        SmartMoveTimeInstantiated = Instantiate(SmartMoveTile, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform.GetChild(1));
        SmartMoveTimeInstantiated.GetComponent<SmartMovementTile>().depth = this.gameObject.GetComponent<TileStatistics>().movement;
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);

    }

    public void AttackAction()
    {
        Debug.Log("Attack Action worked");
        this.gameObject.GetComponent<TileState>().isAttack = true;
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void RefuelAction()
    {
        Debug.Log("Refuel Action worked");
        this.gameObject.GetComponent<TileState>().isRefuel = true;
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void VisionAction()
    {
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
}
