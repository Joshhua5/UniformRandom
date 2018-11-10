using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UniformArrayCrossSeedGPU : MonoBehaviour {
    Material material;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
          
        material.SetTexture("_Random", RandomGenerator.GenerateRandomTexture2D(256, 256));
        material.SetVectorArray("_RandomArray", RandomGenerator.GenerateRandomVectorList(8));
    } 
}
