using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PoiterSprite;
    private float mindistance;
    private float distance;
    private GameObject savedGO;
    private Vector3 savedDirection;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mindistance=1000;
        GameObject[] enemies = FindObjectsOfType<GameObject>();
        foreach(GameObject enemy in enemies)
        {
            if(enemy.tag=="Enemy")
            {
                Vector3 direction = transform.position - enemy.transform.position;
                distance =direction.magnitude;
                if(distance<mindistance) 
                {
                    mindistance=distance;
                    savedGO=enemy;
                    savedDirection=direction;
                }
            }
        }
        PoiterSprite.transform.position=transform.position - savedDirection.normalized*2;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward,-savedDirection);
        PoiterSprite.transform.rotation=rotation;
    }
}
