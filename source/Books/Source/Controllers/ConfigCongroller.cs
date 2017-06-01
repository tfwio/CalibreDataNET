using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CalibreData;
using Newtonsoft.Json;

using CalibreData.Models;

namespace BookApp.Controllers
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public class ConfController : Controller
	{
		const string undef = "UNDEFINED";
		static readonly JsonSerializerSettings JsonConfig =
			new JsonSerializerSettings();
		void ModelToView(ControllerBase controller, InfoModel model)
		{
//			if (model != null)
			{
				controller.ViewData["libroot"] = model.libroot ?? undef;
				controller.ViewData["imgroot"] = model.imgroot ?? undef;
				controller.ViewData["dirs"] = string.Join(
					", ",
					model.dirs ?? new string[]{
						"nothing was defined"
					});
				controller.ViewData["ignore"] = string.Join(
					", ",
					model.ignore ?? new string[]{
						"nothing was defined"
					});
			}
		}
		public ActionResult Images()
		{
			Response.ContentType = "application/json; charset=utf-8";
			Response.Write(ImagePathToJSON.Command(Server.MapPath("~/assets/subtlepatterns")));
			return null;
		}
		public ActionResult Index(InfoModel model)
		{
//			string path = HttpContext.Current.Server.MapPath("~/assets/conf.json");
//			string path = HttpContext.Server.MapPath("~/assets/conf.json");
			string path = Server.MapPath("~/assets/conf.json");
			bool hasConfig = System.IO.File.Exists(path);
			ModelToView(this,model);
			bool HasModel = model.imgroot == undef;
			string data = null;
			InfoModel result = null;
			
			if (hasConfig)
			{
				data = System.IO.File.ReadAllText(path);
				result = JsonConvert.DeserializeObject(
					data, typeof(InfoModel), JsonConfig)
					as InfoModel;
				
				this.ViewData["json-memory"] = result;
				
				InfoModel im = JsonConvert.DeserializeObject(
					data, typeof(InfoModel), JsonConfig)
					as InfoModel;
				
				for (int i = 0; i < im.dirs.Length; i++)
				{
					im.dirs[i] = string.Format("“{0}”",im.dirs[i]);
				}
				
				ModelToView(this,im);
			}
			if (HasModel)
			{
//				Response.Write(path);
				model.action = "input";
				Response.ContentType = "application/json; charset=utf-8";
				Response.Write(JsonConvert.SerializeObject(model));
				return null;
			}
			else if (!string.IsNullOrEmpty(Request["get"]))
			{
//				Response.Write(path);
				Response.ContentType = "application/json; charset=utf-8";
				result.action = "config";
				Response.Write(JsonConvert.SerializeObject(result));
				return null;
			}
			return View();
			//return View();
		}
		public ActionResult Data(InfoModel model)
		{
			
			Response.ContentType = "application/json; charset=utf-8";
			string value = string.Format("{{'httpMethod': '{0}'}}",Request.HttpMethod);
			Response.Write(value);
//			Response.Write(JsonConvert.SerializeObject(result));
			return null;
		}
		/// <summary>
		/// We'll only check the directory here.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public ActionResult checkpath(InfoModel model)
		{
			return null;
		}
		
		public ActionResult SetDirectory()
		{
			return View();
		}
	}
}