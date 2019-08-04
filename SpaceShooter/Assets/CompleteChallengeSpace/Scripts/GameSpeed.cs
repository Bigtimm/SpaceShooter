using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    private float speed;
    private bool called;
    private ParticleSystem ps;
    public float hSliderValue;
    public Done_GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gameController.winGame == true && called == false)
        {
            called = true;
            hSliderValue = 40.0f;
        }




    }
}
