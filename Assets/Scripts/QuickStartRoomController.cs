using UnityEngine;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex; //Number for the build index to the multiplay scene.

    public override void OnEnable()
    {
    	PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
    	PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom() //Callback function for when we succesfully create or join a room.
    {
    	Debug.Log("Joined Room");
    	StartGame();
    }

    private voif StartGame() //Function for loading into the multiplayer scene.
    {
    	if (PhotonNetwork.IsMasterClient)
    	{
    		Debug.Log("Starting Game");
    		PhotonNetwork.LoadLevel(multiplayerSceneIndex); //Because of AutoSync Scene all players who
    	}
    }
}
