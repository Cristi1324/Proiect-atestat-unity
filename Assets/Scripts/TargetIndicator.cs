using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Indicator;
    public GameObject Target;
    public Camera cam;
    public Vector3 Offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Indicator.transform.position = new Vector3(Target.transform.position.x+Offset.x,Target.transform.position.y+Offset.y,Target.transform.position.z+Offset.z);
        if(Indicator.name=="Player Indicator")
        {
            if(cam.orthographicSize>50)
            {
                Indicator.GetComponent<SpriteRenderer>().enabled=true;
            }else{
                Indicator.GetComponent<SpriteRenderer>().enabled=false;
            }
        }
            
    }
}
