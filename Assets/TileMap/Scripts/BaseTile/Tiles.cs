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

    public void PointerClick()
    {
        if(_isUnit == true)
        {
            this.gameObject.GetComponentInParent<UnitDisplay>().MoveAction();
        }
        Debug.Log("LETS GO");


        if (_isAction == true)
        {

            if (_isMove == true)
            {
                this.gameObject.GetComponentInParent<Move>().StartMovement();
                Debug.Log("COOLBRO");
            }
        }

    }
}
