using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{
    public GameObject selectedGameObject;

    public Ray ray;
    public RaycastHit hit;

    public void Start()
    {
        Debug.Log("YES");
    }

    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            if (selectedGameObject == null)
            {
                selectedGameObject = hit.transform.gameObject;
            }

            if (hit.transform.gameObject != selectedGameObject)
            {
                selectedGameObject.transform.GetComponent<Tiles>().PointerExit();
                selectedGameObject = hit.transform.gameObject;
            }

            hit.transform.GetComponent<Tiles>().PointerEnter();
            selectedGameObject = hit.transform.gameObject;
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
        else
        {
            selectedGameObject.transform.GetComponent<Tiles>().PointerExit();
        }

    }
}
