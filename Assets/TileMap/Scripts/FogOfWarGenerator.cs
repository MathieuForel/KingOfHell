using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarGenerator : MonoBehaviour
{
    [SerializeField] public int Nrow, Ncolumn;

    [SerializeField] public GameObject FogPrefab;

    [SerializeField] public bool activate;

    public void Start()
    {
       // GridGenerator();
    }

    public void Update()
    {
        if(activate)
        {
            activate = false;
            GridGenerator();
        }
    }


    public void GridGenerator()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Destroy(this.gameObject.transform.GetChild(i).gameObject);
        }

        for (int x = 0; x < Ncolumn; x++)
        {
            for (int y = 0; y < Nrow; y++)
            {
                var spawnedtile = Instantiate(FogPrefab, new Vector3(x, y, -3), Quaternion.identity, this.gameObject.transform);
                spawnedtile.name = $"Tile {x} {y}";

            }
        }
    }
}
