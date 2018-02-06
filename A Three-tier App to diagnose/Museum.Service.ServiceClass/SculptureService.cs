using System.ServiceModel;

namespace Museum.Service.ServiceClass
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SculptureService : Museum.Service.Contract.ISculptureService
    {
    public System.Collections.Generic.IEnumerable<Museum.Service.Contract.Sculpture> GetSculptures(string filter) => Museum.Service.Processor.SculptureProcessor.GetSculptures(filter);
  }
}