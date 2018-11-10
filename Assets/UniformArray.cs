using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UniformArray : MonoBehaviour {  
    List<Vector4> randomVectors;

	// Use this for initialization
	void Start () { 
        randomVectors = RandomGenerator.GenerateRandomVectorList(256);
	}
	 
    void OnDrawGizmos()
    {
        var t = transform;
        Gizmos.color = Color.green;
        foreach (var vector in randomVectors) {
            Gizmos.DrawLine(t.TransformPoint(Vector3.zero), t.TransformPoint(vector));
        }    
    }
}
