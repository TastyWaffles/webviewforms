public static class TestData
{
  public static object[] generateTestData()
  {
    var data = new List<object>();

    for (int i = 0; i < 10; i++)
    {
      data.Add(
         new
         {
           uid = "" + (123000 + i),
           title = String.Format("test title {0}", i),
           description = String.Format("some description {0}", i),
           serialNumber = "" + (9876 - i),
           dateCreated = DateTimeOffset.Now.ToUnixTimeMilliseconds() - (i * 1000 * 60 * 60),
         }
      );
    }

    return data.ToArray();
  }
}