using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ShareFileSMB.SBM;

namespace ShareFileSMB
{
    class ConnectSMB
    {
        public class SmbFileContainer
        {
            private readonly NetworkCredential networkCredential;
            // Path to shared folder:
            public readonly string networkPath;

            public SmbFileContainer()
            {
                this.networkPath = @"\\166.166.4.189\Newfolder";
                var userName = "tang1811";
                var password = "123456789";
                var domain = "";
                networkCredential = new NetworkCredential(userName, password, domain);
                //NetworkCredential a = new NetworkCredential();
            }

            public bool IsValidConnection()
            {
                using (var network = new NetworkConnection($"{networkPath}", networkCredential))
                {
                    var result = network.Connect();

                    return result != 0;
                }
            }

            public void CreateFile(string targetFile, string content)
            {
                using (var network = new NetworkConnection(networkPath, networkCredential))
                {
                    network.Connect();
                    var file = Path.Combine(this.networkPath, targetFile);
                    if (!File.Exists(file))
                    {
                        using (File.Create(file)) { };
                        using (StreamWriter sw = File.CreateText(file))
                        {
                            sw.WriteLine(content);
                        }
                    }
                }
            }
            public void SendFile(String LocationFile, String TargetFile)
            {
                try
                {
                    using (NetworkConnection network = new NetworkConnection(networkPath, networkCredential))
                    {
                        network.Connect();
                        var path = Path.Combine(networkPath, TargetFile);
                        if (!File.Exists(path))
                        {
                            File.Copy(LocationFile, path, true);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}