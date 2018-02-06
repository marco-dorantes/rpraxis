namespace Museum.Service.DataAccess
{
  public interface IMuseumStore
  {
    System.Data.IDataReader GetSculptures(string filter);
  }
}