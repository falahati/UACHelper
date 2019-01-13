using System;
using UACHelper.Properties;

namespace UACHelper
{
    public class ExecutableTask
    {
        public ExecutableTask(string address, string arguments, string workingDirectory)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException(Resources.ExecutableTask_Address_Error, nameof(address));
            }

            Address = address;
            Arguments = arguments;
            WorkingDirectory = workingDirectory;

            if (string.IsNullOrWhiteSpace(WorkingDirectory))
            {
                WorkingDirectory = Environment.CurrentDirectory;
            }
        }

        public ExecutableTask(string address, string arguments) : this(address, arguments, string.Empty)
        {
        }

        public ExecutableTask(string address) : this(address, string.Empty)
        {
        }

        public string Address { get; }
        public string Arguments { get; }
        public string WorkingDirectory { get; }
    }
}