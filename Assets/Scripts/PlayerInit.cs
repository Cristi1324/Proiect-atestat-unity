using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    // Start is called before the first frame update
    const float G = 6.6f;
    public float horizontalspeed;
    public float distanceFromBody;
    public Transform parentPlanet;
    public Rigidbody parentPlanetmass;
    public Rigidbody rb;

    bool init =false;
    void Start()
    {
        //distanceFromBody = Vector3.Distance(parentPlanet.position, transform.position);
        //horizontalspeed = Mathf.Sqrt(G*parentPlanetmass.mass/distanceFromBody);
        //rb.velocity=new Vector3(horizontalspeed,parentPlanetmass.velocity.y,0);
        rb.velocity=parentPlanetmass.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
