using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{ 
    public Vector3 meshPosition;
    
    MeshData meshData;
    public void Start()
    {
        meshData = new MeshData();
        meshData.CreateSphear(meshPosition, 10, 5);
        Debug.Log(meshData.vertex.Count);
    }
    

    public void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            
            meshData = new MeshData();
            meshData.CreateSphear(meshPosition, 10, 5);
            
            for (int i = 0; i < meshData.vertex.Count; i++)
            {
                Vector3 vertex = meshData.vertex[i];
                Gizmos.DrawSphere(vertex, 0.1f);
            }
        }
    }
}

public class MeshData
{
    public List<Vector3> vertex;
    public List<int> triangles;

    public MeshData()
    {
        vertex = new List<Vector3>();
        triangles = new List<int>();
    }
    
    public Vector3 normalizeV3(Vector3 coordinate, Vector3 origin)
    {
        float distance = Vector3.Distance(origin, coordinate);
        Vector3 direction = coordinate - origin;
        Vector3 normal = direction / distance;
        return normal;
    }

    public void CreateFrontFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int y = 0; y <= resolution; y++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, y * percentPosition, radius) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }
    
    public void CreateBackFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int y = 0; y <= resolution; y++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, y * percentPosition, 0) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }
    
    public void CreateLeftFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int y = 0; y <= resolution; y++)
        for (int z = 0; z <= resolution; z++)
        {
            Vector3 position = new Vector3(0, y * percentPosition, z * percentPosition) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }
    
    public void CreateRightFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int y = 0; y <= resolution; y++)
        for (int z = 0; z <= resolution; z++)
        {
            Vector3 position = new Vector3(radius, y * percentPosition, z * percentPosition) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }
    
    public void CreateTopFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int z = 0; z <= resolution; z++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, radius, z * percentPosition) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }
    
    public void CreateDownFace(Vector3 offset, int resolution, int radius)
    {
        float percentPosition = (float)radius / resolution;
        
        for (int z = 0; z <= resolution; z++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, 0, z * percentPosition) + offset;
            Vector3 center = new Vector3(radius / 2f, radius / 2f, radius / 2f) + offset;
            Vector3 sphearPointPosition = normalizeV3(position, center) * radius + center;
            vertex.Add(sphearPointPosition);
        }
    }


    
    public void CreateSphear(Vector3 offset, int resolution, int radius)
    {
        CreateFrontFace(offset, resolution, radius);
        CreateBackFace(offset, resolution, radius);
        CreateLeftFace(offset, resolution, radius);
        CreateRightFace(offset, resolution, radius);
        CreateTopFace(offset, resolution, radius);
        CreateDownFace(offset, resolution, radius);
    }
}
