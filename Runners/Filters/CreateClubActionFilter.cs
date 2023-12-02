using Microsoft.AspNetCore.Mvc.Filters;

namespace Booking.com.Filters
{
    public class CreateClubActionFilterpublic : ActionFilterAttribute
    {
        private readonly string PATH = Directory.GetCurrentDirectory() + "/Logs/"  + "logs.txt";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Before
            File.AppendAllText(PATH, context.HttpContext.Request.Path);
            base.OnActionExecuting(context);
        }

    }
}
