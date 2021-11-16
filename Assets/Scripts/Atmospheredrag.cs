using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmospheredrag : MonoBehaviour
{
    public float drag;
    public float bulletdrag;

    public Rigidbody Planetrb;

    void OnTriggerStay(Collider col) {
        if(col.attachedRigidbody.GetComponent<Rigidbody>() != null)
        if(Mathf.Abs(Planetrb.velocity.magnitude-col.attachedRigidbody.velocity.magnitude)>1)
        if(col.gameObject.tag!="Planet")
        {
            //Debug.Log("ApplyDrag"+col.gameObject.tag);
            if(col.gameObject.tag=="Bullet")
            {
                col.attachedRigidbody.velocity = col.attachedRigidbody.velocity - (-Planetrb.velocity+col.attachedRigidbody.velocity)*(bulletdrag);
            }else
            {
                col.attachedRigidbody.velocity = col.attachedRigidbody.velocity - (-Planetrb.velocity+col.attachedRigidbody.velocity)*(drag);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletdrag = drag/5;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate() {

    }
}
