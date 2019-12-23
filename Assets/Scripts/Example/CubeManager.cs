using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MoniLib.Data;

public class CubeManager : Manager<int, CubeData>
{
    public override int AssignKey(CubeData entry)
    {
        var id = Data.All.Count > 0 ? Data.All.Max(x => x.Id) + 1 : 0;
        entry.Id = id;
        entry.Colour = new Colour(0, 0, 0);
        return id;
    }

    public override int KeySelector(CubeData entry) => entry.Id;

    //public List<Cube> objs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
