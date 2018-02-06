using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Service.DataAccess
{
  public interface IMuseumStore
  {
    System.Data.IDataReader GetSculptures(string filter);
  }
}