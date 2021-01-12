using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates roomTemplates;
    private int rand;
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
                rand = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, roomTemplates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[rand], transform.position, roomTemplates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, roomTemplates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, roomTemplates.rightRooms[rand].transform.rotation);
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
                //Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            hasSpawned = true;
        }
    }
}
