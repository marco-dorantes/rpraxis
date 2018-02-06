using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Service.Contract
{
  [DataContract]
  public class Sculpture
  {
    [DataMember]
    public string ID;

    [DataMember]
    public string Name;

    [DataMember]
    public string Artist;

    [DataMember]
    public string When;
  }
}