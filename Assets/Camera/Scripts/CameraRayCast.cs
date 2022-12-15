using System;
using System.Collections;
using System.Collections.Generic;
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
    {/*
        if (this.gameObject.transform.GetComponent<Actions>().SelectedUnit == null)
        {

        }
        else
        {
            Debug.Log(this.gameObject.transform.GetComponent<Actions>().SelectedUnit);
        }*/


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
                try
                {
                    selectedGameObject.transform.GetComponent<Tiles>().PointerExit();
                }
                catch (NullReferenceException)
                {
                    selectedGameObject = hit.transform.gameObject;
                }
                selectedGameObject = hit.transform.gameObject;
            }

            try
            {
                hit.transform.GetComponent<Tiles>().PointerEnter();
            }
            catch (NullReferenceException)
            {

            }



            selectedGameObject = hit.transform.gameObject;
            TargetHit = hit.transform.gameObject;
        }
        else
        {
            try
            {
                selectedGameObject.transform.GetComponent<Tiles>().PointerExit();
            }
            catch (NullReferenceException)
            {

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            try
            {
                this.gameObject.transform.GetComponent<Actions>().TypeHit();
            }
            catch(NullReferenceException)
            { 
            
            }
        }
    }
}
