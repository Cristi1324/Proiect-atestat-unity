using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth=10;
    public int Health;
    public GameObject GO;
    void Start()
    {
        Health=MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
            if(GO.tag=="Player")
            {
                FindObjectOfType<PausedMenuScript>().GameOver();
            }else
            Destroy(GO);
        }
    }
}
