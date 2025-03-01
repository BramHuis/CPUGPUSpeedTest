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

    void InitializeArray() {
        array = new Vector3[arraySize];
    }

    void SineWave() {
        for (int i = 0; i < arraySize; i++) {
            
            Vector3 arrayItem = array[i];
            float test = arrayItem.x + arrayItem.y + arrayItem.z;
            array[i].x = test * 0.51f;
            array[i].y = amplitude * Mathf.Sin(frequency * i * 0.1f + Time.time * speed) + test;
            array[i].x = test * 0.253f;
        }
    }

    void Start() {
        InitializeArray();
    }

    void Update() {
        SineWave();
    }
}
