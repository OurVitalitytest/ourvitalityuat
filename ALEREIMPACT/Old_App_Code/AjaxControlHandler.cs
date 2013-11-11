using System.Linq;
using System.Web;
using System.Web.UI;

public abstract class AjaxControlHandler : IHttpHandler
{
    public abstract Control GetControl(HttpContext context);

    public void ProcessRequest(HttpContext context)
    {
        

        // Intialize the pseudo page and user control
        using (var page = new Page())
        {
            var control = GetControl(context);

            // Display error if the user control was not found
            if (control == null)
            {
                context.Response.StatusCode = 404;
                context.Response.Output.WriteLine("The requested url was not found");
                return;
            }

            // Check existense of the AjaxEnabled attribute. Only add the AjaxEnabled attribut to 
            // user controls that is safe for direct calls
            var type = control.GetType();
            var attributes = type.GetCustomAttributes(typeof(AjaxEnabledAttribute), true);
            var attribute = attributes.FirstOrDefault() as AjaxEnabledAttribute;

            // If the attribute was not found, display an error
            if (attribute == null)
            {
                context.Response.StatusCode = 403;
                context.Response.Output.WriteLine("Access to the resource is not allowed");
                return;
            }


            // Check if the request is valiud with regards to the requirements of the attribute.
            // If not, display error
            if ((attribute.Method == RequestMethodSupport.GET && context.Request.RequestType != "GET")
                || (attribute.Method == RequestMethodSupport.POST && context.Request.RequestType != "POST"))
            {
                context.Response.StatusCode = 403;
                context.Response.Output.WriteLine(string.Format("The request method {0} is not allowed.", context.Request.RequestType));
                return;
            }

            // Add user control to the pages control tree
            page.Controls.Add(control);

            // Disable caching, remove this if you will allow client caching
            context.Response.CacheControl = "No-Cache";

            // Execute and return result to Output stream
            context.Server.Execute(page, context.Response.Output, true);
        }
    }

    public bool IsReusable
    {
        get { return true; }
    }
}
