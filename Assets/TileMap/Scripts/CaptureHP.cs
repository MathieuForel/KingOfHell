using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureHP : MonoBehaviour
{
    void FixedUpdate()
    {
        if(this.gameObject.GetComponentInParent<TileStatistics>().captureHP < this.gameObject.GetComponentInParent<TileStatistics>().baseCaptureHP)
        {
            this.gameObject.GetComponent<TextMesh>().text = this.gameObject.GetComponentInParent<TileStatistics>().captureHP.ToString();
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<TextMesh>().text = " ";
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
