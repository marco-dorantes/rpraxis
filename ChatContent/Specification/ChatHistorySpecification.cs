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

    [TestMethod, TestCategory("Text_HTML")]
    public void AnchorAndNewline()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:kant,Immanuel Kant,\"--?T::Z\",1529850327436,\"Ok. Let us read, for example, this:\r\n<a href=\"\"https://plato.stanford.edu/entries/truth/\"\">https://plato.stanford.edu/entries/truth/</a>\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("Ok. Let us read, for example, this:\r\n<a href=\"\"https://plato.stanford.edu/entries/truth/\"\">https://plato.stanford.edu/entries/truth/</a>", record.ContentXml);
    }

    [TestMethod, TestCategory("Text_HTML")]
    public void Anchor()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"--?T::Z\",1516852436904,\"And all that, in Spanish, here <a href=\"\"http://www.filosofia.org/filomat/index.htm\"\">http://www.filosofia.org/filomat/index.htm</a>\"";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("And all that, in Spanish, here <a href=\"\"http://www.filosofia.org/filomat/index.htm\"\">http://www.filosofia.org/filomat/index.htm</a>", record.ContentXml);
    }

    [TestMethod, TestCategory("Text_HTML")]
    public void CharacterEntity()
    {
      //Arrange
      string chat_entry = "live:kant,Immanuel Kant,live:hume,David Hume,\"--?T::Z\",1516952436904,But, is &quot;truth&quot; directly related to &quot;freedom&quot;?";
      var parser = new ChatHistoryModule.ChatRecordParser();

      //Act
      var record = parser.Parse(chat_entry);

      //Assert
      Assert.IsNotNull(record);
      Assert.AreEqual<string>("But, is &quot;truth&quot; directly related to &quot;freedom&quot;?", record.ContentXml);
    }
  }
}