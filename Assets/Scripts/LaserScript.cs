using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lr;
    public bool LaserisOn = true;
    private float damagetime;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;
        lr.SetPosition(0,transform.position);

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 30, layerMask)&&LaserisOn)
        {
            lr.enabled=true;
            damagetime+=Time.deltaTime;
            if(hit.collider)
            {
                lr.SetPosition(1,hit.point);
                if(hit.collider.tag=="Enemy")
                {
                    if(damagetime>0.05f)
                    {
                        hit.collider.gameObject.GetComponent<HealthScript>().Health -= 1;
                        damagetime=0;
                    }
                }else damagetime=0;
                //Debug.Log(damagetime);
            }
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else if(LaserisOn)
        {
            lr.enabled=true;
            lr.SetPosition(1,transform.position+transform.up*30);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }else lr.enabled=false;
    }
}
