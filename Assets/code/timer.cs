using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timerText;
    float time = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float seconds = time % 60;
        timerText.GetComponent<TextMeshProUGUI>().text = ((int)seconds).ToString();
    }
}
