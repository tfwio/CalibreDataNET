/* oio * 7/12/2014 * Time: 10:39 PM
 */
using System;
using System.Collections.Generic;
using System.Cor3.Data.Engine;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;

namespace TestData
{
	static class JpegExtension
	{
		
	}
	class Program
	{
		const string sql_db_path = @"D:\DEV\WWW\PUB\lipxo\TestData\bin\Debug\metadata.db";
		const string dbc = @"Data Source=$(AttachDbFileName);Version=3;";
		const string generalQuery = @"select b.[id] 'bid', a.[name] 'author', [title], [format], [path] from ( ( ( ( books b inner join data d on b.[id] = d.[book] ) inner join books_authors_link bal on bal.[book] = b.[id] ) inner join authors a on bal.[author] = a.[id] ) );";
		/// <summary>
		/// This method, now obsolete---was to test JSON serialization and initial query-model planning.
		/// </summary>
		/// <returns></returns>
		static public string Index()
		{
			const string mytable = "mytable";
//			const string jsonenc = "application/json";
			if (true)
			{
				var list = new List<object[]>();
				var rows = new List<string>();
				string err = null;
				using (var db = new SQLiteQuery(sql_db_path))
					using (var data = db.ExecuteSelect(generalQuery, mytable))
				{
					if (data.HasErrors) err = "We encountered an error\n";
					foreach (DataColumn r in data.Tables[mytable].Columns) rows.Add(r.ColumnName);
					foreach (DataRowView r in data.Tables[mytable].DefaultView) list.Add(r.Row.ItemArray);
				}
				return JsonConvert.SerializeObject(
					new {
						headers=rows,
						data = list.Count,
						query = generalQuery,
						error = err
					});
//				);
				list.Clear();
				list = null;
				return null;
			}
//			return View();
		}
		
		public static void Main(string[] args)
		{
			
			{
				// FloatPoint sizeto = new FloatPoint(200, 320);
				// ToJpeg(@"C:/users/oio/desktop/ape.png",@"C:/users/oio/desktop/ape.jpg",sizeto,90);
				// Console.Write("Press any key to continue . . . ");
				// Console.ReadKey();
				// return;
			}
			{
//				var dt = DateTime.Parse("2014-06-27T15:56:53.124");
//				Console.WriteLine("{0}",dt);
//				Console.Write("Press any key to continue . . . ");
//				Console.ReadKey();
//				return ;
			}
			{
				string v = Index();
				Console.Write(v);
				// TODO: Implement Functionality Here
				
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}