using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FrogEnemyMovement : MonoBehaviour
{
    public Rigidbody2D frogRigidBody2D;
    private bool jumpRight = true;
    private int frameDelay = 0;
    public Animator frogAnimator;

    // Start is called before the first frame update
    public void Start()
    {
        frogRigidBody2D = GetComponent<Rigidbody2D>();
        frogRigidBody2D.velocity = new Vector2(-2, 5);
        frogAnimator.SetBool("isJumping", true);
        frogAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        frameDelay++;
        if (frogRigidBody2D.velocity == new Vector2(0, 0))
        {
            frogAnimator.SetBool("isJumping", false);
            if (frameDelay == 480)
            {
                frogAnimator.SetBool("isJumping", true);
                if (jumpRight)
                {
                    frogRigidBody2D.velocity = new Vector2(2, 5);
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    jumpRight = false;
                }
                else
                {
                    frogRigidBody2D.velocity = new Vector2(-2, 5);
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    jumpRight = true;
                }
                frameDelay = 0;
            }
        }
    }
}
