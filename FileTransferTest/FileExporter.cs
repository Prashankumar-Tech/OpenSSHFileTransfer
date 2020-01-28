using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferTest
{
    public static class FileExporter
    {

        private static int port = 22;

        public static bool UploadFile(string fileName)
        {
            try
            {
                string username = ConfigurationManager.AppSettings["SFTPUserName"];
                string host = ConfigurationManager.AppSettings["SFTPHostName"];
                int portNumber = ConfigurationManager.AppSettings["SFTPPortNo"] == null ? port : Convert.ToInt32(ConfigurationManager.AppSettings["SFTPPortNo"]);
                string PrivateKeyFile = ConfigurationManager.AppSettings["PrivateKeyFileForExportFileToSFTP"];
                var keyFile = new PrivateKeyFile(PrivateKeyFile);
                var keyFiles = new[] { keyFile };
                string uploadPath = ConfigurationManager.AppSettings["SFTPUploadDirectory"];
                var methods = new List<AuthenticationMethod>();
                methods.Add(new PrivateKeyAuthenticationMethod(username, keyFile));

                var con = new ConnectionInfo(host, portNumber, username, methods.ToArray());
                using (SftpClient client = new SftpClient(con))
                {
                    client.Connect();
                    FileInfo uploadFile = new FileInfo(fileName);
                    string uploadfile = uploadFile.FullName;
                    using (var fileStream = new FileStream(uploadfile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fileStream, uploadPath + uploadFile.Name, null);
                        client.Disconnect();
                        client.Dispose();
                        fileStream.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                string FileTransferLogPath = ConfigurationManager.AppSettings["FileTransferLogPath"];
                LogWriter logWriter = new LogWriter(FileTransferLogPath);
                logWriter.LogWrite("Exception inside SFTP file upload method:" + ex.Message);
                return false;
            }
            return true;
        }
    }
}
