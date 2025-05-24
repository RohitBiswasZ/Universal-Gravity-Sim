using UnityEngine;

[CreateAssetMenu()]
public class PlanetSettings : ScriptableObject
{
    public Color baseColor;
    [Range(1,103)] public int resolution;
    [Range(-1,1)] public float shadowStrength;
}