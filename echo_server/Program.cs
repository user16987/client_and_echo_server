using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace echo_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread tread = new Thread(client);
            tread.Start();
        }

        public static int count = 0;
        
        public static void client()
        {
            count++;
            NamedPipeServerStream pipe = new NamedPipeServerStream("myPipe", PipeDirection.InOut, 100);
            pipe.WaitForConnection();
            Thread tread = new Thread(client);
            tread.Start();
            Console.WriteLine("clients connection number:"+count);
            StreamReader rd = new StreamReader(pipe);
            StreamWriter wr = new StreamWriter(pipe);
            wr.AutoFlush = true;
            while (true)
                {
                string str = rd.ReadLine();
                Console.WriteLine("read message: " + str);
                wr.WriteLine("from client number: "+(count-1)+", message: "+str+", ");
                }
        }        
    }
}

