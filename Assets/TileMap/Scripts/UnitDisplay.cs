using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDisplay : MonoBehaviour
{

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
        /*if(this.gameObject.GetComponent<TileState>().isMove == false)
        {*/
            this.gameObject.GetComponent<TileState>().isMove = true;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //}
    }

    public void AttackAction()
    {
        Debug.Log("Attack Action worked");
        this.gameObject.GetComponent<TileState>().isAttack = true;
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void RefuelAction()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void VisionAction()
    {
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
}
