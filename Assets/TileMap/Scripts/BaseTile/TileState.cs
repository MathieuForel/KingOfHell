using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileState : MonoBehaviour
{
    [Header("Team")]
    [Space(15)]

    [SerializeField] public bool teamHeaven;
    [SerializeField] public bool teamHell;
    [SerializeField] public bool teamNeutral;
    [Space(25)]


    [Header("Terrain")]
    [SerializeField] public bool isTerrain;
    [Space(15)]

    [SerializeField] public bool isPlains;
    [SerializeField] public bool isSand;
    [SerializeField] public bool isWater;
    [SerializeField] public bool isOcean;
    [SerializeField] public bool isMountain;
    [SerializeField] public bool isBigMountain;
    [SerializeField] public bool isMountainWithTunnel;
    [SerializeField] public bool isBigMountainWithTunnel;
    [SerializeField] public bool isForest;
    [SerializeField] public bool isHole;
    [SerializeField] public bool isRoad;
    [Space(25)]


    [Header("Structure")]
    [SerializeField] public bool isStructure;
    [Space(15)]

    [SerializeField] public bool isHQ;
    [SerializeField] public bool isCity;
    [SerializeField] public bool isFactory;
    [SerializeField] public bool isAirport;
    [Space(25)]


    [Header("Unit")]
    [SerializeField] public bool isUnit;
    [Space(15)]

    [SerializeField] public bool isCAC;
    [SerializeField] public bool isTALD;
    [SerializeField] public bool isT;
    [SerializeField] public bool isS;
    [Space(25)]


    [Header("RPC")]
    [Space(15)]

    [SerializeField] public bool isStrongVsCAC;
    [SerializeField] public bool isStrongVsTALD;
    [SerializeField] public bool isStrongVsT;
    [SerializeField] public bool isStrongVsS;
    [Space(15)]

    [SerializeField] public bool isWeakVsCAC;
    [SerializeField] public bool isWeakVsTALD;
    [SerializeField] public bool isWeakVsT;
    [SerializeField] public bool isWeakVsS;
    [Space(25)]


    [Header("Action")]
    [SerializeField] public bool isAction;
    [Space(15)]

    [SerializeField] public bool isFog;
    [SerializeField] public bool isVision;
    [SerializeField] public bool isMove;
    [SerializeField] public bool isAttack;
    [SerializeField] public bool isRefuel;

    public void Start()
    {

        this.gameObject.transform.position = new Vector3(Mathf.Floor(this.gameObject.transform.position.x + 0.5f), Mathf.Floor(this.gameObject.transform.position.y + 0.5f), Mathf.Floor(this.gameObject.transform.position.z + 0.5f));

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);

        if (isTerrain == true)
        {
            this.gameObject.transform.position += new Vector3(0, 0, 0);
            this.gameObject.layer = 10;
            this.gameObject.transform.GetChild(0).gameObject.layer = 10;
        }

        if (isStructure == true)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -0.1f);
            this.gameObject.layer = 11;
            this.gameObject.transform.GetChild(0).gameObject.layer = 11;
        }

        if (isUnit == true)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -2);
            this.gameObject.layer = 12;
            this.gameObject.transform.GetChild(0).gameObject.layer = 12;
        }

        if (isAction == true)
        {
            this.gameObject.layer = 13;
            this.gameObject.transform.position += new Vector3(0, 0, -3);
            this.gameObject.transform.GetChild(0).gameObject.layer = 13;
        }

        //--------------------------------------------


        if (isUnit && teamHell == GameObject.Find("MainCamera").GetComponent<Actions>().HellTurn)
        {
            this.gameObject.tag = "CanMove";
        }
        if (isUnit && teamHell != GameObject.Find("MainCamera").GetComponent<Actions>().HellTurn)
        {
            this.gameObject.tag = "HasMoved";
        }

        if (isUnit && teamHeaven != GameObject.Find("MainCamera").GetComponent<Actions>().HellTurn)
        {
            this.gameObject.tag = "CanMove";
        }
        if (isUnit && teamHeaven == GameObject.Find("MainCamera").GetComponent<Actions>().HellTurn)
        {
            this.gameObject.tag = "HasMoved";
        }
        TeamColorUpdate();
    }

    public void TeamColorUpdate()
    {
        if (isUnit || isStructure)
        {
            if (teamNeutral)
            {
                this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(111f / 255f, 111f / 255f, 111f / 255f);
            }


            if (teamHell)
            {
                this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 100f / 255f, 100f / 255f);
            }

            if (teamHeaven)
            {
                this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(100f / 255f, 255f / 255f, 100f / 255f);
            }
        }
    }
}
