using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    // Start is called before the first frame update
    private int timewarp = 1;
    void Start()
    {
        
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown((KeyCode.Period))&&timewarp<5)
        {
            timewarp++;
        }
        if(Input.GetKeyDown((KeyCode.Comma))&&timewarp>1)
        {
            timewarp--;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch(timewarp)
        {
            case 1:
            Time.timeScale=1;
            break;
            case 2:
            Time.timeScale=5;
            break;
            case 3:
            Time.timeScale=10;
            break;
            case 4:
            Time.timeScale=20;
            break;
            case 5:
            Time.timeScale=50;
            break;
        }
    }
}
