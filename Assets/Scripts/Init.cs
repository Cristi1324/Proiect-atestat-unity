using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update

    const float G = 667f;
    public float verticalspeed;
    public float distanceFromBody;
    public Transform parentPlanet;
    public Rigidbody parentPlanetmass=null;
    public Rigidbody rb;
    void Start()
    {
        distanceFromBody = Vector3.Distance(parentPlanet.position, transform.position);
        verticalspeed += Mathf.Sqrt(G*parentPlanetmass.mass/distanceFromBody);
        rb.velocity=new Vector3(0,verticalspeed,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
