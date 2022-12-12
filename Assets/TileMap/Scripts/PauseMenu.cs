using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject MenuPause;

    [SerializeField] private GameObject Units;

    [SerializeField] private GameObject Structure;

    [SerializeField] public int HellFunds;

    [SerializeField] public int HeavenFunds;


    [SerializeField] public int i = 0;

    public void Start()
    {
        Units = GameObject.Find("Units");
    }

    public void Activate()
    {
        MenuPause.SetActive(true);
        CameraRayCast.CanSelect = false;
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void EndTurn()
    {

        for (i = 0; i < Units.transform.childCount; i++)
        {
            Units.transform.GetChild(i).gameObject.tag = "HasMoved";
        }

        if (this.gameObject.GetComponent<Actions>().HellTurn)
        {
            this.gameObject.GetComponent<Actions>().HellTurn = false;
        }
        else
        {
            this.gameObject.GetComponent<Actions>().HellTurn = true;
        }


        //-----------------------------------------------------UNIT CHECK-----------------------------------------------------
        for (i = 0; i < Units.transform.childCount; i++)
        {
            if (Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == true)
                {
                    Units.transform.GetChild(i).gameObject.tag = "CanMove";

                    Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusDefence = 0;

                    if (Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced > 0)
                    {
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced -= 1;
                    }
                }
            }

            if (Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == false)
                {
                    Units.transform.GetChild(i).gameObject.tag = "CanMove";

                    Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusDefence = 0;

                    if (Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced > 0)
                    {
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced -= 1;
                    }


                }
            }
        }

        //-----------------------------------------------------Structure CHECK-----------------------------------------------------

        for (i = 0; i < Structure.transform.childCount; i++)
        {
            if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == true)
                {
                    HellFunds += Structure.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().fundPerTurn;
                }
            }

            if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == false)
                {
                    HeavenFunds += Structure.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().fundPerTurn;
                }
            }
        }

        Cancel();
    }

    public void Cancel()
    {
        MenuPause.SetActive(false);
        CameraRayCast.CanSelect = true;
    }
}
