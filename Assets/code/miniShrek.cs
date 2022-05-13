using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniShrek : MonoBehaviour
{
    public GameObject explosion;
    public GameObject[] weapons;
    public int speed = 20;
    public bool spawnWeapon = true;
    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {

        if (move)
            StartCoroutine(rotateRandomly());
    }

    IEnumerator rotateRandomly()
    {
        var eular = transform.eulerAngles;
        eular.y = Random.Range(0, 360);
        this.transform.eulerAngles = eular;
        yield return new WaitForSeconds(2);
        StartCoroutine(rotateRandomly());
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void ChangeHealth(float amount)
    {
        Die();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "redWall")
        {
            Die();
        }
    }

    public void Die()
	{
		// This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
		

		Instantiate(explosion, transform.position, transform.rotation);
        if (spawnWeapon)
            Instantiate(weapons[Random.Range(0,weapons.Length-1)], transform.position, weapons[Random.Range(0, weapons.Length - 1)].transform.rotation);
        // Remove this GameObject from the scene
        Destroy(gameObject);
	}
}
