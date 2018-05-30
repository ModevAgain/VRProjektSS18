using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData", order = 1)]

public class LevelData : ScriptableObject {

    public List<Room> Rooms;
}

[Serializable]
public class Room
{
    public GameObject RoomObj;
    public float Width;


}
