using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 1.0f;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = transform.GetComponent<Player>();
        InvokeRepeating("callFootsteps", 0, movingSpeed);
    }

    void callFootsteps()
    {
        if (playerScript.state == Player.PlayerStates.MOVING)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Footsteps");
        }
    }
}
