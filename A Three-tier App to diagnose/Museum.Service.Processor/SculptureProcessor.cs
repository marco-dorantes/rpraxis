using System.Collections.Generic;

namespace Museum.Service.Processor
{
  public static class SculptureProcessor
  {
    public static System.Collections.Generic.IEnumerable<Museum.Service.Contract.Sculpture> GetSculptures(string filter)
    {
      var result = new List<Museum.Service.Contract.Sculpture>();
      var typemap = new nutility.TypeClassMapper();
      var store = typemap.GetService<Museum.Service.DataAccess.IMuseumStore>();
      System.Data.IDataReader reader = store.GetSculptures(filter);
      while (reader.Read())
      {
        var sculpture = new Museum.Service.Contract.Sculpture
        {
          ID = reader.GetString(0),
          Name = reader.GetString(1),
          Artist = reader.GetString(2),
          When = reader.GetString(3)
        };
        result.Add(sculpture);
      }
      return result;
    }
  }
}