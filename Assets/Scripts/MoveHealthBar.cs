using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HealthBar;
    public GameObject HealthTarget;
    public Camera cam;
    public Vector3 Offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthTarget!=null)
        {
            HealthBar.transform.position = new Vector3(HealthTarget.transform.position.x+Offset.x,HealthTarget.transform.position.y+Offset.y,HealthTarget.transform.position.z+Offset.z-10);
            HealthBar.transform.localScale = new Vector3((4*(float)HealthTarget.gameObject.GetComponent<HealthScript>().Health/(float)HealthTarget.gameObject.GetComponent<HealthScript>().MaxHealth),0.4f,1);
            HealthBar.GetComponent<SpriteRenderer>().material.color=new Color(
                1-(float)HealthTarget.gameObject.GetComponent<HealthScript>().Health/(float)HealthTarget.gameObject.GetComponent<HealthScript>().MaxHealth,
            (float)HealthTarget.gameObject.GetComponent<HealthScript>().Health/(float)HealthTarget.gameObject.GetComponent<HealthScript>().MaxHealth,
            0,1);
        }
        else Destroy(HealthBar);
    }
}