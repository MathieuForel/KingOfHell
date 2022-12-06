using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int Nrow, Ncolumn;

    [SerializeField] public GameObject TilePrefab;


    public void Start()
    {
        GridGenerator();
    }

    public void GridGenerator()
    {

        for(int x = 0; x < Ncolumn; x++)
        {
            for(int y = 0; y < Nrow; y++)
            {
                var spawnedtile = Instantiate(TilePrefab, new Vector3(x, y), Quaternion.identity, this.gameObject.transform);
                spawnedtile.name = $"Tile {x} {y}";

            }
        }
    }
}
