using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg;
    public int timeToDissapear = 10;
    IEnumerator die()
    {
        yield return new WaitForSeconds(timeToDissapear);
        Destroy(this.gameObject);
    }

    void Start()
    {
        StartCoroutine(die());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
