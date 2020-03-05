using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Player playerScript;

    FMOD.Studio.EventInstance kickBallSound;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        kickBallSound = FMODUnity.RuntimeManager.CreateInstance("event:/KickBall");
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
                {
                    kickBallSound.setParameterByName("Volume", playerScript.dashScale());
                    kickBallSound.start();
                }
                break;
            default:
                break;
        }
    }
}
