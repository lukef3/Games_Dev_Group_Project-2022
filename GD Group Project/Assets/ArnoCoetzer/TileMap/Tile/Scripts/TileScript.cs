using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    
    private float tile_Health;
    private float max_health = 100f;
    TileMapMaster manager;

    private void Start()
    {
        tile_Health = max_health; 
    }
  

    internal void Set_Manager(TileMapMaster master) 
    {
        manager = master;
    }

    public void Take_Damage(float amount)
    {
        tile_Health = tile_Health - amount;

        if (tile_Health <= 0)
        {
            Destroy_Tile();
        }
      
    }

    internal void Destroy_Tile() 
    {
        manager.RemoveTileFromList(this);
        Destroy(this.gameObject);
    }


    
}
