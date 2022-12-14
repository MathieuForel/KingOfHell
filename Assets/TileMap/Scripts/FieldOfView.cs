using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] public LayerMask LayerMask;

    [SerializeField] public Mesh mesh;

    public float x;
    public float y;

    [SerializeField] public float fov;
    [SerializeField] public int RayCount;
    [SerializeField] private float Angle;
    [SerializeField] private float AngleIncrease;
    [SerializeField] public float ViewDistance;
    [SerializeField] private int VertexIndex;
    [SerializeField] private int TriangleIndex;

    [SerializeField] public Vector3 vertex;



    void Start()
    {
        mesh = new Mesh();
        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        this.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    public void LateUpdate()
    {
        ViewDistance = this.gameObject.transform.parent.GetComponent<TileStatistics>().vision;
        RayCount = (int)ViewDistance * 4;

        //fov = 90f;
        Vector3 origin = Vector3.zero;
        Angle = 0f;
        AngleIncrease = fov / RayCount;


        Vector3[] vertices = new Vector3[RayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RayCount * 3];

        vertices[0] = origin;

        VertexIndex = 1;
        TriangleIndex = 0;
        for (int i = 0; i <= RayCount; i++)
        {
            //Vector3 vertex;

            //RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))), ViewDistance/*, LayerMask*/);

            //RaycastHit[] ray = Physics.RaycastAll(origin, new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))), Mathf.Infinity, LayerMask);

            //bool ray = Physics.Raycast(origin, new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))), Mathf.Infinity, LayerMask);

            Ray ray = new Ray(this.gameObject.transform.position, new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))));
            RaycastHit hit;

            //Debug.DrawRay(this.gameObject.transform.position, new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))), Color.green, 100f);

            Physics.Raycast(ray, out hit);
           // if ((Physics.Raycast(ray , out hit, 100f)  && hit.transform.gameObject.layer != 4)
            //{
                //Debug.Log("qsf");
                vertex = origin + new Vector3(Mathf.Cos(Angle * (Mathf.PI / 180f)), Mathf.Sin(Angle * (Mathf.PI / 180f))) * ViewDistance;
           // }

            try
            {
                if (Physics.Raycast(ray, out hit, ViewDistance) && hit.transform.gameObject.tag == "BlockVision")
                {
                    //Debug.Log("i hit something D:");
                    vertex = origin;
                    //Debug.Log((this.gameObject.transform.position.x - hit.transform.position.x));
                }

                if (Physics.Raycast(ray, out hit, ViewDistance) && hit.transform.gameObject.tag == "FogOfWar")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            catch (NullReferenceException)
            { 
            
            }


            vertices[VertexIndex] = vertex;

            if(i > 0)
            {
                triangles[TriangleIndex + 0] = 0;
                triangles[TriangleIndex + 1] = VertexIndex - 1;
                triangles[TriangleIndex + 2] = VertexIndex;

                TriangleIndex += 3;
            }

            VertexIndex++;
            Angle -= AngleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

    }

}
