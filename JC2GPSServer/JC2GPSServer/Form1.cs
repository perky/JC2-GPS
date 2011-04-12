using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Net;
using System.Net.Sockets;
using Drew.Util;

namespace JC2GPSServer
{
    public partial class Form1 : Form
    {
        JC2GPSServer.ProcessMemoryReader pReader;
        private Socket m_socket = null;
        private float xval, yval, zval;
        private float lastx = 0;
        private float lasty = 0;
        private float lastz = 0;
        private float velocity = 0;
        private MovingAverageCalculator speedCalculator = new MovingAverageCalculator(4);

        public Form1()
        {
            InitializeComponent();

            IPEndPoint localEP = new IPEndPoint(System.Net.IPAddress.Any, 49898);
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            m_socket.Bind(localEP);

            pReader = new JC2GPSServer.ProcessMemoryReader();
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("JustCause2");

            if (myProcesses.Length > 0)
            {
                pReader.ReadProcess = myProcesses[0];
                pReader.OpenProcess();

                System.Timers.Timer updateTimer = new System.Timers.Timer();
                updateTimer.Interval = 500;
                updateTimer.Elapsed += new ElapsedEventHandler(broadcast);
                updateTimer.SynchronizingObject = this;
                updateTimer.Start();

                System.Timers.Timer checkPostionAndSpeedTimer = new System.Timers.Timer();
                checkPostionAndSpeedTimer.Interval = 300;
                checkPostionAndSpeedTimer.Elapsed += new ElapsedEventHandler(checkPositionAndSpeed);
                checkPostionAndSpeedTimer.SynchronizingObject = this;
                checkPostionAndSpeedTimer.Start();
            }
        }

        private void checkPositionAndSpeed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int bytesReaded;
            byte[] memory;

            // Get X position.
            memory = pReader.ReadProcessMemory((IntPtr)0x011FA2E4, 8, out bytesReaded);
            xval = BitConverter.ToSingle(memory, 0);

            // Get Y position.
            memory = pReader.ReadProcessMemory((IntPtr)0x011FA2EC, 8, out bytesReaded);
            yval = BitConverter.ToSingle(memory, 0);

            // Get Z Position.
            memory = pReader.ReadProcessMemory((IntPtr)0x011FA2E8, 8, out bytesReaded);
            zval = BitConverter.ToSingle(memory, 0);

            // Calculate Velocity.
            float dx = xval - lastx;
            float dy = yval - lasty;
            float dz = zval - lastz;
            double dist = Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
            dist = ((dist * 3600) / 1000)*1.5;
            lastx = xval;
            lasty = yval;
            lastz = zval;

            // Add velocity to moving average.
            velocity = speedCalculator.NextValue((float)dist);
            //velocity = (float)dist;

            xval = (xval + 16384) * 0.0625f;
            yval = (yval + 16384) * 0.0623f;
            zval -= 200;

            xlabel.Text = Math.Floor(xval).ToString();
            ylabel.Text = Math.Floor(yval).ToString();
            zlabel.Text = Math.Floor(zval).ToString();
            speedlabel.Text = Math.Floor(velocity).ToString();
        }

        private void broadcast(object sender, System.Timers.ElapsedEventArgs e)
        {
            IPAddress ip = IPAddress.Parse("192.168.1.66");
            IPEndPoint endPoint = new IPEndPoint(ip, 49898);

            String message = xval.ToString() + "," + yval.ToString() + "," + Math.Floor(zval).ToString() + "," + Math.Floor(velocity).ToString();
            Byte[] bytes = Encoding.UTF8.GetBytes(message);
            m_socket.SendTo(bytes, endPoint);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
