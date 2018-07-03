using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour {

    public LevelData LevelData;



    private DoorActivation _currentDoor;

    private bool _firstStart = true;

    private int _roomCounter = 0;
    private float _currentYPos = 0;
	private ContentScript _currentRoom;
	private ContentScript _oldRoom;

	// Use this for initialization
	void Start () {
        spawnRoom();

        
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            spawnRoom();
    }

    void spawnRoom()
    {

        //_currentRoom -> _oldRoom
        if (_currentRoom != null)
			_oldRoom = _currentRoom;


        GameObject tempRoom = LevelData.Rooms[_roomCounter].RoomObj;

        _currentYPos += LevelData.Rooms[_roomCounter].Width;

        tempRoom.transform.position = new Vector3(0, 0, _currentYPos);
        GameObject instRoom = Instantiate<GameObject>(tempRoom);

        _currentRoom = instRoom.GetComponent<ContentScript>();
        StartCoroutine(_currentRoom.Setup());
        _currentDoor = _currentRoom.Door;
        _currentDoor.RoomHasFinished += () => StartCoroutine(DeleteRoom());
        
        if (_currentDoor != null)
            _currentRoom.Door.doorOpening += spawnRoom;

        _roomCounter++;
        
    }

	public IEnumerator DeleteRoom()
	{
        _currentDoor.RoomHasFinished -= () => StartCoroutine(DeleteRoom());
        yield return _currentRoom.CloseConnectionToOldRoom();
		Destroy (_oldRoom.gameObject);

	}

}
