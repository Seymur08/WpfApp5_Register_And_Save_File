using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5;


public partial class MainWindow : Window
{
	List<User> users = new List<User>();

	List<string> Cities = new List<string>()
			{
		"Astara","Ağcabədi","Ağdam","Ağdaş","Ağdərə","Ağstafa",
		"Ağsu","Babək","Balakən","Beyləqan","Biləsuvar","Bərdə",
		"Culfa","Cəbrayıl","Cəlilabad","Daşkəsən","Xankəndi",
		"Xaçmaz","Xırdalan","Xızı","Xocalı","Xocavənd","Xudat",
			};

	public MainWindow()
	{
		InitializeComponent();
		City_Box.ItemsSource = Cities;
		List_User.ItemsSource = users;
		
	}

	private void Submit(object sender, RoutedEventArgs e)
	{
		string? gender = null;

		if(textBoxName.Text.Length > 0)
		{
			if(textBoxSurnname.Text.Length > 0)
			{
				foreach( RadioButton item in radiobutton_Check.Children )
				{
					if( item.IsChecked == true )
					{
						gender = item.Content.ToString();
						break;
					}
				}
				User user = new User(textBoxName.Text, textBoxSurnname.Text, gender!, Academy_check.IsChecked!.Value, City_Box.Text);
				users.Add(user);
				List_User.Items.Refresh();
			}
		}
	}

	private void Remove_Button(object sender, RoutedEventArgs e)
	{
		if(List_User.SelectedItem != null)
		{
			users.Remove((User)List_User.SelectedItem);
			List_User.Items.Refresh();
		}
		
	}

	private void Save_Button(object sender, RoutedEventArgs e)
	{
		OpenFileDialog file = new OpenFileDialog();

		file.Filter = "Only txt|*.txt|Only json|*.txt";

		if(file.ShowDialog() == true)
		{
			MessageBoxResult result = MessageBox.Show("Secdiyiniz file'da kohne\nmelumatlar silinecek\nEminsiniz?",
				"Diqqet", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

			if(result == MessageBoxResult.Yes)
			{
				if( File.Exists(file.FileName) )
				{
					var write = new JsonSerializerOptions { WriteIndented = true };
					string json = JsonSerializer.Serialize(users, write);

					File.WriteAllText(file.FileName, json);
				}
			}




		}

	}

}