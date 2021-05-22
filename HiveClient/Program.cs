using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;

namespace HiveClient
{
    class Program
  {
    static void Main(string[] args)
    {
      GetData();
      Console.WriteLine("----------------------------------------------");
      Console.WriteLine("Press a key to end");
      Console.Read();
    }

    static async void GetData()
    {
      using (OdbcConnection conn = 
             new OdbcConnection("DSN=sqla;UID=token;PWD=<YOUR PAT TOKEN>"))
      {
        conn.OpenAsync().Wait();
        OdbcCommand cmd = conn.CreateCommand();
        cmd.CommandText =
            "select * from customers limit 10;";
        DbDataReader dr = await cmd.ExecuteReaderAsync();
        while (dr.Read())
        {
          Console.WriteLine(dr.GetString(1)); 
        }
      }
    }
  }
}
