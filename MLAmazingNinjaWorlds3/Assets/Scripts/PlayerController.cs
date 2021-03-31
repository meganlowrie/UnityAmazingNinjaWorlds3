using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animatorClip;

    private Rigidbody rigidBody;

    [SerializeField]
    public bool onGround;
    private bool jumpStart;

    public float distanceGround;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rigidBody = GetComponent<Rigidbody>();
        animatorClip = GetComponent<Animator>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float verticalVelocity = rigidBody.velocity.y;
        if(!Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.5f))
        {
            onGround = false;
        } else
        {
            onGround = true;
        }

        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpStart = true;

        }
        else
        {
            jumpStart = false;
        }

        if(onGround)
        {
            verticalVelocity = 0;
        }

        animatorClip.SetFloat("horizontalVector", horizontal);
        animatorClip.SetFloat("verticalVector", verticalVelocity);

    }

}
