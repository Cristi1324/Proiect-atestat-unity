using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform firePoint;
    public Rigidbody fireRb;
    public float cooldown = 5f;
    public float cooldowntimer=0f;
    RaycastHit hit;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(cooldowntimer>0)
        {
            cooldowntimer -= Time.deltaTime;
            //Debug.Log("Realoading");
        }    
        else
        {
            if(firePoint.tag!="Player")
            {
                int layerMask = 8;
                layerMask = ~layerMask;
                Physics.Raycast(firePoint.position,firePoint.TransformDirection(Vector3.up),out hit,50,layerMask);
                //Debug.DrawRay(firePoint.position,firePoint.TransformDirection(Vector3.forward)*hit.distance,Color.red);
                //Debug.Log(hit.distance);
                if(hit.rigidbody)
                if(hit.rigidbody.gameObject.tag=="Player")
                {
                    //Debug.DrawRay(firePoint.position,firePoint.TransformDirection(Vector3.forward)*hit.distance,Color.red);
                    GameObject newBullet = Instantiate(bullet,firePoint.position,firePoint.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity = speed*firePoint.up + fireRb.velocity;
                    newBullet.GetComponent<BulletScript>().damage =2;
                    newBullet.GetComponent<BulletScript>().lifetime =10;
                    cooldowntimer=cooldown;
                }
            }
            if(firePoint.tag=="PlayerPart")
            {
                if(fireRb.gameObject.GetComponent<PlayerController>().fire==true)
                {
                    GameObject newBullet = Instantiate(bullet,firePoint.position,firePoint.rotation) as GameObject;
                     newBullet.GetComponent<Rigidbody>().velocity = speed*firePoint.up + fireRb.velocity;
                     newBullet.GetComponent<BulletScript>().damage =2;
                    newBullet.GetComponent<BulletScript>().lifetime =10;
                    cooldowntimer=cooldown;
                }
            }
        }
    }
}
