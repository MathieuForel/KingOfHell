using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{

    [SerializeField] public GameObject Highlight;

    [SerializeField] private bool _isTerrain;
    [SerializeField] private bool _isStructure;
    [SerializeField] private bool _isUnit;
    [SerializeField] private bool _isAction;
    [SerializeField] private bool _isMove;


    public void Awake()
    {
        _isTerrain = this.gameObject.GetComponentInParent<TileState>().isTerrain;
        _isStructure = this.gameObject.GetComponentInParent<TileState>().isStructure;
        _isUnit = this.gameObject.GetComponentInParent<TileState>().isUnit;
        _isAction = this.gameObject.GetComponentInParent<TileState>().isAction;
        _isMove = this.gameObject.GetComponentInParent<TileState>().isMove;
    }

    public void PointerEnter()
    {
        Highlight.SetActive(true);

    }

    public void PointerExit()
    {
        //Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        Highlight.SetActive(false);
    }


    public void Start()
    {
        Collider[] ColliderTouched = Physics.OverlapBox(this.gameObject.transform.position, this.gameObject.transform.localScale / 2);


        for (int i = 0; i < ColliderTouched.Length; i++)
        {
            if (ColliderTouched[i].gameObject.transform.parent.gameObject.layer == this.gameObject.transform.parent.gameObject.layer)
            {
                if (this.gameObject.transform.parent.gameObject != ColliderTouched[i].gameObject.transform.parent.gameObject)
                {
                    this.gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }
}
