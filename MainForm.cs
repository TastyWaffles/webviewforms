using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Web.WebView2.Core;

namespace webviewforms;

public partial class MainForm : Form
{
  public MainForm()
  {
    InitializeComponent();

    // Change the title of the form
    this.Text = "Placeholder Title";

    // Point the webview to the index.html file
    this.MainWebView.Source = new Uri(System.IO.Path.Combine(Application.StartupPath, "web", "dist", "index.html"));

    // Attach WebMessageReceived handler once initalisation is complete
    this.MainWebView.CoreWebView2InitializationCompleted += AttachMessageHandler;
  }

  /// <summary>
  /// Attach message handler to the WebMessageReceived event
  /// </summary>
  private void AttachMessageHandler(object? sender, EventArgs e)
  {
    this.MainWebView.CoreWebView2.WebMessageReceived += async (s, e) =>
    {
      var json = e.TryGetWebMessageAsString();
      Console.WriteLine(json);

      //deserialize json into Record object
      var record = JsonSerializer.Deserialize<JsonNode>(json);

      await Router.handleMessage(this, record?["type"]?.GetValue<string>(), record?["payload"]);
    };
  }
}
