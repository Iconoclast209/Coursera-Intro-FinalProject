using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text timeDisplay;

    float elapsedTime = 0f;
    bool shipIsActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shipIsActive)
        {
            elapsedTime += Time.deltaTime;
            timeDisplay.text = elapsedTime.ToString();
        }
        
    }

    public void StopTimeDisplay()
    {
        shipIsActive = false;
    }
}
