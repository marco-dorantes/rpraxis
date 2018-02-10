using System;
using System.ServiceModel;
using static System.Console;

namespace Museum.Service.Host
{
  class HostProgram
  {
    static void Main(string[] args)
    {
      try
      {
        using (var host = new ServiceHost(typeof(Museum.Service.ServiceClass.SculptureService), new Uri("http://localhost:5000/Museum")))
        {
          try
          {
            host.Open();
            WriteLine("Service listening at:");
            foreach (var endpoint in host.Description.Endpoints)
            {
              WriteLine($"\t{endpoint.Address.Uri}");
            }
            WriteLine("Press ENTER to exit.");
            ReadLine();
          }
          catch (Exception ex)
          {
            WriteLine($"{ex.GetType().FullName}: {ex.Message}");
          }
        }
      }
      catch (Exception ex)
      {
        WriteLine($"{ex.GetType().FullName}: {ex.Message}");
      }
    }
  }
}