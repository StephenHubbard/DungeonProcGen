using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates roomTemplates;
    private int randomNum;
    private bool hasSpawned = false;

    public float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);

        roomTemplates = FindObjectOfType<RoomTemplates>();

        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (hasSpawned == false)
        {
            if (openingDirection == 1)
            {
                randomNum = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[randomNum], transform.position, roomTemplates.bottomRooms[randomNum].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                randomNum = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[randomNum], transform.position, roomTemplates.topRooms[randomNum].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                randomNum = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[randomNum], transform.position, roomTemplates.leftRooms[randomNum].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                randomNum = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[randomNum], transform.position, roomTemplates.rightRooms[randomNum].transform.rotation);
            }
            hasSpawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().hasSpawned == false && hasSpawned == false)
            {
                Destroy(gameObject);
            }
            hasSpawned = true;
        }
    }
}
