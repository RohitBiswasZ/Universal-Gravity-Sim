using System;
using Unity.Collections;
using UnityEngine;

public struct PlanetMeshData : IDisposable
{
    public NativeList<Vector3> vertex;
    public NativeList<int> triangles;

    public PlanetMeshData(Allocator allocator)
    {
        vertex = new NativeList<Vector3>(allocator);
        triangles = new NativeList<int>(allocator);
    }

    public void ClonePlanetMeshData(PlanetMeshData meshData, Allocator allocator)
    {
        vertex = new NativeList<Vector3>(allocator);
        triangles = new NativeList<int>(allocator);
        
        vertex.AddRange(meshData.vertex.AsArray());
        triangles.AddRange(meshData.triangles.AsArray());
    }

    public void AddPlanetMeshData(PlanetMeshData meshData)
    {
        for (int i = 0; i < meshData.triangles.Length; i++) triangles.Add(meshData.triangles[i] + vertex.Length);
        vertex.AddRange(meshData.vertex.AsArray());
    }

    public void Dispose()
    {
        if (vertex.IsCreated) vertex.Dispose();
        if (triangles.IsCreated) triangles.Dispose();
    }
}