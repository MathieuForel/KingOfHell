using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionActiveButton : MonoBehaviour
{
    [SerializeField] public GameObject Camera;

    void Update()
    {
        if (CameraRayCast.selectedGameObject.gameObject.GetComponentInParent<TileState>() != null)
        {
            if (CameraRayCast.selectedGameObject.gameObject.GetComponentInParent<TileState>().isUnit == true)
            {
                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(2).childCount < 1)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }

                if (CameraRayCast.selectedGameObject.gameObject.transform.GetChild(3).childCount < 1)
                {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                }
                else
                {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
            }
        }

    }
}
