using System.Diagnostics;

[GenerateSerializer]
[DebuggerDisplay("({Latitude} : {Longitude})")]
public class Gps
{
    [Id(0)]
    public double Latitude { get; set; }
    [Id(1)]
    public double Longitude { get; set; }
}