using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    TileMapMaster tileManager;
    public Transform joeCloneTemplate;
    Vector3 spawnJoePosition = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        tileManager = FindObjectOfType<TileMapMaster>();
        tileManager.CreateMap(30, 3, 15, 20);

        spawnJoe();

    }

    private void spawnJoe()
    {
        Transform joe = Instantiate(joeCloneTemplate, spawnJoePosition, Quaternion.identity);
        GameObject joeCameraGO = new GameObject("JoeCamGO");
        joeCameraGO.transform.parent = joe.transform;
        joeCameraGO.transform.localPosition = new Vector3(0, 1, -2);

        Camera joeCam = joeCameraGO.gameObject.AddComponent<Camera>();
        Camera.main.tag = "Untagged";
        joeCam.tag = "MainCamera";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
