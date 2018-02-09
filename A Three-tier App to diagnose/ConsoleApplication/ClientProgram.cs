﻿using System;
using static System.Console;

namespace ConsoleApplication
{
  class ClientProgram
  {
    static void run(int k)
    {
      try
      {
        WriteLine($"[{k,6}]");
        var sculpture_client = new ConsoleApplication.SculptureProxy("SculptureService");
        var sculptures = sculpture_client.Proxy.GetSculptures($"{Guid.NewGuid()}");
        foreach (var sculpture in sculptures)
        {
          WriteLine($"{sculpture.ID,5} {sculpture.Name,30} {sculpture.Artist,24} {sculpture.When,20}");
        }
      }
      catch (Exception ex)
      {
        WriteLine($"{ex.GetType().FullName}: {ex.Message}");
      }
    }
    static void Main(string[] args)
    {
      for (int k = 0; k < 2049 * 5; ++k)
      {
        WriteLine("Press ENTER to continue");ReadLine();
        run(k);
      }
    }
  }
}