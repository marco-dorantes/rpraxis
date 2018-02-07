using System;
using System.Data;
using System.IO;

namespace Museum.Service.DataAccess.LocalStore
{
  class LocalFile : IDataReader
  {
    private FileInfo file;
    private FileInfo basefile;
    private StreamReader reader;
    private string[] fields;

    public LocalFile(string filename, string call)
    {
      basefile = new FileInfo(filename);
      if (!basefile.Exists)
      {
        throw new Exception($"{nameof(LocalFile)} not found: {filename}");
      }
      string newname = null;
      do
      {
        var ms = DateTime.Now.TimeOfDay.TotalMilliseconds;
        newname = $"{Path.GetFileNameWithoutExtension(basefile.Name)}_{call}_at_{ms}.txt";
        file = new FileInfo(newname);
        newname = file.Exists ? null : file.FullName;
      } while (string.IsNullOrWhiteSpace(newname));
      Name = newname;
      Prepare();
    }
    public string Name { get; private set; }
    public void Prepare()
    {
      basefile.CopyTo(file.FullName, true);
      reader = new StreamReader(new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 2048, FileOptions.RandomAccess));
    }
    public object this[int i] => throw new NotImplementedException();

    public object this[string name] => throw new NotImplementedException();

    public int Depth => throw new NotImplementedException();

    public bool IsClosed => throw new NotImplementedException();

    public int RecordsAffected => throw new NotImplementedException();

    public int FieldCount => throw new NotImplementedException();

    public void Close()
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public bool GetBoolean(int i)
    {
      throw new NotImplementedException();
    }

    public byte GetByte(int i)
    {
      throw new NotImplementedException();
    }

    public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
    {
      throw new NotImplementedException();
    }

    public char GetChar(int i)
    {
      throw new NotImplementedException();
    }

    public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
    {
      throw new NotImplementedException();
    }

    public IDataReader GetData(int i)
    {
      throw new NotImplementedException();
    }

    public string GetDataTypeName(int i)
    {
      throw new NotImplementedException();
    }

    public DateTime GetDateTime(int i)
    {
      throw new NotImplementedException();
    }

    public decimal GetDecimal(int i)
    {
      throw new NotImplementedException();
    }

    public double GetDouble(int i)
    {
      throw new NotImplementedException();
    }

    public Type GetFieldType(int i)
    {
      throw new NotImplementedException();
    }

    public float GetFloat(int i)
    {
      throw new NotImplementedException();
    }

    public Guid GetGuid(int i)
    {
      throw new NotImplementedException();
    }

    public short GetInt16(int i)
    {
      throw new NotImplementedException();
    }

    public int GetInt32(int i)
    {
      throw new NotImplementedException();
    }

    public long GetInt64(int i)
    {
      throw new NotImplementedException();
    }

    public string GetName(int i)
    {
      throw new NotImplementedException();
    }

    public int GetOrdinal(string name)
    {
      throw new NotImplementedException();
    }

    public DataTable GetSchemaTable()
    {
      throw new NotImplementedException();
    }

    public string GetString(int i)
    {
      string result = null;
      if (i >= 0 && i < fields?.Length)
      {
        result = fields[i];
      }
      else
      {
        throw new IndexOutOfRangeException($"Index {i} not found ({fields?.Length})");
      }
      return result;
    }

    public object GetValue(int i)
    {
      throw new NotImplementedException();
    }

    public int GetValues(object[] values)
    {
      throw new NotImplementedException();
    }

    public bool IsDBNull(int i)
    {
      throw new NotImplementedException();
    }

    public bool NextResult()
    {
      throw new NotImplementedException();
    }

    public bool Read()
    {
      bool result = false;
      string line = reader.ReadLine();
      result = line != null;
      if (result)
      {
        fields = line.Split(',');
      }
      return result;
    }
  }
}