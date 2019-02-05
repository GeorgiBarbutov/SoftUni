using System;

public class XmlLayout : Layout
{
    public XmlLayout() 
        : base("<log>" + Environment.NewLine +
            "<date>{0}</date>" + Environment.NewLine +
            "<level>{1}</level>" + Environment.NewLine +
            "<message>{2}</message>" + Environment.NewLine +
            "</log>")
    {
    }
}

