using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 10_000 10000
// 100_000 100000
// 1_000_000 1000000
// 10_000_000 10000000
// 67_107_840 67107840 

public class GPU : MonoBehaviour
{
    Vector3[] array;
    ComputeBuffer computeBuffer;
    [SerializeField] ComputeShader computeShader;
    [SerializeField, Range(1, 67107840)] int arraySize;

    int kernelHandle;
    uint threadGroupSizeX;
    int dispatchSize;

    void Initialize() {
        array = new Vector3[arraySize]; // Allocate memory for the array on the CPU
        kernelHandle = computeShader.FindKernel("CalculateSineWave"); // Get a kernel handle for the compute shader's CalculateSineWave function
        computeBuffer = new ComputeBuffer(arraySize, sizeof(float) * 3); // Allocate memory for the array on the GPU
        computeShader.SetBuffer(kernelHandle, "waveBuffer", computeBuffer); // Bind the compute buffer to the kernel handle
        computeBuffer.SetData(array); // Set the data of the CPU side array to the GPU side buffer (array), even though the data is just mock data
        computeShader.GetKernelThreadGroupSizes(kernelHandle, out threadGroupSizeX, out _, out _); // Retrieve the threadgroup size of the kernel in the compute shader 
        dispatchSize = Mathf.CeilToInt((float)arraySize / threadGroupSizeX); // Calculate the number of threadgroups needed
        computeShader.SetInt("waveBufferLength", arraySize); // Set the 'waveBufferLength' int on the compute shader to the array's length
    }

    void SineWave() {
        computeShader.SetFloat("time", Time.time); // Set the 'time' float on the compute shader to the time since startup of the application
        computeShader.Dispatch(kernelHandle, dispatchSize, 1, 1); // Dispatch and run the shader with the correct dispatchSize
    }

    void Start() {
        Initialize(); // Runs once at the start
    }

    void Update() {
        SineWave(); // Runs as many times as possible
    }

    void OnDestroy() {
        computeBuffer?.Dispose(); // Deallocate memory for the GPU buffer
    }
}
