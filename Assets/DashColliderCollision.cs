using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashColliderCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ball")
        {
            Physics.IgnoreCollision(collision.collider, transform.GetComponent<BoxCollider>());
        }
    }
}
