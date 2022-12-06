using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{

    [SerializeField] public GameObject Highlight;

    public void PointerEnter()
    {
        Debug.Log("GG");
        Highlight.SetActive(true);
    }

    public void PointerExit()
    {
        Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        Highlight.SetActive(false);
    }
}
