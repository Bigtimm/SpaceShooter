using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeed : MonoBehaviour
{
    private float speed;
    private bool called;
    private ParticleSystem ps;
    public float hSliderValue = 1.0f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (Done_GameController.winGame == true && called == false)
        {
            called = true;
            hSliderValue = 10.0f;
        }
    }
}
