using System.Runtime.Serialization;

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