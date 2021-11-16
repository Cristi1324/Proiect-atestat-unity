using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Indicator;
    public GameObject Target;
    void Start()
    {
        GameObject HeathBar = Instantiate(Indicator);
        HeathBar.GetComponent<MoveHealthBar>().HealthTarget=Target;
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }
}
