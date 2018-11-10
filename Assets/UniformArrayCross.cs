using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UniformArrayCross : MonoBehaviour {
    Vector4 seed = new Vector4(0, 0, 0, 1);
    List<Vector4> randomVectors;

    // Use this for initialization
    void Start()
    {
        RandomGenerator.UniformRandomOnSphere(out seed.x, out seed.y, out seed.z);
        randomVectors = RandomGenerator.GenerateRandomVectorList(256);
    }

    void OnDrawGizmos()
    {
        var t = transform;
        Gizmos.color = Color.green;
        foreach (var vector in randomVectors)
        {
            Gizmos.DrawLine(
                t.TransformPoint(Vector3.zero),
                t.TransformPoint(Vector3.Cross(vector, seed).normalized)
            );
        }
    }
}
