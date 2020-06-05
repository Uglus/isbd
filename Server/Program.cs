﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary;
using System.Data.Sql;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Server
{
    class Program
    {
        static TcpListener server;
        
        static void Main(string[] args)
        {
           
            int port = 1488;
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(addr,port);

            try
            {
                server.Start();
                Thread serverThread = new Thread(new ThreadStart(WorkMethod));
                serverThread.Start();

                Console.WriteLine("\n Сервер запущений \n Для зупинки натисніть любу клавішу...");
                Console.ReadKey();

                server.Stop();
                Console.WriteLine("\n Сервер зупинено \n Програма завершена");
            }
            catch (Exception err) { Console.WriteLine(err.Message); }

        }

        static async void WorkMethod()
        {
            try {
                DataManager dm = new DataManager();
                User userType = new User();
                await Task.Run(() => {
                    while(true)
                    {
                      //  dm.test();
                        Console.WriteLine("Очікування запитів...");
                        TcpClient handler = server.AcceptTcpClient();
                        NetworkStream ns = handler.GetStream();
                        BinaryFormatter bf = new BinaryFormatter();

                        var item = bf.Deserialize(ns);
                        Console.WriteLine($"Отриманий об'єкт: {item.GetType()}");

                        //Якщо отриманий об'єкт - юзер
                        if(item.GetType() == userType.GetType())
                        {
                            User user = (User)item;
                            if(user.FuncName == "UserSignUp")
                            {
                                dm.UserSignUp(user);
                            }
                            if(user.FuncName == "UserEdit")
                            {
                                dm.UserEdit(user);
                            }
                            if(user.FuncName == "UserSignIn")
                            {
                                bool result = dm.UserSignIn(user);
                                bf.Serialize(ns, result);
                            }
                        }

                        //
                        //
                        Console.WriteLine($"   >>>Done! {handler.Client.LocalEndPoint}");
                        ns.Close();
                        handler.Close();
                    }
                });

            } catch (Exception err) { Console.WriteLine(err.Message); }
        }
    }
}
