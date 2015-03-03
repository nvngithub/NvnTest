using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NvnTest.Candidate {
    public partial class BrowserForm : Form {
        private List<string> urls = new List<string>();
        private string url = string.Empty;

        public BrowserForm() {
            InitializeComponent();

            webBrowser.Navigating += new WebBrowserNavigatingEventHandler(webBrowser_Navigating);
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            webBrowser.NewWindow += new CancelEventHandler(webBrowser_NewWindow);
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            lblCurrentUrl.Text = e.Url.AbsoluteUri;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            HtmlElementCollection links = webBrowser.Document.Links;
            foreach (HtmlElement element in links) {
                element.AttachEventHandler("onclick", LinkClicked);
            }

            if (e.Url.AbsoluteUri.StartsWith("http")) {
                txtAddress.Text = e.Url.AbsoluteUri;
            }

            if (webBrowser.ReadyState == WebBrowserReadyState.Complete) {
                lblCurrentUrl.Text = string.Empty;
            }
        }

        private void webBrowser_NewWindow(object sender, CancelEventArgs e) {
            e.Cancel = true;
            webBrowser.Navigate(url);
        }

        private void LinkClicked(object sender, EventArgs e) {
            HtmlElement link = webBrowser.Document.ActiveElement;
            url = link.GetAttribute("href");
        }

        public List<string> Urls {
            get { return urls; }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            urls.Add(e.Url.AbsoluteUri);
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                webBrowser.Navigate(txtAddress.Text);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            webBrowser.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e) {
            webBrowser.GoForward();
        }

        private void btnGo_Click(object sender, EventArgs e) {
            webBrowser.Navigate(txtAddress.Text);
        }
    }
}
