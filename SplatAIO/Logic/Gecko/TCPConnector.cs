using System;
using System.IO;
using System.Net.Sockets;

namespace SplatAIO.Logic.Gecko
{
    internal class TCPConnector
    {
        private TcpClient client;
        private NetworkStream stream;

        public TCPConnector(string host, int port)
        {
            Host = host;
            Port = port;
            client = null;
            stream = null;
        }

        public string Host { get; }
        public int Port { get; }

        public void Connect()
        {
            try
            {
                Close();
            }
            catch (Exception)
            {
            }
            client = new TcpClient();
            client.NoDelay = true;
            var ar = client.BeginConnect(Host, Port, null, null);
            var wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    client.Close();
                    throw new IOException("Connection timoeut.", new TimeoutException());
                }

                client.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            }
            stream = client.GetStream();
            stream.ReadTimeout = 10000;
            stream.WriteTimeout = 10000;
        }

        public void Close()
        {
            try
            {
                if (client == null)
                    throw new IOException("Not connected.", new NullReferenceException());
                client.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                client = null;
            }
        }

        public void Purge()
        {
            if (stream == null)
                throw new IOException("Not connected.", new NullReferenceException());
            stream.Flush();
        }

        public void Read(byte[] buffer, uint nobytes, ref uint bytes_read)
        {
            try
            {
                var offset = 0;
                if (stream == null)
                    throw new IOException("Not connected.", new NullReferenceException());
                bytes_read = 0;
                while (nobytes > 0)
                {
                    var read = stream.Read(buffer, offset, (int) nobytes);
                    if (read >= 0)
                    {
                        bytes_read += (uint) read;
                        offset += read;
                        nobytes -= (uint) read;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }

        public void Write(byte[] buffer, int nobytes, ref uint bytes_written)
        {
            try
            {
                if (stream == null)
                    throw new IOException("Not connected.", new NullReferenceException());
                stream.Write(buffer, 0, nobytes);
                if (nobytes >= 0)
                    bytes_written = (uint) nobytes;
                else
                    bytes_written = 0;
                stream.Flush();
            }
            catch (ObjectDisposedException e)
            {
                throw new IOException("Connection closed.", e);
            }
        }
    }
}