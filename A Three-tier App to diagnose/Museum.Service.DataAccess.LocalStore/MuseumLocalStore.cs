using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Service.DataAccess.LocalStore
{
  public class MuseumLocalStore : Museum.Service.DataAccess.IMuseumStore
  {
    const string SculptureFile = "Sculpture.csv";

    public IDataReader GetSculptures(string filter) => new LocalFile(SculptureFile);
  }
}