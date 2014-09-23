using ShareWindow.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ShareWindow
{
    class Response
    {
        public bool TextResponse { get; set; }
        public string Text { get; set; }
        public byte[] Binary { get; set; }
    }

    class WebServer : IDisposable
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, Response> _responderMethod;
        private bool _started = false;

        public WebServer(Func<HttpListenerRequest, Response> method, params string[] prefixes)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("URI Prefixes must be present");

            if (method == null)
                throw new ArgumentException("Processing method must be specified");
            foreach (string s in prefixes)
                _listener.Prefixes.Add(MakeCorrectURI(GetHost(), s));

            _responderMethod = method;
        }

        private string MakeCorrectURI(string host, string prefix)
        {
            if (string.IsNullOrEmpty(prefix) || prefix == "/")
                return host + (host.EndsWith("/") ? "" : "/");
            return host + (host.EndsWith("/") ? prefix : "/" + prefix) + (prefix.EndsWith("/") ? "" : "/");
        }

        private string GetLocalIPAddress()
        {
            return "+";
            /*IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;*/
        }

        private string GetHost()
        {
            return "http://" + GetLocalIPAddress() + ":" + Settings.Default.Port + "/";
        }

        public void Start()
        {
            if (_started)
                return;
            _started = true;
            try
            {
                _listener.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to start HTTP server. Please check settings"+Environment.NewLine+"Exception : "+e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (new SettingsForm().ShowDialog() == DialogResult.OK)
                    Settings.Default.Save();
                Environment.Exit(-1);
            }

            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (_started && _listener.IsListening)
                {
                    ThreadPool.QueueUserWorkItem((c) =>
                    {
                        var ctx = c as HttpListenerContext;
                        try
                        {
                            var resp = _responderMethod(ctx.Request);
                            if (resp.TextResponse)
                            {
                                string rstr = resp.Text;
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            else
                            {
                                byte[] content = resp.Binary;
                                ctx.Response.ContentLength64 = content.Length;
                                ctx.Response.OutputStream.Write(content, 0, content.Length);
                            }
                        }
                        catch { }
                        finally
                        {
                            ctx.Response.OutputStream.Flush();
                            ctx.Response.OutputStream.Close(); 
                        }
                    }, _listener.GetContext());

                    if (!_started)
                    {
                        _listener.Close();
                        _listener.Stop();
                    }
                }
            });
        }

        public void Stop()
        {
            if (_listener == null)
                return;

            _started = false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
