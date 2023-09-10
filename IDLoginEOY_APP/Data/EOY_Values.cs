using EOY_WEBapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDLoginEOY_APP.Data
{
    class EOY_Values
    {
        EOY_Functions _functions = new EOY_Functions();

        //METHODS
        public const int GET = 1;
        public const int PUT = 2;
        public const int PATCH = 3;
        public const int DELETE = 4;
        public const int POST = 5;
        //Controllery
        public const string WORKPLACE_CONTROLLER = "Workplace";
        public const string HISTORY_ERRORS_CONTROLLER = "HistoryError";
        public const string SETUP_CONTROLLER = "Setup";
        public const string WORKERS_CONTROLLER = "Workers";
        public const string LOGIN_CONTROLLER = "Login";
        //MyDevice
        public string MyMacAdress
        {
            get {
                string macAddress = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            macAddress = nic.GetPhysicalAddress().ToString();

                        }
                    }
                }
                return _functions.MacFormatingString(macAddress);
            }
        }
        public string  MyDeviceName 
        { 
            get {
                string device = Environment.MachineName;
                return device;
                } 
        }
        public  string MyIpv4Adress { get
            {
                string myIp = "";
                IPHostEntry iph;

                iph = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in iph.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                         myIp = ip.ToString();

                    }
                };
                return myIp;
            }
}
    }
}
