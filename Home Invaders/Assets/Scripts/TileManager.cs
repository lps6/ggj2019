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

    private bool isClick = true;

    private void Start()
    {
        isClick = true;
    }

    IEnumerator ClickRoutine()
    {
        yield return new WaitForSeconds(3f);
        isClick = true;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && isClick)
        {

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
            if (grid.GetComponentInChildren<Tilemap>().GetTile(coordinate))
            {
                int enemyRandomIndex = UnityEngine.Random.Range(0, levelManager.level.availableFriends.Count);
                Instantiate(levelManager.level.availableFriends[enemyRandomIndex]).transform.position = grid.transform.GetChild(0).GetComponent<Tilemap>().GetCellCenterWorld(coordinate);
                grid.transform.GetChild(0).GetComponent<Tilemap>().SetTile(coordinate, null);
                isClick = false;
                StartCoroutine(ClickRoutine());
            }
            
            
            //TileBase tile = grid.GetComponentInChildren<Tilemap>().GetTile(coordinate);
        }
    }
}