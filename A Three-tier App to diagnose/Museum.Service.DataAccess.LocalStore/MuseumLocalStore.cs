using System.Data;

namespace Museum.Service.DataAccess.LocalStore
{
  public class MuseumLocalStore : Museum.Service.DataAccess.IMuseumStore
  {
    const string SculptureFile = "Sculpture.csv";

    //public IDataReader GetSculptures(string filter) => new LocalFile(SculptureFile, filter);

    System.Collections.Generic.Dictionary<string, LocalFile> responses;
    public MuseumLocalStore()
    {
      responses = new System.Collections.Generic.Dictionary<string, LocalFile>();
    }
    public IDataReader GetSculptures(string filter)
    {
      var newfile = new LocalFile(SculptureFile, filter);
      LocalFile previous;
      if (responses.TryGetValue(newfile.Name, out previous))
      {
        return previous;
      }
      else
      {
        responses[newfile.Name] = newfile;
        newfile.Prepare();
        return newfile;
      }
    }
  }
}