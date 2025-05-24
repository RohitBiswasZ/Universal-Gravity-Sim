using Unity.Collections;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetMeshGenerator meshGenerator;
    public PlanetMeshData meshData;

    public void Start()
    {
        meshGenerator = gameObject.GetComponent<PlanetMeshGenerator>(); 
        
        meshData = new PlanetMeshData(Allocator.Persistent);
        PlanetMeshData cubeMeshData = meshGenerator.CreateCubicFace(60, 5, Vector3.zero);

        meshData.ClonePlanetMeshData(cubeMeshData, Allocator.Persistent);
        
        Debug.Log("Cube Mesh Data : " + cubeMeshData.vertex.Length);
        Debug.Log("Planet Mesh Data : " + meshData.vertex.Length);
        
        cubeMeshData.Dispose();
    }

    private void OnDrawGizmos()
    {
        if (!meshData.vertex.IsCreated && !Application.isPlaying) return;
        
        for (int i = 0; i < meshData.vertex.Length; i++)
        {
            Vector3 vertex = meshData.vertex[i];
            Gizmos.DrawSphere(vertex, 0.02f);
        }
    }
}
