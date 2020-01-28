using System;
using System.Configuration;
using System.IO;

namespace FileTransferTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Started");
            string outputFileName = ConfigurationManager.AppSettings["OutputFile"];
            string FileTransferLogPath = ConfigurationManager.AppSettings["FileTransferLogPath"];
            LogWriter logWriter = new LogWriter(FileTransferLogPath);
            Console.WriteLine("Sending file Started");
            bool success = FileExporter.UploadFile(outputFileName);
            
            if (success)
            {
                try
                {
                    Console.WriteLine("file transferred successfully!!!");
                    logWriter.TraceWrite("File uploaded to SFTP: " + Path.GetFileName(outputFileName));
                    
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                Console.WriteLine("file transferred failed!!!");
                logWriter.LogWrite("SFTP file upload failed: " + Path.GetFileName(outputFileName));
                

            }
        }
    }
}
