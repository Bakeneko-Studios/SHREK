using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeGirl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator characterAnimator;
    public GameObject armature;
    public bool dead = false;
    public bool run = true;
    public float speed = 3;

    public GameObject playerWeapons;
    void Start()
    {
        if (run)
            characterAnimator.SetTrigger("runTrigger");
    }
    public void ChangeHealth(float amount)
    {
        // Change the health by the amount specified in the amount variable
        die();
    }
    // Update is called once per frame
    void Update()
    {
       if (run)
        {
            var eular = transform.eulerAngles;
            eular.y = Random.Range(0, 360);
            this.transform.eulerAngles = eular;
            //transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    void die()
    {
        characterAnimator.enabled = false;
        armature.SetActive(true);
        dead = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "redWall")
        {
            die();
        }

        if (dead && collision.collider.tag == "Player")
        {
            playerWeapons.GetComponent<WeaponSystem>().AddWeapon(10);
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dangerous")
        {
            die();
        }
    }

}
