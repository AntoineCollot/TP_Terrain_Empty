using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeshFromHeightMap : MonoBehaviour
{
    public Texture2D heightMap = null;
    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        Generate();
    }

    public void GetRandomMap()
    {
        
    }

    public void Generate()
    {
        GetComponent<MeshFilter>().mesh = GenerateMesh();
    }

    Mesh GenerateMesh()
    {
        if (heightMap == null)
            GetRandomMap();

        if (heightMap.width > 256 || heightMap.height > 256)
            Debug.LogWarning("HeightMap is too big, it may cause issues");

        Vector3[] points = GeneratePointsFromHeightMap(heightMap.width, heightMap.height, heightMap);
        int[] triangles = GenerateTriangles(heightMap.width, heightMap.height);
        Vector2[] uvs = GenerateUVs(heightMap.width, heightMap.height);

        mesh.vertices = points;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        return mesh;
    }

    Vector3[] GeneratePointsFromHeightMap(int width, int height, Texture2D heightMap)
    {
        return null;
    }

    int[] GenerateTriangles(int width, int height)
    {
        return null;
    }

    Vector2[] GenerateUVs(int width, int height)
    {
        //UVs are in 2D
        Vector2[] uvs = new Vector2[width * height];

        //Map the UVs left to right, bottom to top
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Get the id in the 1D array.
                //The ids are from left to right, bottom to top.
                int id = y * width + x;

                uvs[id] = new Vector2(x / (float)width, y / (float)height);
            }
        }

        return uvs;
    }
}
