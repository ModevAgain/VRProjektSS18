using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour {

    public LevelData LevelData;

    private DoorScript _currentDoor;

    private bool _firstStart = true;

    private int _roomCounter = 0;
    private float _currentYPos = 0;

	// Use this for initialization
	void Start () {
        spawnRoom();
	}

    void spawnRoom()
    {

        GameObject tempRoom = LevelData.Rooms[_roomCounter].RoomObj;

        _currentYPos += LevelData.Rooms[_roomCounter].Width;

        tempRoom.transform.position = new Vector3(0, 0, _currentYPos);
        GameObject instRoom = Instantiate<GameObject>(tempRoom);

        _currentDoor = instRoom.GetComponentInChildren<DoorScript>();

        if (_currentDoor != null)
            _currentDoor.doorOpening += spawnRoom;

        _roomCounter++;
        
    }
}
