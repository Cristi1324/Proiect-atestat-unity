using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public float parralax =2f;

    public Camera mainCamera;

    void LateUpdate()
    {
        MeshRenderer mr =GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        if(tag=="Background")
        if(mainCamera.orthographicSize>50)
        {
            transform.localScale = new Vector3(500,500,10);
        }else transform.localScale = new Vector3(10,10,10);
        offset.x = transform.position.x/transform.localScale.x/parralax;
        offset.y = transform.position.y/transform.localScale.y/parralax;
        mat.mainTextureOffset=offset;
        
    }
}
