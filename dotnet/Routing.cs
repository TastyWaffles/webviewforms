
using System.Text.Json;
using System.Text.Json.Nodes;

public static class Router
{
  ///<summary>
  /// Example of potential messaging
  /// </summary>
  public static async Task handleMessage(webviewforms.MainForm form, string? instruction, JsonNode? payload)
  {
    if ("LOGIN".Equals(instruction))
    {
      await Messaging.PostMessage(form, "receiveLogin", JsonSerializer.Serialize(new
      {
        authenticated = Authenticate(payload?["username"]?.GetValue<string>(), payload?["password"]?.GetValue<string>())
      }));
    }
    else if ("GET_DATA".Equals(instruction))
    {
      var data = TestData.generateTestData();
      var output = JsonSerializer.Serialize(data);
      await Messaging.PostMessage(form, "receiveData", output);
    }
  }

  private static bool Authenticate(string? username, string? password)
  {
    //todo do something with the username and password
    if (username == null || password == null)
    {
      return false;
    }
    return password?.Equals("test") ?? false;
  }
}