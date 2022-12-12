using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUpdate : MonoBehaviour
{
    void FixedUpdate()
    {

        if(this.gameObject.GetComponentInParent<TileStatistics>().turnsBeforeProduced > 0)
        {
            this.gameObject.GetComponent<TextMesh>().text = this.gameObject.GetComponentInParent<TileStatistics>().turnsBeforeProduced.ToString();
            this.gameObject.transform.GetComponent<TextMesh>().color = new Color(255f / 255f, 0f / 255f, 255f / 255f);
        }
        else
        {
            this.gameObject.GetComponent<TextMesh>().text = this.gameObject.GetComponentInParent<TileStatistics>().health.ToString();
            this.gameObject.transform.GetComponent<TextMesh>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
        }

    }
}
