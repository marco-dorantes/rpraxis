using System.Collections.Generic;

namespace Museum.Service.Processor
{
  public static class SculptureProcessor
  {
    //private static System.Collections.Concurrent.ConcurrentDictionary<string, System.Data.IDataReader> responses;
    //static SculptureProcessor()
    //{
    //  responses = new System.Collections.Concurrent.ConcurrentDictionary<string, System.Data.IDataReader>();
    //}

    private static System.Data.IDataReader GetReader(string filter)
    {
      //System.Data.IDataReader previously_cached;
      //if (responses.TryGetValue(filter, out previously_cached))
      //{
      //  return previously_cached;
      //}
      //else
      {
        var typemap = new nutility.TypeClassMapper();
        var store = typemap.GetService<Museum.Service.DataAccess.IMuseumStore>();
        System.Data.IDataReader reader = store.GetSculptures(filter);
        //responses[filter] = reader;
        return reader;
      }
    }
    public static System.Collections.Generic.IEnumerable<Museum.Service.Contract.Sculpture> GetSculptures(string filter)
    {
      var result = new List<Museum.Service.Contract.Sculpture>();
      System.Data.IDataReader reader = GetReader(filter);
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