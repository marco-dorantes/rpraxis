using System.Data;

namespace Museum.Service.DataAccess.LocalStore
{
  public class MuseumLocalStore : Museum.Service.DataAccess.IMuseumStore
  {
    const string SculptureFile = "Sculpture.csv";

    public IDataReader GetSculptures(string filter) => new LocalFile(SculptureFile);
  }
}