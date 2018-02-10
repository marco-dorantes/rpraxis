using System.Data;
using System.Data.SqlClient;

namespace Museum.Service.DataAccess.SqlStore
{
  public class MuseumSqlStore : Museum.Service.DataAccess.IMuseumStore
  {
    public IDataReader GetSculptures(string filter)
    {
      /*
      CREATE TABLE [dbo].[ctest](
        [ID] [varchar](50) NULL,
        [Name] [varchar](50) NULL,
        [Artist] [varchar](50) NULL,
        [When] [varchar](50) NULL
      ) ON [History]
       */
      var conn = new SqlConnection("Data Source=host;Initial Catalog=db;Integrated Security=SSPI;Persist Security Info=False");
      conn.Open();
      var cmd = conn.CreateCommand();
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = "SELECT [ID],[Name],[Artist],[When] FROM ctest";
      return cmd.ExecuteReader();
    }
  }
}