﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;
namespace dotnet
{
    class Work {
         public static bool PingHost(string nameOrAddress)
            {
                bool pingable = false;
                Ping pinger = null;

                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
                finally
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }

                return pingable;

            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int DA = 244;
            int V = 212;
            int ID = 255;
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteAscii("xView#2207 Pinger", Color.FromArgb(DA, V, ID));
                Thread.Sleep(500);
                DA -= 60;
                V -= 36;
                ID -= 40;
            }
           Console.WriteAscii("IP: ", Color.FromArgb(DA + 20, V+15, ID));
           string clasa = Console.ReadLine();
           clasa = clasa.Replace(" ","");
           if (clasa == null) {
               Environment.Exit(-1);
           }
           bool isOK = Regex.IsMatch(clasa, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            if (isOK)
            {
            Console.Clear();
           Console.WriteAscii("Pinging " + clasa + "...", Color.FromArgb(DA, V, ID));
           Pinger(clasa, DA, V, ID);
            }
            else
            {
                Console.Clear();
            Console.WriteAscii("Invalid IP address !", Color.FromArgb(255, 0, 0));
            }
           
        }



     public static void Pinger(string clasa, int DA, int V, int ID) {
         int ok = 0;
            while(true) {
               var x = Work.PingHost(clasa);
                if (x == true && ok == 0) {
                     Console.Clear();
                    Console.WriteAscii("Pinging " + clasa + "...", Color.FromArgb(DA, V, ID));
                    Console.WriteAscii(clasa + " is up !", Color.FromArgb(0, 255, 0));
                    ok = 1;
                }
                else if (x == false && ok == 1 || x == false) {
                    Console.Clear();
                    Console.WriteAscii("Pinging " + clasa + "...", Color.FromArgb(DA, V, ID));
                     Console.WriteAscii(clasa + " is down !", Color.FromArgb(255, 0, 0));
                    ok = 0;
                }
                else if(ok == 1 && x==false) {
                    ok = 0;
                }
                else {
                }
                    Thread.Sleep(1500);
               }
            }
        }
}
