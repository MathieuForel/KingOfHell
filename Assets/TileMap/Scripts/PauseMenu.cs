using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject MenuPause;

    [SerializeField] private GameObject Units;

    [SerializeField] public int i = 0;

    public void Start()
    {
        Units = GameObject.Find("Units");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            MenuPause.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.O) && MenuPause.gameObject.activeInHierarchy == true)
        {
            MenuPause.SetActive(false);
        }
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void EndTurn()
    {
        if (this.gameObject.GetComponent<Actions>().HellTurn)
        {
            this.gameObject.GetComponent<Actions>().HellTurn = false;
        }
        else
        {
            this.gameObject.GetComponent<Actions>().HellTurn = true;
        }

        for (i = 0; i < Units.transform.childCount; i++)
        {
            if (this.gameObject.GetComponent<Actions>().HellTurn == Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHell)
            {
                Units.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            /*else
            {
                Units.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }*/

            if (this.gameObject.GetComponent<Actions>().HellTurn != Units.transform.GetChild(i).gameObject.GetComponent<TileState>().teamHeaven)
            {
                Units.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            /*else
            {
                Units.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }*/

            Debug.Log(Units.gameObject.transform.GetChild(i).name);
        }
    }
}
