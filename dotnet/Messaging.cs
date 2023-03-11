public static class Messaging
{
  public static async Task<string> PostMessage(webviewforms.MainForm form, string destination, string messageJson)
  {
    return await form.MainWebView.CoreWebView2.ExecuteScriptAsync(string.Format("window.{0}('{1}')", destination, messageJson));
  }
}