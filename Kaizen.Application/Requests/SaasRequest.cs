
public class Rootobject
{
    public SaasRequest[] Property1 { get; set; }
}

public class SaasRequest
{
    public string? locale { get; set; }
    public string description { get; set; }
    public Boundingpoly boundingPoly { get; set; }
}

public class Boundingpoly
{
    public Vertex[] vertices { get; set; }
}

public class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
}
