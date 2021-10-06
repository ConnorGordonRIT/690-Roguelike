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

        //  Server Data Variables
        private string data = null;
        private byte[] bytes = new byte[1024];
        private string[] svrArr;

        //  String Variables
        private string sStr = ",,";
        private string eStr = "<C>";

        //  MainMethod - Setup Contact (param IP, Port)
        public void SetupContact(string pIp, int pPort) {
            //  Part - Setup Server
            svrAddress = IPAddress.Parse(pIp);
            svrEndPoint = new IPEndPoint(svrAddress, pPort);

            //  Part - Setup Listen Socket
            svrListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //  Part - First Contact
            FirstContact();
        }

        //  SubMethod of SetupContact - FirstContact
        private void FirstContact() {
            try {
                svrListen.Connect(svrEndPoint);

                //  Part - Get Client IP
                IPHostEntry clientEntry = Dns.GetHostEntry(System.Environment.MachineName);
                IPAddress clientIP = null;

                foreach (IPAddress IP in clientEntry.AddressList) {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                        clientIP = IP;
                    }
                }

                //  Part - Transmit First Contact Message
                data = "FC" + sStr + clientIP.ToString() + sStr + eStr;
                bytes = Encoding.ASCII.GetBytes(data);

                svrListen.Send(bytes);

                //  Part - Recieve First Contact Response
                data = null;

                bool first = true;
                while (first == true) {
                    int svrRecive = svrListen.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, svrRecive);
                    if (data.IndexOf(eStr) > -1) {
                        first = false;
                    }
                }

                //  SubPart - Handle PlayerTag Assignment
                svrArr = data.Split(sStr);
                if (svrArr[0] == "PT") {
                    playerTag = svrArr[1];
                }

                svrListen.Shutdown(SocketShutdown.Both);
                svrListen.Close();
            }
            catch (ArgumentNullException ae) {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se) {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e) {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }
    }
}
