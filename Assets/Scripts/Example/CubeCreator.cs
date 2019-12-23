using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public CubeManager manager;
    public Cube cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        var cubes = manager.Data.All;
        for (int i = 0; i < cubes.Count; i++)
        {
            var cube = Instantiate(cubePrefab);
            cube.transform.position = Vector3.right * i;
            cube.Instantiate(cubes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
