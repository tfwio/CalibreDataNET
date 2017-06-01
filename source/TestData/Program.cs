/* oio * 7/12/2014 * Time: 10:39 PM
 */
using System;
using System.Collections.Generic;
using System.Cor3.Data.Engine;
using System.Data;
using Newtonsoft.Json;
using System.Linq;

namespace TestData
{
  class Program
  {
    // console-options
    struct ConsoleOptions
    {
      /// pause before the program terminates
      public bool ConsolePostPause { get; set; }
      public bool PauseOnError { get;set; }
      public string DatabasePath { get; set; }
    }
    readonly static ConsoleOptions default_console_options = new ConsoleOptions()
    {
      ConsolePostPause = false,
      PauseOnError     = true,
      DatabasePath     = sql_db_path
    };
    // generation options
    public struct OutputOptions
    {
      /// <summary>
      /// if set to true, then will only generate the number of items that are stored to our resulting record-set 'list' items.
      /// </summary>
      public bool SimplifyOutput { get; set; }
      public bool ShowQuery { get; set; }
    }
    static OutputOptions default_output_options = new OutputOptions()
    {
      SimplifyOutput = false,
      ShowQuery = false
    };
    
    const string sql_db_path = @"[drive:\][path-to]\metadata.db";
    const string generalQuery = @"select b.[id] 'bid', a.[name] 'author', [title], [format], [path] from ( ( ( ( books b inner join data d on b.[id] = d.[book] ) inner join books_authors_link bal on bal.[book] = b.[id] ) inner join authors a on bal.[author] = a.[id] ) );";
    
    static JsonSerializerSettings default_json_serializer_settings = new JsonSerializerSettings
    {
      Formatting = Formatting.Indented,
      StringEscapeHandling = StringEscapeHandling.Default
    };
    
    
    
    // test faux mvc controller response (to output)
    static void Test_02(string metadata_db_path, OutputOptions outOptions)
    {
      string v = JsonIndex(metadata_db_path, outOptions);
      Console.Write(v);
    }
    
    
    static void Pause()
    {
      Console.Write("\nPress any key to continue . . . ");
      Console.ReadKey(true);
    }
    
    static void Help() // not yet
    {
      var helpMsg = @"
TestData.exe [-p] [full_path_to_metadata.db]

where...
  -p: Pause after completion (also writes ""press a key to continue"")

";
    }
    
    public static void Main(string[] args)
    {
      var o = default_console_options;
      var oo = default_output_options;
      // inputs stack
      var istack = new Stack<string>(args); // Stack looks at the back first? Okay then...
      
      if (args.Length==0) goto just_continue; // skip if we have nothing to work with.
      
      // check args[] for a valid path.
      if (System.IO.File.Exists(istack.Peek()))
        o.DatabasePath = istack.Pop();
      
      istack = new Stack<string>(istack.Reverse());
      
      while (istack.Count != 0) // more options?
      {
        var next = istack.Peek();
        switch (next.ToLower())
        {
            case "-p": o.ConsolePostPause = true; break;
            case "-s": oo.SimplifyOutput = true; break;
            //case "-n": o.ConsolePostPause = false; break; // useful if we turn default pause operation to true.
        }
        istack.Pop();
      }
      just_continue:
        
        // —————————————————————————————————————————————————————————————————————
        // CHECK INPUT DATABASE PATH
        // —————————————————————————————————————————————————————————————————————
        try {
        // will cause System.NotSupportedException if default-path is supplied (which is good)
        var fileinfo_path = new System.IO.FileInfo(o.DatabasePath);
      }
      catch (System.NotSupportedException)
      {
        var msg = string.Format("Database not found: {0}\nPlease supply a full path to the metadata.db you're interested in.\n", o.DatabasePath);
        Console.Write(msg);
        if (o.PauseOnError) Pause();
        return;
      }
      
      Test_02(o.DatabasePath, oo); // finally
      
      if (o.ConsolePostPause) Pause();
    }
    
    /// <summary>
    /// to test JSON serialization and initial query-model planning.
    /// </summary>
    /// <returns></returns>
    static public string JsonIndex(string database_path, OutputOptions options)
    {
      var db_file = new System.IO.FileInfo(database_path);
      if (!db_file.Exists)
        return string.Format("Database not found: {0}\nPlease supply a full path to the metadata.db you're interested in.\n", db_file.Name);
      
      const string mytable = "mytable"; // const string jsonenc = "application/json";
      if (true)
      {
        var list = new List<object[]>();
        var rows = new List<string>();
        string err = null;
        using (var db = new SQLiteQuery(db_file.FullName))
          using (var data = db.ExecuteSelect(generalQuery, mytable))
        {
          if (data.HasErrors) err = "We encountered an error\n";
          foreach (DataColumn r in data.Tables[mytable].Columns) rows.Add(r.ColumnName);
          foreach (DataRowView r in data.Tables[mytable].DefaultView) list.Add(r.Row.ItemArray);
        }
        object data1 = options.SimplifyOutput ? (object)list.Count : (object)list;
        object ObjectToSerialize = new {
          headers=rows,
          data = data1,
          query = options.ShowQuery ? generalQuery : "Nothing to see here!",
          error = err
        };
        return JsonConvert.SerializeObject(
          ObjectToSerialize, default_json_serializer_settings);
      }
    }

    // void Test_00() // png to jpg conversion // note that this method no longer exists!
    // {
    //   var sizeto = new System.Drawing.FloatPoint(200, 320);
    //   ToJpeg(@"C:/users/oio/desktop/ape.png",@"C:/users/oio/desktop/ape.jpg",sizeto,90);
    //   Console.Write("Press any key to continue . . . ");
    //   Console.ReadKey();
    //   return;
    // }
    
    // void Test_01() // date-time recognition (as metadata.db asserts date/time?)
    // {
    //   var dt = DateTime.Parse("2014-06-27T15:56:53.124");
    //   Console.WriteLine("{0}",dt);
    //   Console.Write("Press any key to continue . . . ");
    //   Console.ReadKey();
    //   return ;
    // }
  }
}