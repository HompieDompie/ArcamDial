using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;


namespace ArcamDialNameSpace
{
    class Discover
    {
        public string getMacByIp(string ip)
        {
            var macIpPairs = GetAllMacAddressesAndIppairs();
            int index = macIpPairs.FindIndex(x => x.IpAddress == ip);
            if (index >= 0)
            {
                return macIpPairs[index].MacAddress.ToUpper();
            }
            else
            {
                return null;
            }
        }

        public List<Device> GetAllMacAddressesAndIppairs()
        {
            List<Device> mip = new List<Device>();
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a ";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string cmdOutput = pProcess.StandardOutput.ReadToEnd();
            string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

            foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
            {
                string mac = m.Groups["mac"].Value;
                string ip = m.Groups["ip"].Value;

                if (mac.Contains("1b-7c-"))     // 1b-7c is mac manufacturer code for A & R Cambridge
                {
                    mip.Add(new Device()
                    {
                        MacAddress = mac,
                        IpAddress = ip
                        
                    });
                }
            }

            return mip;
        }
        public struct Device
        {
            public string MacAddress;
            public string IpAddress;
            //public string HostName;
        }

      }
}
