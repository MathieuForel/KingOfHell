using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject MenuPause;

    [SerializeField] private GameObject Units;

    [SerializeField] private GameObject Structure;

    [SerializeField] private GameObject FogGenerator;

    [SerializeField] public int HellFunds;

    [SerializeField] public int HeavenFunds;

    [SerializeField] public int HellCOPowerDuration;

    [SerializeField] public int HeavenCOPowerDuration;


    [SerializeField] public int i = 0;


    [SerializeField] private GameObject VictoryScreens;
    [SerializeField] public bool HellHQUp;
    [SerializeField] public bool HeavenHQUp;

    public void Start()
    {
        Units = GameObject.Find("Units");
        EndTurn();
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
            Units.transform.GetChild(i).GetChild(4).gameObject.SetActive(false);
        }

        for (i = 0; i < Structure.transform.childCount; i++)
        {
            Structure.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
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
                    Units.transform.GetChild(i).GetChild(4).gameObject.SetActive(true);

                    Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusDefence = 0;

                    if (Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced > 0)
                    {
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced -= 1;
                    }

                    if(HellCOPowerDuration > 0)
                    {
                        HellCOPowerDuration -= 1;

                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusMovementRange = 1;
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusAttack = 2.5f;
                    }

                    //-------------------------------------------------------STRUCTURE------------------------------------------------
                    try
                    {
                        if (Units.transform.GetChild(i).gameObject.transform.position.x == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.x &&
                            Units.transform.GetChild(i).gameObject.transform.position.y == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.y)
                        {
                            if (Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHell &&
                                Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHeaven &&
                                Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamNeutral == false)
                            {
                                Debug.Log("ON A STRUCTURE REGENERATING");
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().health += 2;
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().stamina += 20;
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().mana = Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().baseMana;
                            }
                        }
                    }
                    catch (UnassignedReferenceException)
                    {

                    }
                }
            }

            if (Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == false)
                {
                    Units.transform.GetChild(i).gameObject.tag = "CanMove";
                    Units.transform.GetChild(i).GetChild(4).gameObject.SetActive(true);

                    Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusDefence = 0;

                    if (Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced > 0)
                    {
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().turnsBeforeProduced -= 1;
                    }


                    if (HeavenCOPowerDuration > 0)
                    {
                        HeavenCOPowerDuration -= 1;

                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusMovementRange = 1;
                        Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().bonusAttack = 2.5f;
                    }

                    //-------------------------------------------------------STRUCTURE------------------------------------------------
                    try
                    {
                        if (Units.transform.GetChild(i).gameObject.transform.position.x == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.x &&
                            Units.transform.GetChild(i).gameObject.transform.position.y == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.y)
                        {
                            if (Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHell &&
                                Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven == Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHeaven &&
                                Units.transform.GetChild(i).gameObject.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamNeutral == false)
                            {
                                Debug.Log("ON A STRUCTURE REGENERATING");
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().health += 2;
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().stamina += 20;
                                Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().mana = Units.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().baseMana;
                            }
                        }
                    }
                    catch (UnassignedReferenceException)
                    {

                    }
                }
            }
        }

        //-----------------------------------------------------Structure CHECK-----------------------------------------------------

        HellHQUp = false;
        HeavenHQUp = false;

        for (i = 0; i < Structure.transform.childCount; i++)
        {
            if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == true)
                {
                    HellFunds += Structure.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().fundPerTurn;
                    Structure.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }

                if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().isHQ)
                {
                    Debug.Log(Structure.transform.GetChild(i).gameObject);
                    HellHQUp = true;
                }
            }

            if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven)
            {
                if (this.gameObject.GetComponent<Actions>().HellTurn == false)
                {
                    HeavenFunds += Structure.transform.GetChild(i).gameObject.GetComponent<TileStatistics>().fundPerTurn;
                    Structure.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }

                if (Structure.transform.GetChild(i).gameObject.GetComponent<TileState>().isHQ)
                {
                    Debug.Log(Structure.transform.GetChild(i).gameObject);
                    HeavenHQUp = true;
                }
            }
        }

        if(HellHQUp == false)
        {
            CameraRayCast.CanSelect = false;
            VictoryScreens.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (HeavenHQUp == false)
        {
            CameraRayCast.CanSelect = false;
            VictoryScreens.transform.GetChild(0).gameObject.SetActive(true);
        }

        Cancel();

        FogGenerator.gameObject.SetActive(false);
        FogGenerator.GetComponent<FogOfWarGenerator>().GridGenerator();
        FogGenerator.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        MenuPause.SetActive(false);
        CameraRayCast.CanSelect = true;
    }

    public void PowerActivation()
    {

        Debug.Log("Clicked power button");

        if(this.gameObject.GetComponent<Actions>().HellTurn == true)
        {
            HellCOPowerDuration = 2;
            this.gameObject.GetComponent<BattleCalculator>().COPowerHell = 0;
        }
        if (this.gameObject.GetComponent<Actions>().HellTurn == false)
        {
            HeavenCOPowerDuration = 2;
            this.gameObject.GetComponent<BattleCalculator>().COPowerHeaven = 0;
        }
    }
}
