using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;


namespace HardDriveSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // hb serial please
            textBox1.Text = GetHDDSerial();
        }

        public string GetHDDSerial()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {         // get the hardware serial no. 
                if (wmi_HD["SerialNumber"] != null)
                    return wmi_HD["SerialNumber"].ToString();
            }
            return string.Empty;
        } 
    }
}
