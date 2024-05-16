using ModSim.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ModSim
{
    public partial class FormSim : Form
    {
        //timer variables
        public double secondsSinceStart, twoSecondTimer, tenSecondTimer, threeMinuteTimer;

        public string lastSentence;

        public bool isPluginUsed;

        //usually 256 - send ntrip to serial in chunks
        public int packetSizeNTRIP;

        public bool lastHelloGPS, lastHelloAutoSteer, lastHelloMachine, lastHelloNav;
        public bool isConnectedNav, isConnectedSteer, isConnectedMachine;

        //is the fly out displayed
        public bool isViewAdvanced = false;

        //used to hide the window and not update text fields and most counters
        public bool isAppInFocus = true, isLostFocus;
        public int focusSkipCounter = 121;

        //The base directory where Drive will be stored and fields and vehicles branch from
        public string baseDirectory;


        public FormSim()
        {
            InitializeComponent();
        }

        //First run
        private void FormSim_Load(object sender, EventArgs e)
        {
            if (Settings.Default.setF_workingDirectory == "Default")
                baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\";
            else baseDirectory = Settings.Default.setF_workingDirectory + "\\AgOpenGPS\\";

            if (Settings.Default.setUDP_isOn)
            {
                LoadUDPNetwork();
            }
            else
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label9.Visible = false;

                lblWASCounts.Visible = false;
                lblSwitchStatus.Visible = false;
                lblWorkSwitchStatus.Visible = false;

                label10.Visible = false;
                label12.Visible = false;
                lbl1To8.Visible = false;
                lbl9To16.Visible = false;

                lblIP.Text = "Off";
            }

            latitude = 53.4360564;
            longitude = -111.160047;
        }

        private void FormSim_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();

            if (UDPSocket != null)
            {
                try
                {
                    UDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { UDPSocket.Close(); }
            }
        }

        private void FormSim_Resize(object sender, EventArgs e)
        {
        }



        private void deviceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void btnResetTimer_Click(object sender, EventArgs e)
        {
            threeMinuteTimer = secondsSinceStart;
        }

        private void btnRelayTest_Click(object sender, EventArgs e)
        {
                helloFromAgIO[7] = 1;
        }

        private void lblIP_Click(object sender, EventArgs e)
        {
            lblIP.Text = "";
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    _ = IPA.ToString();
                    lblIP.Text += IPA.ToString() + "\r\n";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

