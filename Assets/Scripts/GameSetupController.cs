using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{

	public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Create a networked player object for ach player that loads in to the multiplayer room;
    }

    private void CreatePlayer()
    {
    	Debug.Log("Creating Player");
    	PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character", "Player"), Vector3.zero + new Vector3 (0, 0, -2), Quaternion.identity);
    }

}
