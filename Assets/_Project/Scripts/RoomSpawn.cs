using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour {

    public GameObject EmptyRoom;
    public GameObject StartRoom;

    private DoorScript _currentDoor;

    private bool _firstStart = true;

	// Use this for initialization
	void Start () {
        spawnRoom();
	}

    void spawnRoom()
    {
        if (_firstStart)
        {
            StartRoom.transform.position = new Vector3(0, 0, 0);
            GameObject tempRoom = Instantiate<GameObject>(StartRoom);

            _currentDoor = tempRoom.GetComponentInChildren<DoorScript>();

            if (_currentDoor != null)
                _currentDoor.doorOpening += spawnRoom;

            _firstStart = false;
        }
        else
        {
            GameObject tempRoom = Instantiate<GameObject>(EmptyRoom);
            tempRoom.transform.position = new Vector3(20, 0, 0);

            
            _currentDoor = tempRoom.GetComponentInChildren<DoorScript>();

            if (_currentDoor != null)            
                _currentDoor.doorOpening += spawnRoom;

            


        }



    }
}
