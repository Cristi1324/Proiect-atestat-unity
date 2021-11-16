using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    // Start is called before the first frame update

    const float G = 667f;
    public Rigidbody rb;
    float atrforce;
    Attractor MainAttractor;
    public float relativevelocity;
    public float orbitalvelocity;
    public float escapevelocity;
    private bool inted = false;

    // Update is called once per frame

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float MaxAtrforce=0;
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor attractor in attractors)
        {
            Attract(attractor);
            {
                if(atrforce>MaxAtrforce)
                {
                    MaxAtrforce=atrforce;
                    MainAttractor = attractor;
                }
            }
        }
        relativevelocity = (rb.velocity - MainAttractor.rb.velocity).magnitude;
        orbitalvelocity = Mathf.Sqrt(G*MainAttractor.rb.mass/Vector3.Distance(MainAttractor.rb.position, transform.position));
        escapevelocity = Mathf.Sqrt(2*G*MainAttractor.rb.mass/Vector3.Distance(MainAttractor.rb.position, transform.position));
        if(rb.tag=="Player"&&relativevelocity>0.1f)
        {
            relativevelocity = (rb.velocity - MainAttractor.rb.velocity).magnitude;
            //Debug.Log(MainAttractor.rb.tag);
            //Debug.Log("relative velocity:"+relativevelocity);
            PlayerController PC = gameObject.GetComponent<PlayerController>();
            PC.relativeVelocity= relativevelocity;
            PC.orbitalVelocity = orbitalvelocity;
            PC.escapeVelocity = escapevelocity;
            if(!rb.GetComponent<PlayerController>().accelerate&&rb.GetComponent<PlayerController>().inertialdampening)rb.velocity = rb.velocity - (-MainAttractor.rb.velocity+rb.velocity)*(0.1f);
        }
        else if(rb.tag=="Enemy"&&inted==false)
        {
            inted=true;
            rb.velocity=MainAttractor.rb.velocity;
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        float forceMagnitude = G*(rb.mass * rbToAttract.mass) / Mathf.Pow(distance,2);
        Vector3 force = direction.normalized * forceMagnitude;
        if(force.magnitude>0)
        rbToAttract.AddForce(force);
        atrforce=force.magnitude;
    }
}
