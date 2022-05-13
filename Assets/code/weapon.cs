using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public GameObject shootpoint;
    public float shootForce = 100;
    public GameObject projectile;
    public bool isProjectile = false;
    public int respawnTime = 5;
    public GameObject showingObject;
    public bool respawned = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        showingObject.SetActive(true);
        respawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && respawned)
        {
            GameObject bullet = Instantiate(projectile, shootpoint.transform.position, projectile.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(shootpoint.transform.forward * shootForce);
            if (isProjectile)
            {
                showingObject.SetActive(false);
                respawned = false;
                StartCoroutine(respawn());
            }
            
        }
    }
}
