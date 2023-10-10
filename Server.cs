using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace XADServeiClient
{
    class Server
    {
        static void Main(string[] args)
        {
            bool leyendoOescribiendo = false;
            TcpListener listener = new TcpListener(30003);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            while (true)
            {
                if (leyendoOescribiendo)
                {
                    string mensaje = Console.ReadLine();
                    Console.WriteLine("Out: " + mensaje);
                    sw.WriteLine(mensaje);
                    leyendoOescribiendo = false;
                }
                else
                {
                    Console.WriteLine("In: " + sr.ReadLine());
                    leyendoOescribiendo = true;
                }
            }
        }
    }
}
