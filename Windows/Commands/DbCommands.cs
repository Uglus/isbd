using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary;

namespace Windows.Commands
{
    public class DbCommands
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        int port = 1488;
        
        public User SendAndReceiveUser(User user)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(ns, user);
                user = (User)bf.Deserialize(ns);

                ns.Close();
                client.Close();
            }
            catch (Exception err) { }

            return user;
        }

        public void SendUser(User user)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(ns, user);

                ns.Close();
                client.Close();
            }
            catch (Exception err) { }
        }

    }
}
