using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace XADServeiClient
{
    class Client
    {
        static void Main(string[] args)
        {
            bool leyendoOescribiendo = true;
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 30003);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            while (true)
            {
                if (leyendoOescribiendo) {
                    string mensaje = Console.ReadLine();
                    Console.WriteLine("Out: " + mensaje);
                    sw.WriteLine(mensaje);
                    sw.Flush();
                    leyendoOescribiendo = false;
                } else {
                    Console.WriteLine("In: " + sr.ReadLine());
                    leyendoOescribiendo = true;
                }
            }
        }
    }
}