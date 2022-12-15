using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void LateUpdate()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
