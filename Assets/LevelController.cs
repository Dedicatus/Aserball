using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject ballSpawnPoint;
    public GameObject mySpawnPoint;
    [SerializeField] private GameObject ballPrefab;
    private GameObject ball;
    public GameObject myPlayer;

    private void Start()
    {
        ball = Instantiate(ballPrefab, ballSpawnPoint.transform.position, Quaternion.identity);
    }

    public void resetRound()
    {
        ball.transform.position = ballSpawnPoint.transform.position;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        myPlayer.transform.position = mySpawnPoint.transform.position;
        myPlayer.transform.rotation = mySpawnPoint.transform.rotation;
        myPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        myPlayer.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
