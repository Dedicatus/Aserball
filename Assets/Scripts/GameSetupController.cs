using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
	public GameObject playerPrefab;

    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.FindWithTag("LevelController").GetComponent<LevelController>();
        CreatePlayer(); //Create a networked player object for ach player that loads in to the multiplayer room;
    }

    private void CreatePlayer()
    {
    	Debug.Log("Creating Player");
        levelController.myPlayer = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character", "Player"), levelController.mySpawnPoint.transform.position, Quaternion.identity);
    }

}
