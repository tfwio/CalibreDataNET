/* oio : 3/9/2014 6:29 AM */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookApp
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
//			routes.RouteExistingFiles = true;
//			routes.IgnoreRoute("assets/{*pathInfo}");
//			routes.IgnoreRoute("assets/css/default.css");
//			routes.IgnoreRoute("{file}.gif");
//			routes.IgnoreRoute("{file}.js");
			routes.MapRoute(
				"Default", "{controller}/{action}/{id}",
				new {
					controller = "conf",
					action = "index",
					id = UrlParameter.Optional,
				});
			routes.MapRoute(
				"Api","api/index/{library}/{sort}",
				new {
					controller = "api",
					action = "index",
					library = "library, the",
					sort = "title"
				});
			routes.MapRoute(
				"Book","api/book/{category}/{id}/{fmt}",
				new {
					controller = "Api",
					action = "book",
					category = "libirary, the",
					book = "00001",
					fmt = UrlParameter.Optional,
				});
		}
		
		protected void Application_Start()
		{
		  CalibreData.Models.BookRequest.SetRoot(@"e:\serve\book");
			RegisterRoutes(RouteTable.Routes);
		}
	}
}
