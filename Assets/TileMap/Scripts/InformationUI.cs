using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour
{
    [SerializeField] private GameObject TS;

    [SerializeField] private GameObject U;

    public void Update()
    {
        try
        {
            if(CameraRayCast.TargetHit.GetComponentInParent<TileState>().isTerrain || CameraRayCast.TargetHit.GetComponentInParent<TileState>().isStructure)
            {
                TS = CameraRayCast.TargetHit.gameObject.transform.parent.gameObject;
            }
        }
        catch (NullReferenceException)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        try
        {
            if (CameraRayCast.TargetHit.GetComponentInParent<TileState>().isUnit)
            {
                U = CameraRayCast.TargetHit.gameObject.transform.parent.gameObject;
            }
        }
        catch (NullReferenceException)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (TS != null)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);


            this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = TS.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = TS.name;
            this.gameObject.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = "Movement: " + TS.GetComponent<TileStatistics>().bonusMovementRange.ToString();
            this.gameObject.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "Vision: " + TS.GetComponent<TileStatistics>().bonusVision.ToString();
            this.gameObject.transform.GetChild(0).GetChild(5).GetComponent<Text>().text = "Defence: " + (TS.GetComponent<TileStatistics>().bonusDefence + TS.GetComponent<TileStatistics>().defencePoints).ToString();
        }

        if(U != null)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);


            this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = U.GetComponent<SpriteRenderer>().sprite;

            if (U.GetComponent<TileState>().isCAC)
            {
                this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "corps a corps (CAC)";
            }
            if (U.GetComponent<TileState>().isTALD)
            {
                this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "tireur a longue distance (TALD)";
            }
            if (U.GetComponent<TileState>().isT)
            {
                this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "tank (T)";
            }
            if (U.GetComponent<TileState>().isS)
            {
                this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "soigneur (S)";
            }


            this.gameObject.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = "Attaque: " + U.GetComponent<TileStatistics>().attack.ToString();
            this.gameObject.transform.GetChild(1).GetChild(4).GetComponent<Text>().text = "Defence: " + U.GetComponent<TileStatistics>().defence.ToString();
            this.gameObject.transform.GetChild(1).GetChild(5).GetComponent<Text>().text = "Vision: " + U.GetComponent<TileStatistics>().vision.ToString();
            this.gameObject.transform.GetChild(1).GetChild(6).GetComponent<Text>().text = "Movement: " + U.GetComponent<TileStatistics>().movement.ToString();
            this.gameObject.transform.GetChild(1).GetChild(7).GetComponent<Text>().text = "Mana: " + U.GetComponent<TileStatistics>().mana.ToString();
            this.gameObject.transform.GetChild(1).GetChild(8).GetComponent<Text>().text = "Stamina: " + U.GetComponent<TileStatistics>().stamina.ToString();
        }

    }
}
