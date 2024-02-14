using System;

namespace SessionEndingHandler
{
	public class RegistrySubkeyNotFoundException : Exception
	{
		public string KeyName { get; }

		private const string DefaultMessage = "The specified Registry sub-key could not be found.";

		public RegistrySubkeyNotFoundException() : base(DefaultMessage) { }
		public RegistrySubkeyNotFoundException(string keyName) : base(DefaultMessage) => KeyName = keyName;
		public RegistrySubkeyNotFoundException(string message, string keyName) : base(message) => KeyName = keyName;
	}
}
