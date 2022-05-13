using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapons;
    public GameObject cameraa;
    public int curWeapon = 0;
    public int[] weaponsObtained;
    public GameObject[] allIcons; 
    int prev = 0;
    public int scale;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //(int)(curWeapon + Input.mouseScrollDelta.y* scale)%weaponsObtained.Length
        curWeapon = Mathf.Abs(curWeapon + (int)Input.mouseScrollDelta.y)%weaponsObtained.Length;
        if (curWeapon != prev)
            equipWeapon(curWeapon);
        
    }

    void equipWeapon(int weaponNum)
    {
        Debug.Log(weaponNum);
        weapons[weaponsObtained[prev]].SetActive(false);
        weapons[weaponsObtained[weaponNum]].SetActive(true);
        prev = weaponNum;
    }

    void updateIcons()
    {

    }
}
