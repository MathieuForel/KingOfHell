using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarBehaviour : MonoBehaviour
{
    [SerializeField] private Collider[] ColliderTouched; 

    public void Start()
    {
        ColliderTouched = Physics.OverlapBox(this.gameObject.transform.position, this.gameObject.GetComponent<BoxCollider>().size / 2);

        for (int i = 0; i < ColliderTouched.Length; i++)
        {
            if (ColliderTouched[i].gameObject.transform.parent.gameObject.tag == this.gameObject.tag)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
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
            Debug.Log(this.gameObject);
            try
            {
                Debug.Log(collision.gameObject);

                if (Camera.main.GetComponent<Actions>().HellTurn == true && collision.gameObject.GetComponentInParent<TileState>().teamHell)
                {
                    Destroy(this.gameObject);
                }

                if (Camera.main.GetComponent<Actions>().HellTurn == false && collision.gameObject.GetComponentInParent<TileState>().teamHeaven)
                {
                    Debug.Log("mhhhh");
                    Destroy(this.gameObject);
                }
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
