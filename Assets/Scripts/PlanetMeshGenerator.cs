using Unity.Collections;
using UnityEngine;

public class PlanetMeshGenerator : MonoBehaviour
{
    public PlanetMeshData FrontFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        
        float percentPosition = (float)(radius) / resolution;
        
        for (int y = 0; y <= resolution; y++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, y * percentPosition, radius) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);

            if (x < resolution && y < resolution)
            {
                int i = x + y * (resolution + 1);
                
                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i);

                meshData.triangles.Add(i + resolution + 2);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);
            }
        }
        
        return meshData;
    }

    public PlanetMeshData BackFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        float percentPosition = (float)(radius) / resolution;

        for (int x = 0; x <= resolution; x++)
        for (int y = 0; y <= resolution; y++)
        {
            Vector3 position = new Vector3(x * percentPosition, y * percentPosition, 0) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);
            
            if (x < resolution && y < resolution)
            {
                int i = x + y * (resolution + 1);
                
                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i);

                meshData.triangles.Add(i + resolution + 2);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);

            }
        }
        
        return meshData;
    }
    
    public PlanetMeshData RightFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        float percentPosition = (float)(radius) / resolution;

        for (int y = 0; y <= resolution; y++)
        for (int z = 0; z <= resolution; z++)
        {
            Vector3 position = new Vector3(radius, y * percentPosition, z * percentPosition) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);
            
            if (z < resolution && y < resolution)
            {
                int i = z + y * (resolution + 1);
                
                meshData.triangles.Add(i);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);

                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + resolution + 2);
            }
        }
        
        return meshData;
    }
    
    public PlanetMeshData LeftFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        float percentPosition = (float)(radius) / resolution;

        for (int y = 0; y <= resolution; y++)
        for (int z = 0; z <= resolution; z++)
        {
            Vector3 position = new Vector3(0, y * percentPosition, z * percentPosition) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);
            
            if (z < resolution && y < resolution)
            {
                int i = z + y * (resolution + 1);
                
                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i);

                meshData.triangles.Add(i + resolution + 2);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);
            }
        }
        
        return meshData;
    }
    
    public PlanetMeshData TopFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        float percentPosition = (float)(radius) / resolution;

        for (int z = 0; z <= resolution; z++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, radius, z * percentPosition) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);
            
            if (z < resolution && x < resolution)
            {
                int i = z + x * (resolution + 1);
                
                meshData.triangles.Add(i);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);

                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + resolution + 2);
            }
        }
        
        return meshData;
    }
    
    public PlanetMeshData DownFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        float percentPosition = (float)(radius) / resolution;

        for (int z = 0; z <= resolution; z++)
        for (int x = 0; x <= resolution; x++)
        {
            Vector3 position = new Vector3(x * percentPosition, 0, z * percentPosition) - offset;
            Vector3 normalize = NormalizeCordinate(position, ((Vector3.one * radius) / 2) + offset) * radius;
            meshData.vertex.Add(normalize);
            
            if (z < resolution && x < resolution)
            {
                int i = z + x * (resolution + 1);
                
                meshData.triangles.Add(i + 1);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i);

                meshData.triangles.Add(i + resolution + 2);
                meshData.triangles.Add(i + resolution + 1);
                meshData.triangles.Add(i + 1);
            }
        }
        
        return meshData;
    }

    public PlanetMeshData CreateCubicFace(int resolution, int radius, Vector3 offset)
    {
        PlanetMeshData frontFaceMeshData = FrontFace(resolution, radius, offset);
        PlanetMeshData backFaceMeshData = BackFace(resolution, radius, offset);
        PlanetMeshData rightFaceMeshData = RightFace(resolution, radius, offset);
        PlanetMeshData leftFaceMeshData = LeftFace(resolution, radius, offset);
        PlanetMeshData topFaceMeshData = TopFace(resolution, radius, offset);
        PlanetMeshData downFaceMeshData = DownFace(resolution, radius, offset);

        PlanetMeshData meshData = new PlanetMeshData(Allocator.Temp);
        
        meshData.AddPlanetMeshData(frontFaceMeshData);
        meshData.AddPlanetMeshData(backFaceMeshData);
        meshData.AddPlanetMeshData(rightFaceMeshData);
        meshData.AddPlanetMeshData(leftFaceMeshData);
        meshData.AddPlanetMeshData(topFaceMeshData);
        meshData.AddPlanetMeshData(downFaceMeshData);
        
        frontFaceMeshData.Dispose();
        backFaceMeshData.Dispose();
        rightFaceMeshData.Dispose();
        leftFaceMeshData.Dispose();
        topFaceMeshData.Dispose();
        downFaceMeshData.Dispose();
        
        return meshData;
    }

    Vector3 NormalizeCordinate(Vector3 cordinate, Vector3 center)
    {
        float distance = Vector3.Distance(center, cordinate);
        Vector3 direction = cordinate - center;
        Vector3 normal = direction / distance;
        return normal;
    }
}
