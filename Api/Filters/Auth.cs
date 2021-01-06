using AcademyApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class Auth:ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApiDbContext _db;
        public Auth(ApiDbContext db, IHttpContextAccessor accessor)
        {
            _db = db;
            _accessor = accessor;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
