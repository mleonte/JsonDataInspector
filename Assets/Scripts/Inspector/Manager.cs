using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoniLib.Data;
using UnityEditor;

[ExecuteInEditMode]
public abstract class Manager<TKey, TValue> : MonoBehaviour
{
    public List<TValue> objs;
    public JsonDataCollection<TKey, TValue> Data;
    private string filePath;
    public string FilePath { get; set; }
    
    void OnEnable()
    {
        if (FilePath != null && FilePath != "")
            Data = new JsonDataCollection<TKey, TValue>($"Assets/Data/{FilePath}");
    }
    
    public void Reset()
    {
        Data = new JsonDataCollection<TKey, TValue>($"Assets/Data/{FilePath}");
    }

    public abstract TKey KeySelector(TValue entry);

    public abstract TKey AssignKey(TValue entry);

    public void Add(TValue entry)
    {
        Data[AssignKey(entry)] = entry;
    }
}
