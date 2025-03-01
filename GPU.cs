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
    [SerializeField, Range(1, 67107840)] int arraySize;
    [SerializeField] ComputeShader computeShader;
    int kernelHandle;
    ComputeBuffer computeBuffer;
    uint dispatchGroupSizeX;
    int dispatchSize;

    void Initialize() {
        array = new Vector3[arraySize];
        kernelHandle = computeShader.FindKernel("CalculateSineWave");
        computeBuffer = new ComputeBuffer(arraySize, sizeof(float) * 3);
        computeShader.SetBuffer(kernelHandle, "waveBuffer", computeBuffer);
        computeBuffer.SetData(array);
        computeShader.GetKernelThreadGroupSizes(kernelHandle, out dispatchGroupSizeX, out _, out _);
        dispatchSize = Mathf.CeilToInt((float)arraySize / dispatchGroupSizeX);
    }

    void SineWave() {
        computeShader.SetFloat("time", Time.time);
        computeShader.SetInt("waveBufferLength", arraySize);
        computeShader.Dispatch(kernelHandle, dispatchSize, 1, 1);
    }

    void Start() {
        Initialize();
    }

    void Update() {
        SineWave();
    }

    void OnDestroy() {
        computeBuffer?.Dispose();
    }
}
