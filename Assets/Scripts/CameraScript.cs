using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float zoom;
    public int maxsize=20;
    public int minsize=2;
    public int mapsize=500;
    public int savedsize;
    public bool mapmode =false;
    Camera mainCamera;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            savedsize=(int)mainCamera.orthographicSize;
            mainCamera.orthographicSize=mapsize;
            mapmode=true;
            //GameObject.Find("Player Indicator").GetComponent<MeshRenderer>().enabled=false;
        }
        if(Input.GetKeyUp(KeyCode.M))
        {
            mainCamera.orthographicSize=savedsize;
            mapmode=false;
        }
        if(mapmode==false){
            zoom=Input.GetAxis("Mouse ScrollWheel");
        if(zoom!=0)
        {
            mainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")*(mainCamera.orthographicSize);
            //Debug.Log("zooming");
        }
        if(mainCamera.orthographicSize>maxsize) mainCamera.orthographicSize=maxsize;
        else if(mainCamera.orthographicSize<minsize) mainCamera.orthographicSize=minsize;
        }
    }
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
    }
}
