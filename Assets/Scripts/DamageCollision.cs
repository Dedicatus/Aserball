using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class DamageCollision : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    enum DamageType { Dash};
    [SerializeField] DamageType dmgType;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (player == null) return;
        if (coll.gameObject.tag == "Enemy")
        {   
            enemy = coll.gameObject;
            if (dmgType == DamageType.Dash)
            {
                player.GetComponent<Player>().addSingleKill();
                if (player.GetComponent<Player>().isDashHeal)
                    player.GetComponent<Player>().DashHeal();
                if (player.GetComponent<Player>().isDashCharge)
                    player.GetComponent<Player>().DashCharge();
            }
        }

    }

}
