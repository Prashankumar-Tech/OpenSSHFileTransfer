using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferTest
{
    public class LogWriter
    {
        private static readonly object Locker = new object();
        private string filePath = string.Empty;
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage, string filePath)
        {
            this.filePath = filePath;
            LogWrite(logMessage);
        }
        public LogWriter(string filePath)
        {
            this.filePath = filePath;
        }
        public void LogWrite(string logMessage)
        {
            lock (Locker)
            {
                m_exePath = this.filePath;
                string logFile = m_exePath + "\\Logs\\" + DateTime.UtcNow.ToString("dd-MM-yyyy") + "_FileTransferExtraction_log.txt";
                try
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(logFile);
                    file.Directory.Create();
                    using (StreamWriter w = File.AppendText(logFile))
                    {
                        Log(logMessage, w);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                }
            }
        }

        private void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.UtcNow.ToLongTimeString(),
                    DateTime.UtcNow.ToLongDateString());
                txtWriter.WriteLine("Log Message :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        public void TraceWrite(string traceMessage)
        {
            lock (Locker)
            {
                m_exePath = this.filePath;
                string logFile = m_exePath + "\\Traces\\" + DateTime.UtcNow.ToString("dd-MM-yyyy") + "_FileTransferExtraction_Trace.txt";
                try
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(logFile);
                    file.Directory.Create();
                    using (StreamWriter w = File.AppendText(logFile))
                    {
                        Trace(traceMessage, w);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                }
            }
        }
        private void Trace(string traceMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nTrace Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.UtcNow.ToLongTimeString(),
                    DateTime.UtcNow.ToLongDateString());
                txtWriter.WriteLine("Trace Message  :{0}", traceMessage);
                txtWriter.WriteLine("-------------------------------");
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }
    }
}
