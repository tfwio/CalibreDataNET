using System;
using System.Data;
using System.Data.SQLite;

namespace System.Cor3.Data.Engine
{
  public class SQLiteQuery : IDisposable
  {
    public bool HasError = false;

    public Exception Error = null;

    string databaseFile { get; set; }

    public SQLiteDb database { get; set; }

    public SQLiteConnection Connection { get; set; }

    public SQLiteDataAdapter Adapter { get; set; }

    public SQLiteQuery(string sqliteDatabaseFilePath)
    {
      this.databaseFile = sqliteDatabaseFilePath;
      this.database = new SQLiteDb(sqliteDatabaseFilePath);
    }

    public void ExecuteInsert(string query, Action<SQLiteCommand> setParams)
    {
      using (this.Connection = this.database.Connection)
      {
        using (this.Adapter = this.database.Adapter)
        {
          using (this.Adapter.InsertCommand = new SQLiteCommand(query, this.Connection))
          {
            this.Connection.Open();
            try
            {
              if (setParams != null)
              {
                setParams(this.Adapter.InsertCommand);
              }
              this.Adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              this.HasError = true;
              this.Error = e;
            }
            finally
            {
              this.Connection.Close();
            }
          }
        }
      }
    }

    public void ExecuteUpdate(string query, Action<SQLiteCommand> setParams)
    {
      using (this.Connection = this.database.Connection)
      {
        using (this.Adapter = this.database.Adapter)
        {
          using (this.Adapter.UpdateCommand = new SQLiteCommand(query, this.Connection))
          {
            this.Connection.Open();
            try
            {
              if (setParams != null)
              {
                setParams(this.Adapter.UpdateCommand);
              }
              this.Adapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              this.HasError = true;
              this.Error = e;
            }
            finally
            {
              this.Connection.Close();
            }
          }
        }
      }
    }

    public void ExecuteDelete(string query, Action<SQLiteCommand> setParams)
    {
      using (this.Connection = this.database.Connection)
      {
        using (this.Adapter = this.database.Adapter)
        {
          using (this.Adapter.DeleteCommand = new SQLiteCommand(query, this.Connection))
          {
            this.Connection.Open();
            try
            {
              if (setParams != null)
              {
                setParams(this.Adapter.DeleteCommand);
              }
              this.Adapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              this.HasError = true;
              this.Error = e;
            }
            finally
            {
              this.Connection.Close();
            }
          }
        }
      }
    }

    public DataSet ExecuteSelect(string query, string table)
    {
      DataSet ds = new DataSet();
      ds.Tables.Add(table);
      using (this.Connection = this.database.Connection)
      {
        using (this.Adapter = this.database.Adapter)
        {
          using (this.Adapter.SelectCommand = new SQLiteCommand(query, this.Connection))
          {
            this.Connection.Open();
            try
            {
              this.Adapter.SelectCommand.ExecuteNonQuery();
              this.Adapter.Fill(ds, table);
            }
            catch (Exception e)
            {
              this.HasError = true;
              this.Error = e;
            }
            finally
            {
              this.Connection.Close();
            }
          }
        }
      }
      return ds;
    }

    public void Dispose()
    {
      this.HasError = false;
      this.Error = null;
      this.databaseFile = null;
      this.database.Dispose();
      this.database = null;
    }
  }
}
