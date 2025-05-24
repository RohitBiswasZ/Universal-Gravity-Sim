using NaughtyAttributes;
using Unity.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Planet : MonoBehaviour
{
    [Expandable] public PlanetSettings settings;
    public PlanetMeshGenerator meshGenerator;
    public PlanetMeshData meshData;
    [HideInInspector] public Material material;

    private void Start()
    {
        meshGenerator = GetComponent<PlanetMeshGenerator>();
        
        meshData = new PlanetMeshData(Allocator.Persistent);
        PlanetMeshData frontMeshData = meshGenerator.CreateCubicFace(settings.resolution, 5, Vector3.zero);

        meshData.ClonePlanetMeshData(frontMeshData, Allocator.Persistent);
        
        Debug.Log("Cube Mesh Data : " + frontMeshData.vertex.Length);
        Debug.Log("Planet Mesh Data : " + meshData.vertex.Length);
        
        frontMeshData.Dispose();
        
        string shaderId = "Shader Graphs/PlanetShader";
        material = new Material(Shader.Find(shaderId));
        
        UpdateMaterial();
        UpdateMesh();
    }

    [Button("Update Material")]
    public void UpdateMaterial()
    {
        string colorId = "_BaseColor";
        material.SetColor(colorId, settings.baseColor);

        string shadeValueId = "_ShadeValue";
        material.SetFloat(shadeValueId, settings.shadowStrength);
        
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
    }
    
    public void UpdateMesh()
    {
        Mesh mesh = new Mesh();
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        
        mesh.SetVertices(meshData.vertex.AsArray());
        mesh.SetIndices(meshData.triangles.AsArray(), MeshTopology.Triangles, 0);
        
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    [Button("Generate Mesh")]
    public void GenerateMeshData()
    {
        if (meshData.IsCreated()) meshData.Dispose();
        
        meshData = new PlanetMeshData(Allocator.Persistent);
        PlanetMeshData frontMeshData = meshGenerator.CreateCubicFace(settings.resolution, 5, Vector3.zero);

        meshData.ClonePlanetMeshData(frontMeshData, Allocator.Persistent);
        
        frontMeshData.Dispose();
        
        UpdateMesh();
    }
}
