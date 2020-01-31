using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{

	public Gameobject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Create a networked player object for ach player that loads in to the multiplayer room;
    }

    private void CreatePlayer()
    {
    	Debug.Log("Creating Player");
    	PhotonNetwork.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

}
