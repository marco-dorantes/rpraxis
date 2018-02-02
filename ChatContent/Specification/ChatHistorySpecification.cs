using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specification
{
  [TestClass]
  public class ChatHistorySpecification
  {
    [TestMethod]
    public void SimpleTextContent()
    {
      //Arrange
      string chat_entry = "live:john_123,John Doe,live:will,Will Smith,\"--?T::Z\",1517455101016,Hello!";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("Hello!", record.ContentXml);
    }
  }
}