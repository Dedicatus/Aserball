using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                FMODUnity.RuntimeManager.PlayOneShot("event:/HitWall", GetComponent<Transform>().position);
                break;
            case "Player":
                if (collision.gameObject.GetComponent<Player>().state == Player.PlayerStates.DASHING)
                    FMODUnity.RuntimeManager.PlayOneShot("event:/KickBall", GetComponent<Transform>().position);
                break;
            default:
                break;
        }
    }
}
