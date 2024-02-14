using System.Windows;

namespace SessionEndingHandler
{
	public static class MessageBoxManager
	{
		public static void DisplayError(string message)
			=> InternalDisplayMessageBox(message, "Error", image: MessageBoxImage.Error);

		public static bool DisplayConfirmation(string message, MessageBoxResult defaultResult = MessageBoxResult.Yes)
			=> InternalDisplayMessageBox(message, Constants.ProgramName, MessageBoxButton.YesNo, defaultResult: defaultResult) == MessageBoxResult.Yes;

		private static MessageBoxResult InternalDisplayMessageBox(string message, string caption, MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage image = MessageBoxImage.Asterisk, MessageBoxResult defaultResult = MessageBoxResult.OK)
			=> MessageBox.Show(message, caption, button, image, defaultResult);
	}
}
