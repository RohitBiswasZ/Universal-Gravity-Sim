using Unity.Collections;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetMeshGenerator meshGenerator;
    [Range(1, 103)] public int resolution;
    public Color baseColor;
    public PlanetMeshData meshData;

    public void Start()
    {
        meshGenerator = GetComponent<PlanetMeshGenerator>();
        
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = new Material(Shader.Find("Unlit/PlanetShader"));
        string colorId = "_Color";
        material.SetColor(colorId, baseColor);
        meshRenderer.material = material;
        
        meshData = new PlanetMeshData(Allocator.Persistent);
        PlanetMeshData frontMeshData = meshGenerator.CreateCubicFace(resolution, 5, Vector3.zero);

        meshData.ClonePlanetMeshData(frontMeshData, Allocator.Persistent);
        
        Debug.Log("Cube Mesh Data : " + frontMeshData.vertex.Length);
        Debug.Log("Planet Mesh Data : " + meshData.vertex.Length);
        
        frontMeshData.Dispose();
        
        Mesh mesh = new Mesh();
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        
        mesh.SetVertices(meshData.vertex.AsArray());
        mesh.SetIndices(meshData.triangles.AsArray(), MeshTopology.Triangles, 0);
        
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
