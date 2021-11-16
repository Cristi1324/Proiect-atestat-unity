using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointtoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Gunjoint;
    public GameObject Turret;
    public int maxDistance=10;
    public int rotationSpeed=10;
    private float angle;
    public RaycastHit hit;
    private Quaternion targetRotation;
    private Vector2 vectorTarget;
    private GameObject Target;
    private Rigidbody Targetrb;
    private float Turretangle;
    public bool fire=false;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        if(Target!=null) Targetrb=Target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        if(Targetrb!=null)
        {
            vectorTarget = Targetrb.position-transform.position;
            if(vectorTarget.magnitude<maxDistance&&Target)
            {
                angle = Mathf.Atan2(vectorTarget.y,vectorTarget.x)*Mathf.Rad2Deg;
                Turretangle = Turret.transform.forward.z*Mathf.Rad2Deg;
                targetRotation = Quaternion.AngleAxis(angle-90,Vector3.forward);
                if(Gunjoint.transform.forward.z>-90&&Gunjoint.transform.forward.z<90)
                    Gunjoint.transform.rotation= Quaternion.Slerp(Gunjoint.transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
                //Debug.Log(Gunjoint.transform.rotation.z+Turret.name);
            }
        }
    }
}
