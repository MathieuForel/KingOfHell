using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.GetComponent<TileState>().isUnit == false)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
