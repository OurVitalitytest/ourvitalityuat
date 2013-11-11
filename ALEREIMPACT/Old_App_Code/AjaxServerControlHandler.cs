using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AjaxServerControlHandler
/// </summary>
public class AjaxServerControlHandler : AjaxControlHandler
{
    public override Control GetControl(HttpContext context)
    {
        // Get the path to the user control
        string path = context.Request.Url.LocalPath;

        var typeName = path.Substring(0, path.Length - 4).TrimStart('/');
        var type = Type.GetType(typeName);

        // If type is not found
        if (type == null) return null;

        var control = Activator.CreateInstance(type) as WebControl;

        return control;
    }
}
