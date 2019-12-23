using System;
using System.Collections.Generic;
using UnityEngine;
using MoniLib.Data;
using UnityEditor;
using System.Reflection;
using Newtonsoft.Json;

public class JsonDataInspector<TKey, TValue> : Editor
{
    Manager<TKey, TValue> manager;

    void OnEnable()
    {
        manager = target as Manager<TKey, TValue>;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var props = typeof(TValue).GetProperties();

        GUILayout.BeginHorizontal();
        GUILayout.Label("File path:");
        manager.FilePath = EditorGUILayout.TextField(manager.FilePath ?? "");
        if (GUILayout.Button("Update"))
        {
            manager.Reset();
        }
        GUILayout.EndHorizontal();
        
        TableHeaders(props);
        if (manager.FilePath != null && manager.FilePath != "")
        {
            Entries(props);
            NewEntry(props);
            Save();
            Refresh();
        }
    }

    private void TableHeaders(PropertyInfo[] props)
    {
        GUILayout.BeginHorizontal();
        for (int p = 0; p < props.Length; p++)
            GUILayout.Label(props[p].Name);
        GUILayout.EndHorizontal();
    }

    private void Entries(PropertyInfo[] props)
    {
        var entries = manager.Data.All;
        List<TValue> toDelete = new List<TValue>();
        for (int e = 0; e < entries.Count; e++)
        {
            GUILayout.BeginHorizontal();
            for (int p = 0; p < props.Length; p++) {
                Debug.Log($"{props[p].Name} {props[p].PropertyType} {props[p].GetValue(entries[e])}");
                var data = Fields.Get(props[p].PropertyType, props[p].GetValue(entries[e]));
                props[p].SetValue(
                    entries[e],
                    data
                    );
            }
            if (GUILayout.Button("X"))
                toDelete.Add(entries[e]); 
            GUILayout.EndHorizontal();
        }

        for (int i = 0; i < toDelete.Count; i++)
            manager.Data.Remove(manager.KeySelector(toDelete[i]));
    }

    private void NewEntry(PropertyInfo[] props)
    {
        if (GUILayout.Button("Add new entry"))
        {
            var newEntry = Activator.CreateInstance<TValue>();
            for (int p = 0; p < props.Length; p++)
                if (props[p].PropertyType == typeof(String))
                    props[p].SetValue(newEntry, "");
            manager.Add(newEntry);
        }
    }

    private void Save()
    {
        if (GUILayout.Button("Save"))
        {
            manager.Data.Commit();
        }
    }

    private void Refresh()
    {
        if (GUILayout.Button("Refresh"))
        {
            manager.Data.Refresh();
        }
    }


}
