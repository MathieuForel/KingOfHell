using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Vector3 mousePosition;

    [SerializeField] public int cameraClampXminus;
    [SerializeField] public int cameraClampXplus;
    [SerializeField] public int cameraClampYminus;
    [SerializeField] public int cameraClampYplus;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)) - this.gameObject.transform.position;

        //Debug.Log(mousePosition);

        if(mousePosition.x > Vector3.one.x * 10)
        {
            this.gameObject.transform.position += Vector3.right * 0.1f;
        }

        if (mousePosition.x < -Vector3.one.x * 10)
        {
            this.gameObject.transform.position += Vector3.left * 0.1f;
        }

        if (mousePosition.y > Vector3.one.x * 5)
        {
            this.gameObject.transform.position += Vector3.up * 0.1f;
        }

        if (mousePosition.y < -Vector3.one.x * 5)
        {
            this.gameObject.transform.position += Vector3.down * 0.1f;
        }

        this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, cameraClampXminus, cameraClampXplus), Mathf.Clamp(this.gameObject.transform.position.y, cameraClampYminus, cameraClampYplus), -100);


    }
}
