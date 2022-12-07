using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{


    public Ray ray;
    public RaycastHit hit;

    [SerializeField] public static GameObject selectedGameObject;
    [SerializeField] public static GameObject TargetHit;

    [SerializeField] public static bool CanSelect;

    public void Start()
    {
        Debug.Log("YES");
        CanSelect= true;
    }

    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
        if (Physics.Raycast(ray, out hit) && CanSelect == true)
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
            TargetHit = hit.transform.gameObject;


        }
        else
        {
            selectedGameObject.transform.GetComponent<Tiles>().PointerExit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.transform.GetComponent<Actions>().TypeHit();
        }
    }
}
