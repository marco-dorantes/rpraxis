using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specification
{
  [TestClass]
  public class IntegrationLevelTestCases
  {
    [TestMethod]
    public void AllSculptures()
    {
      //Arrange
      var sculpture_client = new ConsoleApplication.SculptureProxy("SculptureService");

      //Act
      var sculptures = sculpture_client.Proxy.GetSculptures(null);

      //Assert
      Assert.IsNotNull(sculptures);
      Assert.IsTrue(sculptures.Count() > 0);
    }
  }
}