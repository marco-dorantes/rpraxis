using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specification
{
  [TestClass]
  public class ComponentLevelTestCases
  {
    [TestMethod]
    public void AllSculptures()
    {
      //Arrange
      string filter = null;

      //Act
      var sculptures = Museum.Service.Processor.SculptureProcessor.GetSculptures(filter);

      //Assert
      Assert.IsNotNull(sculptures);
      Assert.IsTrue(sculptures.Count() > 0);
    }

    [TestMethod]
    public void LocalFile()
    {
      //Arrange
      var store = new Museum.Service.DataAccess.LocalStore.MuseumLocalStore();

      //Act
      var sculptures_reader = store.GetSculptures(filter: null);

      //Assert
      Assert.IsNotNull(sculptures_reader);
      Assert.IsTrue(sculptures_reader.Read());
    }
  }
}