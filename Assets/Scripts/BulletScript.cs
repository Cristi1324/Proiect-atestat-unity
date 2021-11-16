using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bulletobj;
    public int damage;
    public float lifetime;

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision col)
    {
        GameObject Objecthit = col.gameObject;
        HealthScript applydamage = Objecthit.GetComponent<HealthScript>();
        if(applydamage!=null)
        {
            applydamage.Health -=damage;
            if(applydamage.Health<=0)
            {
                //Destroy(Objecthit);
            }
            //Debug.Log("that's a lot of damage");
        }
        Destroy(Bulletobj);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
    private void FixedUpdate() {
        lifetime -= Time.deltaTime;
        if(lifetime<0) Destroy(Bulletobj);
    }
}
