using System.Windows;

namespace SessionEndingHandler
{
	public partial class App : Application
	{
		// Only display the confirmation messagebox if we're running under a Windows version older than 10,
		// Otherwise, cancel the shutdown immediately
		private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
			=> e.Cancel = Constants.IsAtLeastWindows10 || MessageBoxManager.DisplayConfirmation($"The system is about to {(e.ReasonSessionEnding == ReasonSessionEnding.Shutdown ? "shut down" : "log off")}.\nWould you like to abort the shutdown process?");
	}
}
