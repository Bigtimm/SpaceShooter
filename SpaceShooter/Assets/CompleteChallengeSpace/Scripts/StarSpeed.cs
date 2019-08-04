using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeed : MonoBehaviour
{
    private bool called;
    private float speed;

    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
   
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {   
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if(Done_GameController.winGame == true && called == false){
            called = true;
            hSliderValue = 50.0f;
        }
    }
}
