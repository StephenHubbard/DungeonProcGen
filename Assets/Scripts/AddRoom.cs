using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates roomTemplates;

    private void Start()
    {
        roomTemplates = FindObjectOfType<RoomTemplates>();
        roomTemplates.rooms.Add(gameObject);
    }
}
