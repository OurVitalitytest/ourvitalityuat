using System.Web;
using System.Web.UI;

public class AjaxUserControlHandler : AjaxControlHandler
{
    public override Control GetControl(HttpContext context)
    {
        // Get the path to the user control
        string path = context.Request.Url.LocalPath;

        using (var page = new Page())
        {
            var viewControl = page.LoadControl(path) as UserControl;
            return viewControl;
        }
    }
}
