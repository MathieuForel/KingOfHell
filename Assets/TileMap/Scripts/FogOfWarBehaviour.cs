using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarBehaviour : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FogOfWar")
        {
            Destroy(collision.gameObject);
        }
        Debug.Log(this.gameObject);
        Debug.Log(collision.gameObject.transform.parent.gameObject);

        if(collision.gameObject.transform.parent.gameObject.layer == 12)
        {
            try
            {

                Debug.Log(Camera.main.GetComponent<Actions>().HellTurn);

                if (Camera.main.GetComponent<Actions>().HellTurn == true && collision.gameObject.GetComponentInParent<TileState>().teamHell)
                {
                    Destroy(this.gameObject);
                }

                if (Camera.main.GetComponent<Actions>().HellTurn == false && collision.gameObject.GetComponentInParent<TileState>().teamHeaven)
                {
                    Destroy(this.gameObject);
                }
            }
            catch (NullReferenceException)
            {

            }

        }

        if (collision.gameObject.transform.parent.gameObject.layer == 11)
        {
            try
            {
                if (Camera.main.GetComponent<Actions>().HellTurn == true && collision.gameObject.GetComponentInParent<TileState>().teamHell)
                {
                    Destroy(this.gameObject);
                }

                if (Camera.main.GetComponent<Actions>().HellTurn == false && collision.gameObject.GetComponentInParent<TileState>().teamHeaven)
                {
                    Destroy(this.gameObject);
                }
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
