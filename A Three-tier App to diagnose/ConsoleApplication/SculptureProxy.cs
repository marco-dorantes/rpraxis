using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
  public class SculptureProxy : System.ServiceModel.ClientBase<Museum.Service.Contract.ISculptureService>
  {
    public SculptureProxy(string endpointConfigurationName) : base(endpointConfigurationName) { }
    public Museum.Service.Contract.ISculptureService Proxy { get { return this.Channel; } }
  }
}