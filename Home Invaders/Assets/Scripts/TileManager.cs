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

    public GameObject currentFriendScreen;

    private Sprite currentFriendSprite;

    private int friendRandomIndex = 0;

    private void Start()
    {
        isClick = true;
        friendRandomIndex = UnityEngine.Random.Range(0, levelManager.level.availableFriends.Count);
        currentFriendScreen.GetComponent<SpriteRenderer>().sprite = levelManager.level.availableFriends[friendRandomIndex].GetComponent<Friend>().friend.image;
    }

    IEnumerator ClickRoutine()
    {
        currentFriendScreen.SetActive(false);
        yield return new WaitForSeconds(3f);
        currentFriendScreen.SetActive(true);
        friendRandomIndex = UnityEngine.Random.Range(0, levelManager.level.availableFriends.Count);
        currentFriendScreen.GetComponent<SpriteRenderer>().sprite = levelManager.level.availableFriends[friendRandomIndex].GetComponent<Friend>().friend.image;
        isClick = true;
    }

    public void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        currentFriendScreen.transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0) && isClick)
        {

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
            if (grid.GetComponentInChildren<Tilemap>().GetTile(coordinate))
            {
                //friendRandomIndex = UnityEngine.Random.Range(0, levelManager.level.availableFriends.Count);
                Instantiate(levelManager.level.availableFriends[friendRandomIndex]).transform.position = grid.transform.GetChild(0).GetComponent<Tilemap>().GetCellCenterWorld(coordinate);
                //grid.transform.GetChild(0).GetComponent<Tilemap>().SetTile(coordinate, null);
                isClick = false;
                StartCoroutine(ClickRoutine());
            }
            
            
            //TileBase tile = grid.GetComponentInChildren<Tilemap>().GetTile(coordinate);
        }
    }
}