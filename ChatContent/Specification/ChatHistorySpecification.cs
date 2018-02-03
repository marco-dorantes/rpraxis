using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specification
{
  [TestClass]
  public class ChatHistorySpecification
  {
    [TestMethod, TestCategory("SimpleText")]
    public void Plain()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"--?T::Z\",1517455101016,Hello!";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("Hello!", record.ContentXml);
    }

    [TestMethod, TestCategory("SimpleText")]
    public void EnclosingQuotes()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"-- ? T::Z\",1516850226436,\"May I ask you a simple question?\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("May I ask you a simple question?", record.ContentXml);
    }

    [TestMethod, TestCategory("SimpleText")]
    public void NewLine()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:kant,Immanuel Kant,\"-- ? T::Z\",1516850226436,For sure. \r\nShoot!";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("For sure. \r\nShoot!", record.ContentXml);
    }

    [TestMethod, TestCategory("SimpleText")]
    public void EnclosingQuotesAndNewLine()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:kant,Immanuel Kant,\"-- ? T::Z\",1516850226436,\"For sure. \r\nShoot!\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("For sure. \r\nShoot!", record.ContentXml);
    }

    [TestMethod, TestCategory("SimpleText")]
    public void InsideQuotes()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"-- ? T::Z\",1516850227436,What is \"truth\"?";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("What is \"truth\"?", record.ContentXml);
    }

    [TestMethod, TestCategory("SimpleText")]
    public void InsideComma()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:kant,Immanuel Kant,\"-- ? T::Z\",1519850227436,Look, that is deep water.";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("Look, that is deep water.", record.ContentXml);
    }

    [TestMethod, TestCategory("XML_Emoticon")]
    public void Surprised()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"-- ? T::Z\",1529850227436,\"<ss type=\"\"surprised\"\">:O</ss>\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("<ss type=\"\"surprised\"\">:O</ss>", record.ContentXml);
    }

    [TestMethod, TestCategory("XML_Emoticon")]
    public void Smile()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"-- ? T::Z\",1529850227436,\"I know, there is reason, razón in Spanish, <ss type=\"\"smile\"\">:)</ss>\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("I know, there is reason, razón in Spanish, <ss type=\"\"smile\"\">:)</ss>", record.ContentXml);
    }
  }
}