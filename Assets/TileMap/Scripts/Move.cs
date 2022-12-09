using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {/*
        if(collision.gameObject.layer == 10)
        {
            if(collision.gameObject.GetComponentInParent<TileState>().isWater)
            {
                for (int i = 0; i < this.gameObject.transform.parent.childCount; i++)
                {
                    if (this.gameObject.transform.localPosition.x > 0)
                    {
                        if (this.gameObject.transform.parent.GetChild(i).localPosition.x > this.gameObject.transform.localPosition.x &&
                            this.gameObject.transform.parent.GetChild(i).localPosition.y == this.gameObject.transform.localPosition.y)
                        {
                            this.gameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        if (this.gameObject.transform.parent.GetChild(i).localPosition.x < this.gameObject.transform.localPosition.x)
                        {
                            this.gameObject.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);
                        }
                    }
                }
        }*/
    }

}
