using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 10_000 10000
// 100_000 100000
// 1_000_000 1000000
// 10_000_000 10000000
// 67_107_840 67107840 

public class CPU : MonoBehaviour
{
    Vector3[] array;
    [SerializeField, Range(1, 67107840)] int arraySize;
    private float amplitude = 1.1f; // Height of the wave
    private float frequency = 1.2f; // Number of waves in a given space
    private float speed = 1.3f; // Controls wave movement over time

    void Initialize() {
        array = new Vector3[arraySize]; // Allocate memory for the array on the CPU
    }

    void SineWave() {
        // Iterate over the array and do some mock calculations
        for (int i = 0; i < arraySize; i++) {
            Vector3 arrayItem = array[i]; // Retrieve the data point (a float3) from the array
            float test = arrayItem.x + arrayItem.y + arrayItem.z; // Do some extra calculation with the data to make it heavier to compute
            
            // Put some data back into the compute buffer and do simple calculations to make it heavier
            array[i].x = test * 0.51f;
            array[i].y = amplitude * Mathf.Sin(frequency * i * 0.1f + Time.time * speed) + test;
            array[i].x = test * 0.253f;
        }
    }

    void Start() {
        Initialize(); // Runs once at the start
    }

    void Update() {
        SineWave(); // Runs as many times as possible
    }
}
