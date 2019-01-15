using System;
using System.Diagnostics;
using UACHelper.Properties;

namespace UACHelper
{
    public class ShellStartInfo
    {
        private string _arguments;
        private string _verb = "open";
        private string _workingDirectory;

        public ShellStartInfo(string address, string arguments, string workingDirectory) : this(address, arguments)
        {
            WorkingDirectory = workingDirectory;
        }

        public ShellStartInfo(string address, string arguments) : this(address)
        {
            Arguments = arguments;
        }

        public ShellStartInfo(string address)
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

        public string Verb
        {
            get => _verb;
            set => _verb = value ?? "open";
        }

        public ProcessWindowStyle WindowStyle { get; set; } = ProcessWindowStyle.Normal;

        public string WorkingDirectory
        {
            get => _workingDirectory;
            set => _workingDirectory = value ?? Environment.CurrentDirectory;
        }
    }
}