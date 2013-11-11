using System;
using System.ComponentModel;

public class AjaxEnabledAttribute : Attribute
{
    [DefaultValue(RequestMethodSupport.All)]
    public RequestMethodSupport Method { get; set; }
}

public enum RequestMethodSupport
{
    All,
    GET,
    POST
}
