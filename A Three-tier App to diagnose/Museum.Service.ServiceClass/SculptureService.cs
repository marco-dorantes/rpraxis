using System.ServiceModel;

namespace Museum.Service.ServiceClass
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class SculptureService : Museum.Service.Contract.ISculptureService
    {
        public System.Collections.Generic.IEnumerable<Museum.Service.Contract.Sculpture> GetSculptures(string filter) => Museum.Service.Processor.SculptureProcessor.GetSculptures(filter);
    }
}