//No attack for the shit & stolen code. Fuck you all.
using System;
using System.Net;
using System.Net.Sockets;

namespace http {
    class FI
    {
        
        static void Main()
        {
            string wellwellwell = string.Empty;
            string port = "9890";


            Console.WriteLine("Start.\nThis application reveals your device's IP address.Continue? [y/n]");
            wellwellwell = Console.ReadLine();
            wellwellwell.ToLower();
            if (wellwellwell == "y")
            {
                goto ip;
            }
            else if (wellwellwell == "yes")
            {
                goto ip;

            }
            else return;

        ip:
            string localIP = string.Empty;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            Console.WriteLine("IP Address = " + localIP + ":" + port);

        //goto playground;

        //playground:
            //Console.WriteLine("http://" + localIP + ":8081");

        http:
            Console.WriteLine("Input:");
            string string1 = Console.ReadLine();
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://" + localIP + ":" + port + "/");
            listener.Start();
            Console.WriteLine("Listening...");
            Task task = Task.Factory.StartNew(() =>
            {
                while (listener.IsListening)
                {
                    HttpListenerContext context = listener.GetContext();
                    Console.WriteLine("Http requesting...");
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    Console.WriteLine("Http responsing...");
                    string responseString = string1;
                    using (StreamWriter writer = new StreamWriter(response.OutputStream))
                    {
                        writer.WriteLine(responseString);
                    }
                }
            });
            task.Wait();



            



        }
    }
}
