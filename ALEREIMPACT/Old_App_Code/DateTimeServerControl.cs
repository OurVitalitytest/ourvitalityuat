using System;
using System.Web.UI.WebControls;

[AjaxEnabled]
public class DateTimeServerControl : WebControl
{
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        writer.Write("DateTime by WebControl: {0}", DateTime.Now);
    }
}
