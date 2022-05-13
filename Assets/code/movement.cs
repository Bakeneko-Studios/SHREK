using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody Rigid;

    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public float health = 100;
    // Start is called before the first frame update
    public bool dead = false;
    void Start()
    {
        Rigid = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("w"))
        //{
        //    characterAnimator.SetTrigger("runTrigger");
        //}
        //else
        //{
        //    characterAnimator.SetTrigger("idleTrigger");
        //}
        if (!dead)
        {

            Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
            if (Input.GetKeyDown("space"))
                Rigid.AddForce(transform.up * JumpForce);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "dangerous")
        {
            health -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dangerous")
        {
            health -= 1;
        }
    }
}
