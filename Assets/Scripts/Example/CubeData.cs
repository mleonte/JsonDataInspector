using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// The Unity color class isn't serializable with NewtonSoft because of a self reference loop
/// </summary>
public class Colour
{
    public float Red;
    public float Green;
    public float Blue;

    public Colour(float red, float green, float blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public static implicit operator Color(Colour c) => new Color(c.Red, c.Green, c.Blue);

    public static explicit operator Colour(Color c) => new Colour(c.r, c.g, c.b);
}

public class CubeData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Colour Colour { get; set; }
}
