using System.ServiceModel;

namespace Museum.Service.Contract
{
  [ServiceContract]
  public interface ISculptureService
  {
    [OperationContract]
    System.Collections.Generic.IEnumerable<Sculpture> GetSculptures(string filter);
  }
}