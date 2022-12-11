using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] public GameObject ActionMenu;

    [SerializeField] public GameObject RecrutingMenu;

    [SerializeField] public GameObject SelectedUnit;

    [SerializeField] public GameObject PreviousUnit;

    [SerializeField] public bool HellTurn;

    [SerializeField] public bool ActionMode = false;

    [SerializeField] public bool IsAttacking = false;

    [SerializeField] public bool IsRefueling = false;

    [SerializeField] public bool IsCapturing = false;

    [SerializeField] public GameObject CAC;

    [SerializeField] public GameObject TALD;

    [SerializeField] public GameObject T;

    [SerializeField] public GameObject S;


    public void TypeHit()
    {
        Debug.Log("*******************************************");
        if (SelectedUnit == null)
        {

        }
        else
        {
            Debug.Log(SelectedUnit.name);
        }

        try
        {
            if (this.gameObject.transform.GetComponent<Actions>().SelectedUnit.transform.parent == null)
            {

            }
            else
            {
                Debug.Log(this.gameObject.transform.GetComponent<Actions>().SelectedUnit.transform.parent.name);
            }
        }
        catch (UnassignedReferenceException)
        {

        }


        //                         ------------------------------------------------ATTACK & REFUEL-------------------------------------------------
        if (CameraRayCast.TargetHit.layer == 13 && IsAttacking == false && IsRefueling == false) //Action
        {
            Debug.Log("action Attack");
            ActionHit();
        }

        if (CameraRayCast.TargetHit.layer == 12) //Unit
        {
            Debug.Log("uni");
            UnitHit();
        }

        //                         ------------------------------------------------ATTACK & REFUEL-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 12 && (IsAttacking || IsRefueling))
        {
            Debug.Log("EPIC");
            IsAttacking = false;
            IsRefueling = false;
            CancelAction();
        }

        //                         ------------------------------------------------ACTION-------------------------------------------------
        if (CameraRayCast.TargetHit.layer != 13 && ActionMode)
        {
            Debug.Log("f");
            CancelAction();
        }

        //                         ------------------------------------------------MOVE-------------------------------------------------
        if(SelectedUnit!= null)
        {
            if (CameraRayCast.TargetHit.layer != 13 && SelectedUnit.GetComponentInParent<TileState>().isMove == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().isUnit == false)
            {
                Debug.Log("stopmove");
                SelectedUnit.transform.parent.GetChild(1).gameObject.SetActive(false);

            }
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
            if(CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "CanMove" || CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isCAC)
            {
                Debug.Log("MOVING");
                CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position = new Vector3(CameraRayCast.TargetHit.gameObject.transform.position.x, CameraRayCast.TargetHit.gameObject.transform.position.y, CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.transform.position.z);
                CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isMove = false;
                CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);

                CameraRayCast.CanSelect = false;
                CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

                if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "CanMove")
                {
                    SelectedUnit = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.GetChild(0).gameObject;
                    Debug.Log(SelectedUnit.transform.parent);
                    ActionMenu.gameObject.SetActive(true);
                }

                if (CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.tag == "HasMoved")
                {
                    CameraRayCast.CanSelect = true;
                }

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
            //CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            SelectedUnit.transform.GetChild(2).gameObject.SetActive(false);


            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
            {
                SelectedUnit = CameraRayCast.selectedGameObject;
            }

            PreviousUnit = SelectedUnit;

            CameraRayCast.CanSelect = true;
            this.gameObject.GetComponent<CameraRayCast>().Update();
            //CameraRayCast.CanSelect = false;

            SelectedUnit = PreviousUnit;
            CameraRayCast.selectedGameObject = PreviousUnit;

            Debug.Log(CameraRayCast.TargetHit.transform.parent.name);
            Debug.Log(CameraRayCast.TargetHit.layer);
            IsAttacking = true;
            ActionMode = true;
            TypeHit();
        }

        //                         ------------------------------------------------REFUEL-------------------------------------------------

        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isRefuel && ActionMode)
        {
            Debug.Log("REFUELING");

            CameraRayCast.CanSelect = false;
            IsRefueling = true;
            ActionMode = true;

            CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<TileState>().isRefuel = false;
            CameraRayCast.TargetHit.transform.parent.transform.parent.gameObject.SetActive(false);
            SelectedUnit.transform.GetChild(3).gameObject.SetActive(false);


            CameraRayCast.selectedGameObject = CameraRayCast.TargetHit.transform.parent.transform.parent.transform.parent.gameObject;

            if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
            {
                SelectedUnit = CameraRayCast.selectedGameObject;
            }

            PreviousUnit = SelectedUnit;

            CameraRayCast.CanSelect = true;
            this.gameObject.GetComponent<CameraRayCast>().Update();
            CameraRayCast.CanSelect = false;

            SelectedUnit = PreviousUnit;
            CameraRayCast.selectedGameObject = PreviousUnit;

            Debug.Log(CameraRayCast.TargetHit.name);
            Debug.Log(CameraRayCast.TargetHit.layer);
            IsRefueling = true;
            ActionMode = true;
            TypeHit();
        }

        /*
        if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isVision)
        {

        }*/
    }

    public void UnitHit()
    {
        //                         ------------------------------------------------ATTACK-------------------------------------------------
        /*if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isAttack)
        {
            CancelAction();
        }*/

        //Debug.Log(CameraRayCast.TargetHit.transform.parent.name);
        if (ActionMode == true && IsAttacking == true && (CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn || CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamNeutral))
        {
            Debug.Log("Teaming :(");
            CameraRayCast.TargetHit.transform.GetChild(1).gameObject.SetActive(false);
            IsAttacking = false;
            CancelAction();
        }

        if (ActionMode == true && IsRefueling == true && CameraRayCast.TargetHit.transform.parent.GetComponent<TileState>().teamHell != HellTurn)
        {
            Debug.Log("Ani-Teaming :(");
            CameraRayCast.TargetHit.transform.GetChild(1).gameObject.SetActive(false);
            IsRefueling = false;
            CancelAction();
        }


        //                         ------------------------------------------------MOVE-------------------------------------------------
        if (SelectedUnit != null && IsRefueling == false)
        {
            if (SelectedUnit.GetComponentInParent<TileState>().tag == "HasMoved" && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
            {
                Debug.Log("DONT TOUTCH HIM");
                CameraRayCast.TargetHit.transform.parent.gameObject.SetActive(true);
                SelectedUnit.transform.parent.gameObject.SetActive(true);
            }
            else
            {

                if (SelectedUnit.GetComponentInParent<TileState>().isMove)
                {
                    Debug.Log("stopUNITmove");
                    SelectedUnit.transform.parent.GetChild(1).gameObject.SetActive(false);
                    CameraRayCast.TargetHit.transform.parent.gameObject.SetActive(true);
                    CameraRayCast.CanSelect = true;
                }
            }
        }




        if (ActionMode == false && IsAttacking == false && IsRefueling == false && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn && CameraRayCast.TargetHit.transform.parent.tag == "CanMove") 
        {
            Debug.Log("unit");
            CameraRayCast.TargetHit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
            SelectedUnit = CameraRayCast.selectedGameObject;
        }


        //                         ------------------------------------------------ATTACK-------------------------------------------------
        if (ActionMode == true && IsAttacking == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHeaven == HellTurn)
        {
            Debug.Log("PLAY ATTACK ANIMATION HERE GGGGG");
            ActionMode = false;
            IsAttacking = false;

            CameraRayCast.CanSelect = false;

            Debug.Log(CameraRayCast.TargetHit.transform.parent.gameObject);

            PreviousUnit = SelectedUnit;
            SelectedUnit = CameraRayCast.TargetHit.transform.parent.gameObject;

            this.gameObject.GetComponent<BattleCalculator>().StartBattle();

            SelectedUnit.transform.GetChild(2).gameObject.SetActive(true); // counter attack fffffffffffffffffffffffffffffffffffff

            Debug.Log(SelectedUnit.transform.transform.GetChild(2).childCount);

            for (int i = 0; i < SelectedUnit.transform.transform.GetChild(2).childCount; i++)
            {
                Debug.Log(SelectedUnit.transform.GetChild(2).GetChild(i).name);

                if (PreviousUnit.transform.position.x == SelectedUnit.transform.GetChild(2).GetChild(i).position.x &&
                   PreviousUnit.transform.position.y == SelectedUnit.transform.GetChild(2).GetChild(i).position.y)
                {
                    Debug.Log("COUNTER ATTACK");

                    SelectedUnit.GetComponent<TileStatistics>().FixedUpdate();
                    this.gameObject.GetComponent<BattleCalculator>().CounterAttack();

                }
            }

            SelectedUnit = PreviousUnit;

            CameraRayCast.TargetHit.transform.parent.GetChild(2).gameObject.SetActive(false);

            CameraRayCast.CanSelect = true;

            PreviousUnit.tag = "HasMoved";
            PreviousUnit.GetComponentInParent<TileStatistics>().mana -= 1; // contre attaque :(

            if (PreviousUnit.GetComponentInParent<TileState>().isCAC)
            {
                Debug.Log("CACMOVE");
                PreviousUnit.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
            }
        }

        //                         ------------------------------------------------REFUEL-------------------------------------------------

        if (ActionMode == true && IsRefueling == true && CameraRayCast.TargetHit.GetComponentInParent<TileState>().teamHell == HellTurn)
        {
            Debug.Log("Teaming REFUELING :D (cool!)");
            ActionMode = false;
            CameraRayCast.CanSelect = true;


            Debug.Log(CameraRayCast.TargetHit.transform.parent.name);

            CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().stamina += 10;

            CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().mana = CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().baseMana;

            if (SelectedUnit.GetComponentInParent<TileState>().isT)
            {
                CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().bonusDefence = 3;
            }

            if (SelectedUnit.GetComponentInParent<TileState>().isS)
            {
                CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().health += 2;

                if (SelectedUnit.GetComponentInParent<TileStatistics>().mana > 0)
                {
                    SelectedUnit.GetComponentInParent<TileStatistics>().mana -= 1;
                    CameraRayCast.TargetHit.GetComponentInParent<TileStatistics>().health += 2;
                }
            }
        }
    }

    public void StructureHit()
    {
        Debug.Log("Struct");
        Debug.Log(CameraRayCast.selectedGameObject.transform.parent.name);


        if (HellTurn == CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().teamHell &&
           HellTurn != CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().teamHeaven &&
           CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().teamNeutral == false)
        {
            CameraRayCast.CanSelect = false;

            RecrutingMenu.gameObject.SetActive(true);
        }
    }

    public void RecruitingCAC()
    {
        Debug.Log("Recruiting CAC");


        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isHQ || CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isFactory)
        {
            if(HellTurn == true && this.gameObject.GetComponent<PauseMenu>().HellFunds >= 16000 ||
               HellTurn == false && this.gameObject.GetComponent<PauseMenu>().HeavenFunds >= 16000)
            {
                Instantiate(CAC, CameraRayCast.selectedGameObject.transform.parent.transform.position, Quaternion.identity, GameObject.Find("Units").transform);

                CameraRayCast.CanSelect = true;

                RecrutingMenu.gameObject.SetActive(false);
                this.gameObject.GetComponent<PauseMenu>().HeavenFunds -= 16000;
            }
            Debug.Log("not enough moeny to recruit");
        }
    }

    public void RecruitingTALD()
    {
        Debug.Log("Recruiting TALD");


        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isHQ || CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isFactory)
        {
            if (HellTurn == true && this.gameObject.GetComponent<PauseMenu>().HellFunds >= 24000 ||
                HellTurn == false && this.gameObject.GetComponent<PauseMenu>().HeavenFunds >= 24000)
            {
                Instantiate(TALD, CameraRayCast.selectedGameObject.transform.parent.transform.position, Quaternion.identity, GameObject.Find("Units").transform);
                CameraRayCast.CanSelect = true;

                RecrutingMenu.gameObject.SetActive(false);
                this.gameObject.GetComponent<PauseMenu>().HeavenFunds -= 24000;
            }
            Debug.Log("not enough moeny to recruit");
        }
    }
    public void RecruitingT()
    {
        Debug.Log("Recruiting T");


        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isFactory)
        {
            if (HellTurn == true && this.gameObject.GetComponent<PauseMenu>().HellFunds >= 24000 ||
                HellTurn == false && this.gameObject.GetComponent<PauseMenu>().HeavenFunds >= 24000)
            {
                Instantiate(T, CameraRayCast.selectedGameObject.transform.parent.transform.position, Quaternion.identity, GameObject.Find("Units").transform);
                CameraRayCast.CanSelect = true;

                RecrutingMenu.gameObject.SetActive(false);
                this.gameObject.GetComponent<PauseMenu>().HeavenFunds -= 24000;
            }
            Debug.Log("not enough moeny to recruit");
        }
    }
    public void RecruitingS()
    {
        Debug.Log("Recruiting S");


        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isAirport)
        {
            if (HellTurn == true && this.gameObject.GetComponent<PauseMenu>().HellFunds >= 32000 ||
                HellTurn == false && this.gameObject.GetComponent<PauseMenu>().HeavenFunds >= 32000)
            {
                Instantiate(S, CameraRayCast.selectedGameObject.transform.parent.transform.position, Quaternion.identity, GameObject.Find("Units").transform);
                CameraRayCast.CanSelect = true;

                RecrutingMenu.gameObject.SetActive(false);
                this.gameObject.GetComponent<PauseMenu>().HeavenFunds -= 32000;
            }
            Debug.Log("not enough moeny to recruit");
        }
    }
    public void EscapeRecruitMenu()
    {
        CameraRayCast.CanSelect = true;

        RecrutingMenu.gameObject.SetActive(false);
    }

    public void TerrainHit()
    {
        Debug.Log("Terrain");
    }
    


    //                         ------------------------------------------------ATTACK-------------------------------------------------
    public void AttackHit()
    {
        Debug.Log("-------------------------hit ATTACK option");

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

    public void RefuelHit()
    {
        Debug.Log("-------------------------hit REFUEL option");

        //CameraRayCast.TargetHit = CameraRayCast.selectedGameObject;
        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit = CameraRayCast.selectedGameObject;
        }


        Debug.Log(SelectedUnit.name);

        CameraRayCast.CanSelect = true;
        SelectedUnit.gameObject.GetComponentInParent<UnitDisplay>().RefuelAction();
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
        SelectedUnit.transform.GetChild(3).gameObject.SetActive(false);

        Debug.Log(SelectedUnit.name);

        ActionMenu.gameObject.SetActive(true);
    }

    public void Wait()
    {
        Debug.Log("-------------------------Wait");
        ActionMode = false;
        IsAttacking = false;
        IsRefueling = false;
        CameraRayCast.CanSelect = true;

        ActionMenu.gameObject.SetActive(false);

        if (CameraRayCast.selectedGameObject.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit = CameraRayCast.selectedGameObject;
        }

        if (SelectedUnit.GetComponentInParent<TileState>().isUnit)
        {
            SelectedUnit.tag = "HasMoved";
        }
        else
        {
            CameraRayCast.selectedGameObject.tag = "HasMoved";
        }
    }


    public void CanCapture()
    {
        Debug.Log("can i capture?");

        if (SelectedUnit.transform.parent.position.x == SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.x &&
            SelectedUnit.transform.parent.position.y == SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.transform.position.y)
        {
            if (SelectedUnit.transform.parent.GetComponent<TileState>().teamHell != SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHell ||
                SelectedUnit.transform.parent.GetComponent<TileState>().teamHeaven != SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHeaven ||
                SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamNeutral)
            {
                Debug.Log("Yes");
                IsCapturing = true;
            }
            else
            {
                IsCapturing = false;
            }
            Debug.Log("no");
        }
        else
        {
            IsCapturing = false;
            Debug.Log("even less");
        }
        Debug.Log("absolutely not");

    }

    public void Capture()
    {
        Debug.Log(SelectedUnit.transform.parent);
        if (IsCapturing)
        {
            SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileStatistics>().captureHP -= (int)SelectedUnit.transform.parent.GetComponent<TileStatistics>().health;

            ActionMenu.gameObject.SetActive(false);
            ActionMode = false;
            IsAttacking = false;
            IsRefueling = false;
            CameraRayCast.CanSelect = true;

            SelectedUnit.transform.parent.tag = "HasMoved";

            Debug.Log(SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileStatistics>().captureHP);

            if(SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileStatistics>().captureHP < 1)
            {
                SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileStatistics>().captureHP = SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileStatistics>().baseCaptureHP;
                SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamNeutral = false;
                
                if (HellTurn)
                {
                    SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHell = true;
                    SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHeaven = false;
                }
                else
                {
                    SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHell = false;
                    SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().teamHeaven = true;
                }

                SelectedUnit.transform.parent.GetComponentInChildren<StatCheck>().structureGameObject.GetComponent<TileState>().TeamColorUpdate();
            }
        }
    }
}
