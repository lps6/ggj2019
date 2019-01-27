using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using System;

public class TileManager : MonoBehaviour
{
    public Grid grid;

    public LevelManager levelManager;

    public void Start()
    {
      
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
         
            if (grid.GetComponentInChildren<Tilemap>().GetTile(coordinate))
            {
                Instantiate(levelManager.level.availableFriends[0]).transform.position = grid.transform.GetChild(0).GetComponent<Tilemap>().GetCellCenterWorld(coordinate);
                grid.transform.GetChild(0).GetComponent<Tilemap>().SetTile(coordinate, null);
            }
            
            
            //TileBase tile = grid.GetComponentInChildren<Tilemap>().GetTile(coordinate);
        }
    }
}