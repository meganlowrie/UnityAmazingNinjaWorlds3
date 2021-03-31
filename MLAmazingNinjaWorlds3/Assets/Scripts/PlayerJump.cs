using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpStrength = 10f;

    public float fallMultiplier = 2.5f;
    public float jumpMultiplier = 2f;
    public GameObject player;

    public bool alwaysJumping = false;

    private bool canJump;

    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        canJump = player.GetComponent<PlayerController>().onGround;
    }

    // Update is called once per frame
    void Update()
    {
        canJump = player.GetComponent<PlayerController>().onGround;

        if (Input.GetButtonDown("Jump") && canJump)
        {
            StartCoroutine(JumpControl());
        }

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }

    }

    IEnumerator JumpControl()
    {
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().velocity = Vector3.up * jumpStrength;
    }
}
