using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoniLib.Data;
using UnityEditor;

[CustomEditor(typeof(CubeManager))]
public class CubeInspector : JsonDataInspector<int, CubeData>
{
}
