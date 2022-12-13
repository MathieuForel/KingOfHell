using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMovementTile : MonoBehaviour
{

    [SerializeField] public GameObject SmartMoveTile;

    [SerializeField] public GameObject SmartMoveTileInstantiated;

    [SerializeField] public GameObject NorthCollider;
    [SerializeField] public GameObject WestCollider;
    [SerializeField] public GameObject EastCollider;
    [SerializeField] public GameObject SouthCollider;


    [SerializeField] public GameObject ParentTile;

    [SerializeField] public bool N;
    [SerializeField] public bool W;
    [SerializeField] public bool E;
    [SerializeField] public bool S;

    [SerializeField] public float x;
    [SerializeField] public float y;
    [SerializeField] public float depth;



    void Start()
    {
        NorthCollider = this.gameObject.transform.GetChild(1).gameObject;
        WestCollider = this.gameObject.transform.GetChild(2).gameObject;
        EastCollider = this.gameObject.transform.GetChild(3).gameObject;
        SouthCollider = this.gameObject.transform.GetChild(4).gameObject;

        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;

        this.gameObject.name = $"SmartTile {x} {y} {depth}";


        NorthCollider.SetActive(true);
        WestCollider.SetActive(true);
        EastCollider.SetActive(true);
        SouthCollider.SetActive(true);

        if (N)
        {
            NorthCollider.SetActive(false);
        }
        if (W)
        {
            WestCollider.SetActive(false);
        }
        if (E)
        {
            EastCollider.SetActive(false);
        }
        if (S)
        {
            SouthCollider.SetActive(false);
        }

        if (depth == 0)
        {
            NorthCollider.SetActive(false);
            WestCollider.SetActive(false);
            EastCollider.SetActive(false);
            SouthCollider.SetActive(false);
        }

        if(depth < 0)
        {
            this.gameObject.SetActive(false);
        }



    }

    public void SpreadNorth()
    {
        if (depth > 0)
        {
            SmartMoveTileInstantiated = Instantiate(SmartMoveTile, NorthCollider.transform.position, Quaternion.identity, this.gameObject.transform.parent);
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().ParentTile = this.gameObject;
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().S = true;
            NorthCollider.gameObject.SetActive(false);

            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;


            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isTALD || this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isT)
            {
                if (NorthCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }

                if (NorthCollider.GetComponent<MoveTileBehaviour>().Water)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 2;
                }
            }

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isCAC)
            {
                if (NorthCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }
            }
        }
    }

    public void SpreadWest()
    {
        if (depth > 0)
        {
            SmartMoveTileInstantiated = Instantiate(SmartMoveTile, WestCollider.transform.position, Quaternion.identity, this.gameObject.transform.parent);
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().ParentTile = this.gameObject;
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().E = true;
            WestCollider.gameObject.SetActive(false);

            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isTALD || this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isT)
            {
                if (WestCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }

                if (WestCollider.GetComponent<MoveTileBehaviour>().Water)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 2;
                }
            }

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isCAC)
            {
                if (WestCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }
            }
        }
    }

    public void SpreadEast()
    {
        if (depth > 0)
        {
            SmartMoveTileInstantiated = Instantiate(SmartMoveTile, EastCollider.transform.position, Quaternion.identity, this.gameObject.transform.parent);
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().ParentTile = this.gameObject;
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().W = true;
            EastCollider.gameObject.SetActive(false);

            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;


            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isTALD || this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isT)
            {
                if (EastCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }

                if (EastCollider.GetComponent<MoveTileBehaviour>().Water)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 2;
                }
            }

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isCAC)
            {
                if (EastCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }
            }
        }
    }

    public void SpreadSouth()
    {
        if (depth > 0)
        {
            SmartMoveTileInstantiated = Instantiate(SmartMoveTile, SouthCollider.transform.position, Quaternion.identity, this.gameObject.transform.parent);
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().ParentTile = this.gameObject;
            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().N = true;
            SouthCollider.gameObject.SetActive(false);

            SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isTALD || this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isT)
            {
                if (SouthCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }

                if (SouthCollider.GetComponent<MoveTileBehaviour>().Water)
                {
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 2;
                }
            }

            if (this.gameObject.transform.parent.transform.parent.GetComponent<TileState>().isCAC)
            {
                if (SouthCollider.GetComponent<MoveTileBehaviour>().Mountain)
                {
                    Debug.Log("is cac south");
                    SmartMoveTileInstantiated.GetComponent<SmartMovementTile>().depth = depth - 1;
                }
            }
        }
    }

}
