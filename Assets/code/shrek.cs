using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrek : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public int health1 = 1000;
    public int health2 = 200;
    public float diff1;
    public float diff2;
    public GameObject healthbar1;
    public GameObject healthbar2;
    public GameObject removeStuff;
    public GameObject explosion;
    public int lives = 2;
    public GameObject moreStuff;
    public GameObject victoryPage;
    public GameObject body;
    void Start()
    {
        diff1 = healthbar1.transform.localScale.x / health1;
        diff2 = healthbar2.transform.localScale.x / health2;

    }
    IEnumerator turn()
    {
        this.transform.LookAt(player.transform);
        yield return new WaitForSeconds(2);
        StartCoroutine(turn());
    }

    IEnumerator win()
    {
        yield return new WaitForSeconds(3);
        victoryPage.SetActive(true);
    }
    public void ChangeHealth(float amount)
    {
        // Change the health by the amount specified in the amount variable
        if (lives == 2)
        {
            health2 += (int)amount;

            // If the health runs out, then Die.
            if (health2 <= 0)
                die2();

            healthbar2.transform.localScale = new Vector3(healthbar2.transform.localScale.x + ((int)amount * diff2),
                                                             healthbar2.transform.localScale.y,
                                                             healthbar2.transform.localScale.z);
        }

        if (lives == 1)
        {
            health1 += (int)amount;

            // If the health runs out, then Die.
            if (health1 <= 0)
                die1();

            healthbar1.transform.localScale = new Vector3(healthbar1.transform.localScale.x + ((int)amount * diff1),
                                                             healthbar1.transform.localScale.y,
                                                             healthbar1.transform.localScale.z);
        }

    }

    void die2()
    {
        healthbar2.SetActive(false);
        lives = 1;
        moreStuff.SetActive(true);
        removeStuff.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);
    }

    void die1()
    {
        healthbar1.SetActive(false);
        body.SetActive(false);
        Instantiate(explosion, transform.position, transform.rotation);
        StartCoroutine(win());
    }
    // Update is called once per frame
    void Update()
    {

        this.transform.LookAt(player.transform);
        //this.transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "redWall")
        {
            if (lives == 2)
            {
                int damage = collision.collider.GetComponent<bullet>().dmg;
                health2 -= damage;
                if (health2 <= 0)
                {
                    die2();
                }
                healthbar2.transform.localScale = new Vector3(healthbar2.transform.localScale.x - (damage * diff2),
                                                             healthbar2.transform.localScale.y,
                                                             healthbar2.transform.localScale.z);
            }

            if (lives == 1)
            {
                int damage = collision.collider.GetComponent<bullet>().dmg;
                health1 -= damage;
                if (health1 <= 0)
                {
                    die1();
                }
                healthbar1.transform.localScale = new Vector3(healthbar1.transform.localScale.x - (damage * diff1),
                                                             healthbar1.transform.localScale.y,
                                                             healthbar1.transform.localScale.z);
            }
            
        }
    }
}
