using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUpdate : MonoBehaviour
{
    void FixedUpdate()
    {
        this.gameObject.GetComponent<TextMesh>().text = this.gameObject.GetComponentInParent<TileStatistics>().health.ToString();
    }
}
