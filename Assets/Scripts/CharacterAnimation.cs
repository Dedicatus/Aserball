using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    Player player;
    private float dashTimer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = transform.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        switch (player.state)
        {
            case Player.PlayerStates.IDLING:
                animator.SetBool("isMoving", false);
                animator.SetBool("isAttacking", false);
                break;
            case Player.PlayerStates.MOVING: 
                animator.SetBool("isMoving", true);
                animator.SetBool("isAttacking", false);
                break;
            case Player.PlayerStates.DASHING:
                animator.SetBool("isMoving", false);
                animator.SetBool("isAttacking", true);
                break;
        }
    }
}
