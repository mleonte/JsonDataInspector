using UnityEditor;
using UnityEngine;
using System;

public static class Fields
{
    public static object Get(Type type, object current)
    {
        if (type == typeof(Color))
            return EditorGUILayout.ColorField((Color)current);
        else if (type == typeof(Colour))
            return (Colour)EditorGUILayout.ColorField((Colour)current);
        else if (type == typeof(int))
            return EditorGUILayout.IntField((int)current);
        else if (type == typeof(string))
            return EditorGUILayout.TextField((string)current);

        return null;
    }
}

