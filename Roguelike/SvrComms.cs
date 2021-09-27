using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Roguelike {
    class SvrComms {
        //  Player Variables
        private string playerTag;

        //  Server Variables
        private IPAddress svrAddress;
        private IPEndPoint svrEndPoint;

        private Socket svrListen;
        private Socket svrHandle;

        //  Server Data Variables
        private string svrData = null;
        private byte[] svrBytes = new byte[1024];
        private string[] svrArr;

        private string playerData = null;
        private byte[] playerBytes = new byte[1024];

        //  MainMethod - Setup Contact (param IP, Port)
        public void SetupContact(string pIp, int pPort) {
            //  Part - Setup Server
            svrAddress = IPAddress.Parse(pIp);
            svrEndPoint = new IPEndPoint(svrAddress, pPort);

            //  Part - Setup Listen and Handle Sockets
            svrListen = new Socket(svrAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            svrListen.Bind(svrEndPoint);
            svrListen.Listen(10);
            svrHandle = svrListen.Accept();

            //  Part - First Contact
            FirstContact();
        }

        //  SubMethod of SetupContact - FirstContact
        private void FirstContact() {
            //  Part - Get Client IP
            IPHostEntry clientEntry = Dns.GetHostEntry(System.Environment.MachineName);
            IPAddress clientIP = null;
            foreach (IPAddress IP in clientEntry.AddressList) {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    clientIP = IP;
                }
            }

            //  Part - Transmit First Contact Message
            playerData = clientIP.ToString() + ",,FC,,<C>";
            Console.WriteLine("Player Data : " + playerData);

            playerBytes = Encoding.ASCII.GetBytes(playerData);
            svrHandle.Send(playerBytes);

            //  Part - Recieve First Contact Response
            while (true) {
                int svrRecive = svrHandle.Receive(svrBytes);
                svrData += Encoding.ASCII.GetString(svrBytes, 0, svrRecive);
                if (svrData.IndexOf("<C>") > -1) {
                    break;
                }

                //  SubPart - Handle PlayerTag Assignment
                svrArr = svrData.Split(",,");
                if (svrArr[0] == "PT") {
                    playerTag = svrArr[1];
                    Console.WriteLine("Player Tag  : " + playerTag);
                }
            }
        }
    }
}
