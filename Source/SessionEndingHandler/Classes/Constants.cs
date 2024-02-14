using System;

namespace SessionEndingHandler
{
    public static class Constants
    {
        public const string ProgramName = "Session Ending Handler";

		public static readonly bool IsAtLeastWindows10 = Environment.OSVersion.Version.Major >= 10;
	}
}
