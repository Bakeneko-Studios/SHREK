using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donkey : MonoBehaviour
{
    public float shootRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootWeapon());
    }

    IEnumerator shootWeapon()
    {
        yield return new WaitForSeconds(shootRate);
        this.gameObject.GetComponent<Weapon>().Launch();
        StartCoroutine(shootWeapon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
