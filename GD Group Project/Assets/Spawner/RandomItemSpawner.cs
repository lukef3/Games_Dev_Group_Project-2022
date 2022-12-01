using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float secondsBetweenSpawn = 0.5f;
    float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0f;

            int randomIndex = Random.Range(0, pickups.Length);
            int randomTileLevel = Random.Range(0,3);
            Vector2 randomPositionTop = Random.insideUnitCircle * 60;
            Vector2 randomPositionMiddle = Random.insideUnitCircle * 45;
            Vector2 randomPositionBottom = Random.insideUnitCircle * 30;
            float tileLevelCoord;

            if (randomTileLevel == 0)
            {
                tileLevelCoord = 1f;
                Vector3 randomSpawnPosition = new Vector3(randomPositionTop.x, tileLevelCoord, randomPositionTop.y);
                Instantiate(pickups[randomIndex], randomSpawnPosition, Quaternion.identity);
            }

            if (randomTileLevel == 1)
            {
                tileLevelCoord = -19f;
                Vector3 randomSpawnPosition = new Vector3(randomPositionMiddle.x, tileLevelCoord, randomPositionMiddle.y);
                Instantiate(pickups[randomIndex], randomSpawnPosition, Quaternion.identity);
            }

            if (randomTileLevel == 2)
            {
                tileLevelCoord = -39f;
                Vector3 randomSpawnPosition = new Vector3(randomPositionBottom.x, tileLevelCoord, randomPositionBottom.y);
                Instantiate(pickups[randomIndex], randomSpawnPosition, Quaternion.identity);
            }
        }
    }
}
