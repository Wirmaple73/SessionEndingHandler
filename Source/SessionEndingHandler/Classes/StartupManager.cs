using System;
using Microsoft.Win32;

namespace SessionEndingHandler
{
	public static class StartupManager
	{
		private const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

		// Source:
		// https://stackoverflow.com/a/675347/18954775
		public static void SetStartWithWindowsEnabled(bool enabled)
		{
			using (var key = Registry.CurrentUser.OpenSubKey(SubKey, true))
			{
				if (key is null)  // This normally shouldn't happen
					throw new RegistrySubkeyNotFoundException(SubKey);

				if (enabled)
					key.SetValue(Constants.ProgramName, Environment.ProcessPath);
				else
					key.DeleteValue(Constants.ProgramName, false);
			}
		}
	}
}
