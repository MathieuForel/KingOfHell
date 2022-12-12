using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActiveButton : MonoBehaviour
{
    [SerializeField] public GameObject Camera;

    void Update()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);

        if (CameraRayCast.selectedGameObject.gameObject.GetComponentInParent<TileState>() != null)
        {
            if (CameraRayCast.selectedGameObject.gameObject.GetComponentInParent<TileState>().isUnit == true)
            {

                //Debug.Log(CameraRayCast.selectedGameObject.gameObject.transform.GetChild(2).childCount);
                //Debug.Log(CameraRayCast.selectedGameObject.gameObject.transform.GetChild(3).childCount);

                this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
               this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                          this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                //Debug.Log(CameraRayCast.selectedGameObject.gameObject);

                if (CameraRayCast.selectedGameObject.gameObject.GetComponent<TileState>().isT == true)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }

                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(2).childCount == 0)
                {
                    //Debug.Log("UNIT HAS NO ATTACK MOVE");
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(2).childCount > 1)
                {
                    //Debug.Log("UNIT HAS ATTACKS MOVE");
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }

                if(CameraRayCast.selectedGameObject.gameObject.GetComponent<TileState>().isT == true)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
     
                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(3).childCount == 0)
                {
                    //Debug.Log("UNIT HAS NO REFUEL MOVE");
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                }
                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(3).childCount > 1)
                {
                    //Debug.Log("UNIT HAS REFUELS MOVE");
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }

                if (CameraRayCast.selectedGameObject.gameObject.GetComponent<TileState>().isT == true)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }



                Camera.gameObject.GetComponent<Actions>().CanCapture();

                this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                if (Camera.gameObject.GetComponent<Actions>().IsCapturing)
                {
                    Debug.Log("capturing");
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("NOT capturing");
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            else
            {
                this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            }
            if (CameraRayCast.selectedGameObject.gameObject.GetComponent<TileState>().isT == true)
            {
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        /*
        Camera.gameObject.GetComponent<Actions>().CanCapture();

        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        if (Camera.gameObject.GetComponent<Actions>().IsCapturing)
        {
            Debug.Log("capturing");
            this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("NOT capturing");
            this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }*/

    }
}
