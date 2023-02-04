using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace webviewforms;

partial class MainForm
{
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
      this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
      ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
      this.SuspendLayout();
      // 
      // webView
      // 
      this.webView.AllowExternalDrop = true;
      this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.webView.CreationProperties = null;
      this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
      this.webView.Location = new System.Drawing.Point(0, 0);
      this.webView.Name = "webView";
      this.webView.Size = new System.Drawing.Size(800, 451);
      this.webView.TabIndex = 0;
      this.webView.ZoomFactor = 1D;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.webView);
      this.Name = "MainForm";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
      this.ResumeLayout(false);

  }

  #endregion

  private WebView2 webView;

  public WebView2 MainWebView { get => webView; private set => webView = value; }
}
