using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModSim
{
    public partial class FormSim
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
        int remoteSwitch = 1, workSwitch = 1, steerSwitch = 1, switchByte = 0;

        //On Off
        byte guidanceStatus = 0;
        byte prevGuidanceStatus = 0;
        bool guidanceStatusChanged = false;

        //speed sent as *10
        double gpsSpeed = 0;

        //steering variables
        double steerAngleActual = 0;
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
                        case 254:
                            {
                                gpsSpeed = ((double)(data[5] | data[6] << 8)) * 0.1;

                                prevGuidanceStatus = guidanceStatus;

                                guidanceStatus = data[7];
                                guidanceStatusChanged = (guidanceStatus != prevGuidanceStatus);

                                lblGuidanceStatus.Text = guidanceStatus.ToString();
                                lblSteerSwitchStatus.Text = steerSwitch.ToString();

                                //if (steerConfig.SteerButton == 1)
                                //{
                                //    if (guidanceStatus == 1) steerSwitch = 0;
                                //}

                                //Bit 8,9    set point steer angle * 100 is sent
                                steerAngleSetPoint = ((float)(data[8] | data[9] << 8)) * 0.01; //high low bytes

                                //Bit 10 Tram 
                                xte = data[10];

                                //Bit 11
                                relay = data[11];

                                //Bit 12
                                relayHi = data[12];

                                lbl1To8.Text = Convert.ToString(data[11], 2).PadLeft(8, '0');
                                lbl9To16.Text = Convert.ToString(data[12], 2).PadLeft(8, '0');

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
                                switchByte |= (steerSwitch << 1);   //put steerSwitch status in bit 1 position
                                switchByte |= workSwitch;

                                PGN_253[11] = (byte)switchByte;
                                PGN_253[12] = 44;  //(uint8_t)pwmDisplay;

                                //checksum
                                int CK_A = 0;
                                for (int i = 2; i < PGN_253_Size; i++)
                                    CK_A = (CK_A + PGN_253[i]);

                                PGN_253[PGN_253_Size] = unchecked((byte)((int)(CK_A)));

                                SendUDPMessage(PGN_253);

                                if (btnSteerButtonRemote.BackColor == Color.Green)
                                {
                                    btnSteerButtonRemote.BackColor = Color.White;
                                }

                                break;
                            }

                        case 252:
                            {
                                //PID values
                                steerSettings.Kp = data[5];   // read Kp from AgOpenGPS
                                lblKp.Text = steerSettings.Kp.ToString();

                                steerSettings.highPWM = data[6]; // read high pwm
                                lblHighPWM.Text = steerSettings.highPWM.ToString();

                                steerSettings.lowPWM = data[7];   // read lowPWM from AgOpenGPS              

                                steerSettings.minPWM = data[8]; //read the minimum amount of PWM for instant on\
                                lblMinPWM.Text = steerSettings.minPWM.ToString();

                                float temp = steerSettings.minPWM;
                                temp *= 1.2f;
                                steerSettings.lowPWM = (byte)temp;
                                lblLowPWM.Text = steerSettings.lowPWM.ToString();

                                steerSettings.steerSensorCounts = data[9]; //sent as setting displayed in AOG
                                lblWAS_Counts.Text = steerSettings.steerSensorCounts.ToString();

                                steerSettings.wasOffset = (data[10]);  //read was zero offset Lo

                                steerSettings.wasOffset |= (data[11] << 8);  //read was zero offset Hi
                                lblWAS_Offset.Text = steerSettings.wasOffset.ToString();

                                steerSettings.AckermanFix = (float)data[12] * 0.01;
                                lblAckerman.Text = (steerSettings.AckermanFix * 100).ToString("N0") + "%";

                                break;
                            }

                        case 251:
                            {
                                int sett = data[5]; //setting0

                                if ((sett & (1 << 0)) != 0) steerConfig.InvertWAS = 1; else steerConfig.InvertWAS = 0;
                                lblInvertWAS.Text = steerConfig.InvertWAS.ToString();

                                if ((sett & (1 << 1)) != 0) steerConfig.IsRelayActiveHigh = 1; else steerConfig.IsRelayActiveHigh = 0;
                                lblRelayActHigh.Text = steerConfig.IsRelayActiveHigh.ToString();

                                if ((sett & (1 << 2)) != 0) steerConfig.MotorDriveDirection = 1; else steerConfig.MotorDriveDirection = 0;
                                lblMotorDirection.Text = steerConfig.MotorDriveDirection.ToString();

                                if ((sett & (1 << 3)) != 0) steerConfig.SingleInputWAS = 1; else steerConfig.SingleInputWAS = 0;
                                lblSingleInputWAS.Text = steerConfig.SingleInputWAS.ToString();

                                if ((sett & (1 << 4)) != 0) steerConfig.CytronDriver = 1; else steerConfig.CytronDriver = 0;
                                lblCytron.Text = steerConfig.CytronDriver.ToString();

                                if ((sett & (1 << 5)) != 0) steerConfig.SteerSwitch = 1; else steerConfig.SteerSwitch = 0;
                                lblSteerSw.Text = steerConfig.SteerSwitch.ToString();

                                if ((sett & (1 << 6)) != 0) steerConfig.SteerButton = 1; else steerConfig.SteerButton = 0;
                                lblSteerBtn.Text = steerConfig.SteerButton.ToString();

                                if ((sett & (1 << 7)) != 0) steerConfig.ShaftEncoder = 1; else steerConfig.ShaftEncoder = 0;
                                lblShaftEnc.Text = steerConfig.ShaftEncoder.ToString();

                                steerConfig.PulseCountMax = data[6];
                                lblPulseCounts.Text = steerConfig.PulseCountMax.ToString();

                                //was speed
                                //data[7]; 

                                sett = data[8]; //setting1 - Danfoss valve etc

                                if ((sett & (1 << 0)) != 0) steerConfig.IsDanfoss = 1; else steerConfig.IsDanfoss = 0;
                                lblDanfoss.Text = steerConfig.IsDanfoss.ToString();

                                if ((sett & (1 << 1)) != 0) steerConfig.PressureSensor = 1; else steerConfig.PressureSensor = 0;
                                lblPressure.Text = steerConfig.PressureSensor.ToString();

                                if ((sett & (1 << 2)) != 0) steerConfig.CurrentSensor = 1; else steerConfig.CurrentSensor = 0;
                                lblCurrent.Text = steerConfig.CurrentSensor.ToString();

                                if ((sett & (1 << 3)) != 0) steerConfig.IsUseY_Axis = 1; else steerConfig.IsUseY_Axis = 0;
                                lblUseY_Axis.Text = steerConfig.IsUseY_Axis.ToString();
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

                        case 201:
                            {
                                //make really sure this is the subnet pgn
                                if (data[4] == 5 && data[5] == 201 && data[6] == 201)
                                {
                                    lblIPSet1.Text = data[7].ToString();
                                    lblIPSet2.Text = data[8].ToString();
                                    lblIPSet3.Text = data[9].ToString();

                                    TimedMessageBox(2000, "IP Set", "New Values Changed");
                                }

                                break;
                            }

                        //scan reply
                        case 202:
                            {
                                //make really sure this is the reply pgn
                                if (data[4] == 3 && data[5] == 202 && data[6] == 202)
                                {
                                    byte [] scanReply = { 128, 129, 126, 203, 7,
                                        Properties.Settings.Default.etIP_SubnetOne,
                                        Properties.Settings.Default.etIP_SubnetTwo,
                                        Properties.Settings.Default.etIP_SubnetThree, 126,

                                        //source ips

                                        Properties.Settings.Default.etIP_SubnetOne,
                                        Properties.Settings.Default.etIP_SubnetTwo,
                                        Properties.Settings.Default.etIP_SubnetThree, 23 };

                                    //checksum
                                    int CK_A = 0;
                                    for (int i = 2; i < scanReply.Length - 1; i++)
                                    {
                                        CK_A = (CK_A + scanReply[i]);
                                    }
                                    scanReply[scanReply.Length - 1] = unchecked((byte)((int)(CK_A))); 

                                    SendUDPMessage(scanReply);
                                }
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

    public static class steerConfig
    {            
        public static byte InvertWAS = 0;
        public static byte IsRelayActiveHigh = 0; //if zero, active low (default)
        public static byte MotorDriveDirection = 0;
        public static byte SingleInputWAS = 1;
        public static byte CytronDriver = 1;
        public static byte SteerSwitch = 0;  //1 if switch selected
        public static byte SteerButton = 0;  //1 if button selected
        public static byte ShaftEncoder = 0;
        public static byte PressureSensor = 0;
        public static byte CurrentSensor = 0;
        public static byte PulseCountMax = 5;
        public static byte IsDanfoss = 0;
        public static byte IsUseY_Axis = 0;
    }

    public static class steerSettings
    {
        public static byte Kp = 120;  //proportional gain
        public static byte lowPWM = 30;  //band of no action
        public static int wasOffset = 0;
        public static byte minPWM = 25;
        public static byte highPWM = 160;//max PWM value
        public static double steerSensorCounts = 30;
        public static double AckermanFix = 1;     //sent as percent
    }
}
