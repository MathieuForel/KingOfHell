using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTileBehaviour : MonoBehaviour
{

    [SerializeField] public GameObject ActionTouched;
    [SerializeField] public GameObject UnitTouched;
    [SerializeField] public GameObject StructureTouched;
    [SerializeField] public GameObject TerrainTouched;

    [SerializeField] public bool N;
    [SerializeField] public bool W;
    [SerializeField] public bool E;
    [SerializeField] public bool S;

    [SerializeField] public bool Mountain;
    [SerializeField] public bool Water;
    public void Start()
    {
        Collider[] ColliderTouched = Physics.OverlapBox(this.gameObject.transform.position, this.gameObject.transform.localScale / 2);


        for(int i = 0; i < ColliderTouched.Length; i++)
        {
            if (ColliderTouched[i].gameObject.transform.parent.gameObject != this.gameObject.transform.parent.gameObject)
            {
                if (ColliderTouched[i].gameObject.transform.parent.gameObject.layer == 13)
                {
                    ActionTouched = ColliderTouched[i].gameObject.transform.parent.gameObject;

                    try
                    {
                        if (ColliderTouched[i].gameObject.transform.parent.GetComponent<SmartMovementTile>().depth > gameObject.transform.parent.GetComponent<SmartMovementTile>().depth)
                        {
                            this.gameObject.SetActive(false);
                        }

                        if (ColliderTouched[i].gameObject.transform.parent.GetComponent<SmartMovementTile>().depth < gameObject.transform.parent.GetComponent<SmartMovementTile>().depth)
                        {
                            ColliderTouched[i].gameObject.SetActive(false);
                            this.gameObject.SetActive(true);
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }

                }

                if (ColliderTouched[i].gameObject.transform.parent.gameObject.layer == 12)
                {
                    UnitTouched = ColliderTouched[i].gameObject.transform.parent.gameObject;

                }

                if (ColliderTouched[i].gameObject.transform.parent.gameObject.layer == 11)
                {
                    StructureTouched = ColliderTouched[i].gameObject.transform.parent.gameObject;
                }

                if (ColliderTouched[i].gameObject.transform.parent.gameObject.layer == 10)
                {
                    TerrainTouched = ColliderTouched[i].gameObject.transform.parent.gameObject;

                    Mountain = false;
                    Water = false;

                    if (TerrainTouched.GetComponent<TileState>().isMountain)
                    {
                        Mountain = true;
                    }

                    if (TerrainTouched.GetComponent<TileState>().isBigMountain)
                    {
                        this.gameObject.SetActive(false);
                    }

                    if (TerrainTouched.GetComponent<TileState>().isWater)
                    {
                        Water = true;
                    }

                    if (TerrainTouched.GetComponent<TileState>().isOcean)
                    {
                        Debug.Log("touched ocean");
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (N == true && this.gameObject.activeInHierarchy)
        {
            this.gameObject.GetComponentInParent<SmartMovementTile>().SpreadNorth();
        }
        if (W == true && this.gameObject.activeInHierarchy)
        {
            this.gameObject.GetComponentInParent<SmartMovementTile>().SpreadWest();
        }
        if (E == true && this.gameObject.activeInHierarchy)
        {
            this.gameObject.GetComponentInParent<SmartMovementTile>().SpreadEast();
        }
        if (S == true && this.gameObject.activeInHierarchy)
        {
            this.gameObject.GetComponentInParent<SmartMovementTile>().SpreadSouth();
        }
    }
}
