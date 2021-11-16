using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float forcemultiplier=0.02f;
    private float playeracceleration = 10f;
    private float playerstrafeacceleration = 5f;
    private float playerdecceleration = 5f;
    private float rotationspeed=5f;
    public float relativeVelocity =0f;
    public float orbitalVelocity =0f;
    public float escapeVelocity = 0f;
    public bool accelerate=false;
    private bool accelerateup=false;
    private bool acceleratedown=false;
    private bool accelerateleft=false;
    private bool accelerateright=false;
    public bool shift=false;
    public bool rotatetomouse = true;
    private bool landed=true;
    public bool halflanded=false;
    public bool fire = false;
    public bool inertialdampening = false;
    public Rigidbody Player;
    public Transform firepoint;
    public GameObject Bullet;
    public GameObject Laser;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>

    void OnCollisionEnter(Collision col) 
    {
        if(relativeVelocity>5)
        {
            Player.gameObject.GetComponent<HealthScript>().Health -= (int)relativeVelocity/5;
        }
        if(col.gameObject.tag=="Planet"||col.gameObject.tag=="Moon")
        {
            if(halflanded) 
            {
                landed = true;
                //Debug.Log("Landed");
            }
            else halflanded=true;
        }
        //Debug.Log("Collision"+col.gameObject);
    }
    void OnCollisionExit(Collision col) 
    {
        if(col.gameObject.tag=="Planet"||col.gameObject.tag=="Moon")
        {
            if(halflanded) halflanded = false;
            else landed=false;
        }
    }
    void Awake()
    {
        Player = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!acceleratedown&&!accelerateleft&&!accelerateright&&!accelerateup) accelerate=false;
        else accelerate=true;
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inertialdampening)
                inertialdampening=false;
            else inertialdampening=true;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            accelerateup=true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            accelerateleft=true;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            acceleratedown=true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            accelerateright=true;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
            forcemultiplier /=2;
        }
        if(Input.GetKeyDown(KeyCode.Mouse2)&&rotatetomouse)
        {
            rotatetomouse = false;
        }else if(Input.GetKeyDown(KeyCode.Mouse2)) rotatetomouse = true;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire =true;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            fire =false;;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            accelerateup=false;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            accelerateleft=false;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            acceleratedown=false;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            accelerateright=false;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
            forcemultiplier *=2;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Laser.GetComponent<LaserScript>().LaserisOn=true;
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            Laser.GetComponent<LaserScript>().LaserisOn=false;
        }
    }

    private void FixedUpdate() {
        if(!landed&&rotatetomouse)headCursor();
        if(Player)
        {
            if(accelerateup)
            {
                Player.AddForce(transform.up * playeracceleration*forcemultiplier);
            }
            if(accelerateleft)
            {
                Player.AddForce(-transform.right * playerstrafeacceleration*forcemultiplier);
            }
            if(acceleratedown)
            {
                Player.AddForce(-transform.up * playerdecceleration*forcemultiplier);
            }
            if(accelerateright)
            {
                Player.AddForce(transform.right * playerstrafeacceleration*forcemultiplier);
            }

        }
    }
    void headCursor()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,rotationspeed*Time.deltaTime);
    }
}
