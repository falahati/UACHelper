using System;
using UACHelper.Properties;

namespace UACHelper
{
    public class TaskStartInfo
    {
        private string _arguments;
        private string _workingDirectory;

        public TaskStartInfo(string address, string arguments, string workingDirectory) : this(address, arguments)
        {
            WorkingDirectory = workingDirectory;
        }

        public TaskStartInfo(string address, string arguments) : this(address)
        {
            Arguments = arguments;
        }

        public TaskStartInfo(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException(Resources.StartInfo_Address_Error, nameof(address));
            }
            Address = address;
        }

        public string Address { get; }

        public string Arguments
        {
            get => _arguments;
            set => _arguments = value ?? string.Empty;
        }

        public string WorkingDirectory
        {
            get => _workingDirectory;
            set => _workingDirectory = value ?? Environment.CurrentDirectory;
        }
    }
}