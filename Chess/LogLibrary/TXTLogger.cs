using System;
using System.IO;

namespace LogLibrary
{
    /// <summary>
    /// Logger for recording moves in text file
    /// </summary>
    public class TXTLogger : ILogger
    {
        static private string _path;
        static private string _directory;
        /// <summary>
        /// Directory of text file
        /// </summary>
        static public DirectoryInfo di;
        /// <summary>
        /// Constructor of Logger
        /// </summary>
        /// <param name="fileName"></param>
        public TXTLogger(string fileName)
        {

            _directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            _path = Path.Combine(_directory, $"{fileName}.txt");
            di = new DirectoryInfo(_directory);
            di.Create();
            File.AppendAllText(_path, "---------START---------\n");
        }
        /// <summary>
        /// Method for writing text in file
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            File.AppendAllText(_path, message + "\n");
        }
    }
}
