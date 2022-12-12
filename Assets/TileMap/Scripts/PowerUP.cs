using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{

    void FixedUpdate()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);

        if (Camera.main.GetComponent<BattleCalculator>().COPowerHell == 70 && Camera.main.GetComponent<Actions>().HellTurn == true)
        {
            this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }

        if (Camera.main.GetComponent<BattleCalculator>().COPowerHeaven == 70 && Camera.main.GetComponent<Actions>().HellTurn == false)
        {
            this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
}
