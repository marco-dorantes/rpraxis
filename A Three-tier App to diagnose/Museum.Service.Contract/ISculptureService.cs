using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Service.Contract
{
  [ServiceContract]
  public interface ISculptureService
  {
    [OperationContract]
    System.Collections.Generic.IEnumerable<Sculpture> GetSculptures(string filter);
  }
}