using Microsoft.Web.WebView2.Core;

namespace webviewforms;

public partial class MainForm : Form
{
  public MainForm()
  {
    InitializeComponent();
    this.MainWebView.Source = new Uri(System.IO.Path.Combine(Application.StartupPath, "web", "dist", "index.html"));

    this.MainWebView.CoreWebView2InitializationCompleted += OnWebView2Ready;
  }

  private void OnWebView2Ready(object? sender, EventArgs e)
  {
    this.MainWebView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
  }

  private async void WebView_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
  {
    var json = e.TryGetWebMessageAsString();
    Console.WriteLine(json);
    await this.MainWebView.CoreWebView2.ExecuteScriptAsync("window.receiveMessageFromWinForms('" + json + "')");
  }
}
