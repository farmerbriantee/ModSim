using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModSim
{
    public partial class FormLoop
    {
        // UDP Sockets
        public Socket UDPSocket;
        private EndPoint endPointUDP = new IPEndPoint(IPAddress.Any, 0);

        public bool isUDPNetworkConnected;

        //UDP Endpoints
        public IPEndPoint epAgIO = new IPEndPoint(IPAddress.Parse(
                Properties.Settings.Default.etIP_SubnetOne.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetTwo.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetThree.ToString() + ".255"), 9999);
        
        // Data stream
        private byte[] buffer = new byte[1024];

        //used to send communication check pgn= C8 or 200
        private byte[] helloFromAgIO = { 0x80, 0x81, 0x7F, 200, 3, 56, 0, 0, 0x47 };

        public IPAddress ipCurrent;

        //initialize udp network
        public void LoadUDPNetwork()
        {
            helloFromAgIO[5] = 56;

            lblIP.Text = "";
            try //udp network
            {
                string bob = Dns.GetHostName();
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string data = IPA.ToString();
                        lblIP.Text += IPA.ToString().Trim() + "\r\n";
                    }
                }

                // Initialise the socket
                UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                UDPSocket.Bind(new IPEndPoint(IPAddress.Any, 8888));
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP,
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                isUDPNetworkConnected = true;

                //if (!isFound)
                //{
                //    MessageBox.Show("Network Address of Modules -> " + Properties.Settings.Default.setIP_localAOG+"[2 - 254] May not exist. \r\n"
                //    + "Are you sure ethernet is connected?\r\n" + "Go to UDP Settings to fix.\r\n\r\n", "Network Connection Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //btnUDP.BackColor = Color.Red;
                //    lblIP.Text = "Not Connected";
                //}
            }
            catch (Exception e)
            {
                //WriteErrorLog("UDP Server" + e);
                MessageBox.Show(e.Message, "Serious Network Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblIP.Text = "Error";
            }
        }

        #region Send UDP

        public void SendUDPMessage(byte[] byteData)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Send packet to the zero
                    if (byteData.Length != 0)
                    {
                        UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                           epAgIO, new AsyncCallback(SendDataUDPAsync), null);
                    }
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                }
            }
        }

        public void SendUDPMessage(string message)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Get packet as byte array to send
                    byte[] byteData = Encoding.ASCII.GetBytes(message);
                    if (byteData.Length != 0)
                        UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                            epAgIO, new AsyncCallback(SendDataUDPAsync), null);
                }
                catch (Exception)
                {
                }
            }
        }


        private void SendDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                UDPSocket.EndSend(asyncResult);
            }
            catch (Exception)
            {
                //WriteErrorLog(" UDP Send Data" + e.ToString());
                //MessageBox.Show("SendData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Receive UDP

        private void ReceiveDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                // Receive all data
                int msgLen = UDPSocket.EndReceiveFrom(asyncResult, ref endPointUDP);

                byte[] localMsg = new byte[msgLen];
                Array.Copy(buffer, localMsg, msgLen);

                // Listen for more connections again...
                UDPSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPointUDP, 
                    new AsyncCallback(ReceiveDataUDPAsync), null);

                BeginInvoke((MethodInvoker)(() => ReceiveFromUDP(localMsg)));

            }
            catch (Exception)
            {
                //WriteErrorLog("UDP Recv data " + e.ToString());
                //MessageBox.Show("ReceiveData Error: " + e.Message, "UDP Server", MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            }
        }


        static byte [] PGN_253 = { 128, 129, 126, 253, 8, 0, 0, 0, 0, 0, 0, 0, 0, 12 };
        int PGN_253_Size = PGN_253.Length - 1;

        //Heart beat hello AgIO
        static byte [] helloFromAutoSteer = { 128, 129, 126, 126, 5, 0, 0, 0, 0, 0, 71 };
        short helloSteerPosition = 0;


        //Relays
        bool isRelayActiveHigh = true;
        byte relay = 0, relayHi = 0, uTurn = 0;
        byte xte = 0;

        //Switches
        int remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;

        //On Off
        byte guidanceStatus = 0;
        byte prevGuidanceStatus = 0;
        bool guidanceStatusChanged = false;

        //speed sent as *10
        double gpsSpeed = 0;

        //steering variables
        double steerAngleActual = 8.8;
        double steerAngleSetPoint = 0; //the desired angle from AgOpen
        int steeringPosition = 0; //from steering sensor
        double steerAngleError = 0; //setpoint - actual

        private void ReceiveFromUDP(byte[] data)
        {
            try
            {
                //Hello and scan reply
                if (data[0] == 0x80 && data[1] == 0x81)
                {
                    switch (data[3])
                    {
                        case 126:
                            {
                                //traffic.helloFromAutoSteer = 0;
                                if (isViewAdvanced)
                                {
                                    double actualSteerAngle = (Int16)((data[6] << 8) + data[5]);
                                    lblWAS.Text = (actualSteerAngle * 0.01).ToString("N1");
                                    lblWASCounts.Text = ((Int16)((data[8] << 8) + data[7])).ToString();

                                    lblSwitchStatus.Text = ((data[9] & 2) == 2).ToString();
                                    lblWorkSwitchStatus.Text = ((data[9] & 1) == 1).ToString();
                                }
                                break;
                            }

                        case 254:
                            {
                                gpsSpeed = ((double)(data[5] | data[6] << 8)) * 0.1;

                                prevGuidanceStatus = guidanceStatus;

                                guidanceStatus = data[7];
                                guidanceStatusChanged = (guidanceStatus != prevGuidanceStatus);

                                //Bit 8,9    set point steer angle * 100 is sent
                                steerAngleSetPoint = ((float)(data[8] | data[9] << 8)) * 0.01; //high low bytes

                                //Bit 10 Tram 
                                xte = data[10];

                                //Bit 11
                                relay = data[11];

                                //Bit 12
                                relayHi = data[12];

                                //----------------------------------------------------------------------------
                                //Serial Send to agopenGPS

                                int sa = (int)(steerAngleActual * 100);

                                PGN_253[5] = unchecked((byte)((int)(sa)));
                                PGN_253[6] = unchecked((byte)((int)(sa) >> 8));

                                //heading         
                                PGN_253[7] = unchecked((byte)((int)(9999)));
                                PGN_253[8] = unchecked((byte)((int)(9999) >> 8)); 

                                //roll
                                PGN_253[9] = unchecked((byte)((int)(8888)));
                                PGN_253[10] = unchecked((byte)((int)(8888) >> 8));

                                switchByte = 0;
                                switchByte |= ((int)remoteSwitch << 2); //put remote in bit 2
                                switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
                                switchByte |= workSwitch;

                                PGN_253[11] = (byte)switchByte;
                                PGN_253[12] = 44;  //(uint8_t)pwmDisplay;

                                //checksum
                                int CK_A = 0;
                                for (int i = 2; i < PGN_253_Size; i++)
                                    CK_A = (CK_A + PGN_253[i]);

                                PGN_253[PGN_253_Size] = unchecked((byte)((int)(CK_A)));

                                SendUDPMessage(PGN_253);

                                break;
                            }

                        case 200: // Hello from AgIO
                            {
                                int sa = (int)(steerAngleActual * 100);

                                helloFromAutoSteer[5] = unchecked((byte)((int)(sa)));
                                helloFromAutoSteer[6] = unchecked((byte)((int)(sa) >> 8));

                                helloFromAutoSteer[7] = 0;
                                helloFromAutoSteer[8] = 0;
                                helloFromAutoSteer[9] = (byte)switchByte;

                                SendUDPMessage(helloFromAutoSteer);

                                break;
                            }

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        default:
                            {
                                //module return via udp sent to AOG
                                //SendToLoopBackMessageAOG(data);

                                break;
                            }
                    }
                } // end of pgns
            }
            catch
            {

            }
        }

        #endregion
    }
}
