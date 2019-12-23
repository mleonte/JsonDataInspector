using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public void Instantiate(CubeData data)
    {
        var cubeRenderer = GetComponent<Renderer>();
        this.name = data.Name;
        cubeRenderer.material.SetColor("Albedo", data.Colour);
    }
}
