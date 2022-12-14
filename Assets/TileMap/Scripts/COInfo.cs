using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COInfo : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Camera.main.GetComponent<Actions>().HellTurn == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }



        this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Camera.main.GetComponent<PauseMenu>().HellFunds.ToString();
        this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = Camera.main.GetComponent<PauseMenu>().HeavenFunds.ToString();

        this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value = Camera.main.GetComponent<BattleCalculator>().COPowerHell;
        this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Slider>().value = Camera.main.GetComponent<BattleCalculator>().COPowerHeaven;



        if(this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Slider>().value == this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Slider>().maxValue)
        {
            this.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
        }

        if (this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Slider>().value == this.gameObject.transform.GetChild(1).GetChild(2).GetComponent<Slider>().maxValue)
        {
            this.gameObject.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        }
    }
}
