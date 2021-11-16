using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textBox;
    float relativev;
    float orbitalv;
    float escapev;
    int playerHealth;
    public GameObject player;
    void Start()
    {
        textBox = GetComponent<Text>();
        textBox.text="test";
    }

    // Update is called once per frame
    void Update()
    {
        relativev = player.GetComponent<PlayerController>().relativeVelocity;
        orbitalv = player.GetComponent<PlayerController>().orbitalVelocity;
        escapev = player.GetComponent<PlayerController>().escapeVelocity;
        playerHealth = player.GetComponent<HealthScript>().Health;
        textBox.text = "Speed: "+ ((int)(relativev*10)).ToString();//+"\n"+"orbital velocity:   "+orbitalv.ToString()+"\n"+"escape velocity: "+escapev+"\n"+"Health:"+playerHealth;
        textBox.text += "\n"+"Inertial dampening: ";
        if(player.GetComponent<PlayerController>().inertialdampening) textBox.text +="on";
        else textBox.text +="off";
    }
}
