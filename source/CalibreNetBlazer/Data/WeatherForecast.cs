#nullable enable
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Cor3.Data.Engine;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace CalibreNetBlazer.Data
{
  public class WeatherForecast
  {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
    }
    public class NodeData
    {
        // provides: book-id, author, title, format, path
        public long BookID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }

        public NodeData(IList<object?> data)
        {
            if (data[0] != null) BookID = (long) data[0];
            if (data[1] != null) Author = data[1] as string;
            if (data[2] != null) Title  = data[2] as string;
            if (data[3] != null) Format = data[3] as string;
            if (data[4] != null) Path   = data[4] as string;
        }
    }
    public class NodeRow
    {
        // provides: book-id, author, title, format, path
        public long BookID { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public List<string> Format { get; set; }
        public string? Path { get; set; }

        public NodeRow()
        {
            Format = new List<string>();
        }
        public NodeRow(NodeData data)
        {
            this.Format = new List<string>();
            BookID = data.BookID;
            Author = data.Author;
            Title  = data.Title;
            Format.Add(data.Format);
            Path   = data.Path;
        }
    }

    class JSONLoader
    {

        static JsonSerializerSettings default_json_serializer_settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            StringEscapeHandling = StringEscapeHandling.Default
        };

        const string generalQuery = @"
select b.[id] 'book-id', a.[name] 'author', [title], [format], [path], a.[sort]
from ( (

( ( books b inner join data d on b.[id] = d.[book] )
    inner join books_authors_link bal on bal.[book] = b.[id] )
    inner join authors a on bal.[author] = a.[id] )
)

order by a.[sort] ASC, [title]
;";

        /// <summary>
        /// to test JSON serialization and initial query-model planning.
        /// </summary>
        /// <returns></returns>
        static public List<NodeRow> JsonIndex111(
            string database_path,
            bool showQuery,
            bool simplify = false)
        {
            var db_file = new System.IO.FileInfo(database_path);
            if (!db_file.Exists)
                throw new Exception(string.Format("Database not found: {0}\nPlease supply a full path to the metadata.db you're interested in.\n", db_file.Name));

            const string mytable = "mytable"; // const string jsonenc = "application/json";
            if (true)
            {
                var list = new List<NodeData>();
                var rows = new List<string>();
                string err = null;
                using (var db = new SQLiteQuery(db_file.FullName))
                using (var data = db.ExecuteSelect(generalQuery, mytable))
                {
                    if (data.HasErrors) err = "We encountered an error\n";
                    // provides: book-id, author, title, format, path
                    foreach (DataColumn r in data.Tables[mytable].Columns) rows.Add(r.ColumnName);
                    foreach (DataRowView r in data.Tables[mytable].DefaultView) list.Add(new NodeData(r.Row.ItemArray));
                }
                // ((node) => { return false; })

                List<NodeRow> Books = new List<NodeRow>();
                var xn = (from x in list select x.BookID).Distinct();
                foreach (var b in xn)
                {
                    var book = list.Where(x => x.BookID==b);
                    var i = book.First();
                    Books.Add(new NodeRow() { BookID=i.BookID, Author=i.Author, Path=i.Path, Title = i.Title, Format = (from x in book select x.Format).ToList() });
                }

                return Books;
            }
        }


        /// <summary>
        /// to test JSON serialization and initial query-model planning.
        /// </summary>
        /// <returns></returns>
        static public string Index_SerializeJSON(
            string database_path,
            bool showQuery,
            bool simplify = false)
        {
            var db_file = new System.IO.FileInfo(database_path);
            if (!db_file.Exists)
                return string.Format("Database not found: {0}\nPlease supply a full path to the metadata.db you're interested in.\n", db_file.Name);

            const string mytable = "mytable"; // const string jsonenc = "application/json";
            if (true)
            {
                var list = new List<object?>();
                var rows = new List<string>();
                string err = null;
                using (var db = new SQLiteQuery(db_file.FullName))
                using (var data = db.ExecuteSelect(generalQuery, mytable))
                {
                    if (data.HasErrors) err = "We encountered an error\n";
                    // provides: book-id, author, title, format, path
                    foreach (DataColumn r in data.Tables[mytable].Columns) rows.Add(r.ColumnName);
                    foreach (DataRowView r in data.Tables[mytable].DefaultView) list.Add(r.Row.ItemArray);
                }

                object data1 = simplify ? (object)list.Count : (object)list;

                object ObjectToSerialize = new
                {
                    headers = rows,
                    data = data1,
                    query = showQuery ? generalQuery : "Nothing to see here!",
                    error = err
                };
                return JsonConvert.SerializeObject(
                    ObjectToSerialize,
                    default_json_serializer_settings);
            }
        }
    }
}
