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
        private bool dataRead;
        private string dataRaw;
        private byte[] dataBytes;
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
            svrListen.Connect(svrEndPoint);

            //  Part - Transmit First Contact Message
            dataRaw = "FC" + sStr + eStr;
            dataBytes = Encoding.ASCII.GetBytes(dataRaw);
            svrListen.Send(dataBytes);

            //  Part - Recieve First Contact Response
            dataRaw = "";

            //  Part - Read Data
            dataRead = false;
            while (dataRead == false) {
                int bytesRec = svrListen.Receive(dataBytes);
                dataRaw += Encoding.ASCII.GetString(dataBytes, 0, bytesRec);
                if (dataRaw.IndexOf(eStr) > -1) {
                    dataRead = true;
                }
            }

            //  SubPart - Handle PlayerTag Assignment
            svrArr = dataRaw.Split(sStr);
            if (svrArr[0] == "PT") {
                playerTag = svrArr[1];
            }

            svrListen.Shutdown(SocketShutdown.Both);
            svrListen.Close();
        }

        //  MainMethod - Server Send
        public void ServerSend()
    }
}
