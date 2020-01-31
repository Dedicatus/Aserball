using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton; //button used for creating and joining a game.
    [SerializeField]
    private GameObject quickCancelButton; //button used for creating and joining a game.
    [SerializeField]
    private int RoomSize; //button used for creating and joining a game.

    public override void OnConnectedToMaster() //Callback function for when the first connection is established.
    {
    	PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client
    	quickStartButton.SetActive(true);
    }

    public void QuickStart() //Paired to the Quick Start button
    {
    	quickStartButton.SetActive(false);
    	quickCancelButton.SetActive(false);
    	PhotonNetwork.JoinRandomRoom(); //First tries to join an existing room
    	Debug.Log("Quick start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Callback function for failled connection
    {
    	Debug.Log("Failed to join a room");
  		CreateRoom();
    }

    void CreateRoom() //trying to create our own room
    {
		Debug.Log("Creating room now");
		int randomRoomNumber = Random.Range(0, 10000); //creating a random name for the room
		RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize};
		PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOps); //attempting to create a new room.
		Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) //callback funtion for failed room creation.
    {
    	Debug.Log("Failed to create room... trying again");
    	CreateRoom();
    }

    public void QuickCancel() //Paired to the cancel button. Used to stop looking for a room to join.
    {
    	quickCancelButton.SetActive(false);
    	quickStartButton.SetActive(true);
    	PhotonNetwork.LeaveRoom();
    }
}
