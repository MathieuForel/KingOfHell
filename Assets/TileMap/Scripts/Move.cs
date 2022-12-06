using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private int Moving;

    void Start()
    {
        Moving = 0;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<TileState>().isMove == true)
        {*/
            if (Moving >= 1)
            {
                Debug.Log("Moving worked");
                this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<TileState>().isMove = false;
                Moving = 0;
                this.gameObject.transform.parent.gameObject.SetActive(false);

            }
        //}

    }

    public void StartMovement()
    {
        Moving += 1;
    }
}
