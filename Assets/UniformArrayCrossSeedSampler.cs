using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UniformArrayCrossSeedSampler : MonoBehaviour { 
    List<Vector4> randomVectors;
    List<Vector4> sampleVectors;

    [Range(0, 31)]
    public int ShowSampleIteration = 31;

    // Use this for initialization
    void Start()
    { 
        randomVectors = RandomGenerator.GenerateRandomVectorList(64);
        sampleVectors = RandomGenerator.GenerateRandomVectorList(32);
    }

    void OnDrawGizmos()
    {
        var t = transform;
        Gizmos.color = Color.green;  
        foreach (var vector in randomVectors)
        { 
            Gizmos.DrawLine(
                t.TransformPoint(Vector3.zero),
                t.TransformPoint(Vector3.Cross(sampleVectors[ShowSampleIteration], vector).normalized)
            );
        }
    }
}
