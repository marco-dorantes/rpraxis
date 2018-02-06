using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Museum.Service.ServiceClass
{
  public class SculptureService : Museum.Service.Contract.ISculptureService
  {
    public System.Collections.Generic.IEnumerable<Museum.Service.Contract.Sculpture> GetSculptures(string filter) => Museum.Service.Processor.SculptureProcessor.GetSculptures(filter);
  }
}