using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator
{ 
    public static void UniformRandomOnSphere(out float x, out float y, out float z)
    {
        // http://corysimon.github.io/articles/uniformdistn-on-sphere/
        // These random values aren't uniform, but we can get that by rejecting values that fall outside of a sphere within our cube of random values [-1, 1]^3  
        x = Random.value * 2f - 1f;
        y = Random.value * 2f - 1f;
        z = Random.value * 2f - 1f;

        // http://corysimon.github.io/articles/uniformdistn-on-sphere/
        // These random values aren't uniform, but we can get that by rejecting values that fall outside of a sphere within our cube of random values [-1, 1]^3 
        float magnitude = Mathf.Sqrt((x * x) + (y * y) + (z * z));
        if (magnitude >= 1)
            UniformRandomOnSphere(out x, out y, out z);
        else
        {
            // Normalize
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
        }
    }

    public static Texture2D GenerateRandomTexture2D(int width, int height)
    {
        var texture = new Texture2D(width, height, TextureFormat.RGBAHalf, false, true); 
        var scratchColor = new Color(0, 0, 0, 1);
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                UniformRandomOnSphere(out scratchColor.r, out scratchColor.g, out scratchColor.b);
                texture.SetPixel(x, y, scratchColor);
            }
        }
        texture.Apply();
        return texture;
    }

    public static List<Vector4> GenerateRandomVectorList(int size)
    {
        var list = new List<Vector4>(size);
        float x, y, z;
        for (int i = 0; i < size; ++i)
        {
            UniformRandomOnSphere(out x, out y, out z);
            list.Add(new Vector4(x, y, z, 1));
        }
        return list;
    } 
}
