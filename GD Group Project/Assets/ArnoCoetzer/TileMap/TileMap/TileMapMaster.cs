using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapMaster : MonoBehaviour
{
   
    public Object tile;
    public float radius = 30;
    public int levels = 3;
    public int radius_dec_per_level = 15;
    public float distance_between_levels = 20;

    public List<TileScript> Tiles;
    private Vector2 grid_Size;
    private float tile_Size = 2.5f;
    private Quaternion Tile_rotation = new Quaternion(0.70711f,0,0,-0.70711f);

    public List<TileScript> Tiles1 { get => Tiles; set => Tiles = value; }

    void Start()
    {
        grid_Size = new Vector2(radius * 2, radius * 2);
        radius = radius + 1;
        

        for (int z = 0; z < levels; z++)
        {
            for (int x = 0; x < grid_Size.x; x++)
            {
                for (int y = 0; y < grid_Size.y; y++)
                {
                    Vector3 location = new Vector3(x * tile_Size, z * distance_between_levels, y * tile_Size);

                    location = new Vector3(location.x - (((tile_Size * grid_Size.x) / 2) - 1.25f), location.y - ((distance_between_levels*levels)-distance_between_levels), location.z - (((tile_Size * grid_Size.y) / 2) - 1.25f));

                    float i = levels - z - 1;
                    

                    if (vec3ToVec2Magnitude(location) <= (radius * 2) - (radius_dec_per_level * i) )  
                    {          
                        SpawnTile(location);                       
                    }           
                }
            }
        }  
    }

   

    void SpawnTile(Vector3 location) 
    {
        GameObject spawnedTile = Instantiate(tile, location, Tile_rotation) as GameObject;
        TileScript current_tile = spawnedTile.GetComponent<TileScript>();
        current_tile.Set_Manager(this);
        Tiles.Add(current_tile);
    }

    float vec3ToVec2Magnitude(Vector3 loc) 
    {
        Vector3 loc2= new Vector3(loc.x,0,loc.z);
        float result = loc2.magnitude;
        return result;
    }

    internal void RemoveTileFromList(TileScript tile) 
    {
        Tiles.Remove(tile);
    }

}
