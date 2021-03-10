using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    public Transform WallParentTransform;
    public Transform SpawnerParentTransform;
    public GameObject WallPrefab;

    void Start()
    {
        player = PlayerController.Instance;
        InstantiateWallsAndSetToCameraWidth();   
    }

    private void InstantiateWallsAndSetToCameraWidth()
    {
        float verticalSize = Camera.main.orthographicSize;
        float horizontalSize = verticalSize * Screen.width / Screen.height;

        GameObject leftWall = Instantiate(WallPrefab, new Vector3(-horizontalSize, 0), Quaternion.identity, WallParentTransform);
        GameObject rightWall = Instantiate(WallPrefab, new Vector3(horizontalSize, 0), Quaternion.identity, WallParentTransform);

        verticalSize /= 6;
        leftWall.transform.localScale = new Vector3(leftWall.transform.localScale.x,verticalSize);
        rightWall.transform.localScale = new Vector3(rightWall.transform.localScale.x, verticalSize);
    }

    void Update()
    {
        //SetTransformsToPlayerHeight(); For Performance
        SetCameraToPlayerHeight();
    }

    private void SetCameraToPlayerHeight()
    {
        Transform camTransform = transform;
        camTransform.position = new Vector3(0,player.transform.position.y,camTransform.position.z);
    }

    private void SetTransformsToPlayerHeight()
    {
        WallParentTransform.position = new Vector3(0, player.transform.position.y,0);
        SpawnerParentTransform.position = WallParentTransform.position;
    }
}
