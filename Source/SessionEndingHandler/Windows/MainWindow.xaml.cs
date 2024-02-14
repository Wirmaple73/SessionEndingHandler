using System;
using System.Windows;
using SessionEndingHandler.Properties;

namespace SessionEndingHandler
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ImportSettings();
		}

		// The code for handling the shutdown is located at 'App.xaml.cs'

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
			=> e.Cancel = !MessageBoxManager.DisplayConfirmation("Are you sure you want to exit the program? the program must be kept running in order to intercept the shutdown process!", MessageBoxResult.No);

		private void CheckBoxStartWithWindows_Click(object sender, RoutedEventArgs e)
			=> SetStartWithWindowsEnabled(CheckBoxStartWithWindows.IsChecked.Value);

		private void CheckBoxStartMinimized_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.StartMinimized = CheckBoxStartMinimized.IsChecked.Value;
			Settings.Default.Save();
		}

		private void ImportSettings()
		{
			Settings.Default.Reload();

			// Update the UI
			CheckBoxStartWithWindows.IsChecked = Settings.Default.StartWithWindows;
			CheckBoxStartMinimized.IsChecked = Settings.Default.StartMinimized;

			// Apply the settings
			this.WindowState = Settings.Default.StartMinimized ? WindowState.Minimized : WindowState.Normal;
			SetStartWithWindowsEnabled(Settings.Default.StartWithWindows);
		}

		private static void SetStartWithWindowsEnabled(bool enabled)
		{
			try
			{
				StartupManager.SetStartWithWindowsEnabled(enabled);

				Settings.Default.StartWithWindows = enabled;
				Settings.Default.Save();
			}
			catch (RegistrySubkeyNotFoundException ex)
			{
				MessageBoxManager.DisplayError($"An error has occurred:\n{ex.Message}\n({ex.KeyName})");
			}
			catch (Exception ex)
			{
				MessageBoxManager.DisplayError($"An error has occurred:\n{ex.Message}\n\nPlease ensure that the program has write access to the Registry.");
			}
		}
	}
}
