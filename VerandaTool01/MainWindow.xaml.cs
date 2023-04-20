using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VerandaTool01
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{

		public List<ItemData> items;
		public int target = 0;
		List<CountUpButton> buttons;
		public MainWindow()
		{
			InitializeComponent();
			buttons = new List<CountUpButton>();
			if (File.Exists(FILE_PATH))
			{
				LoadFile();
			}
			else
			{
				items = new List<ItemData>();
				for (var i = 0; i < 3; i++)
				{
					var item = new ItemData();
					item.nameJP = i.ToString();
					item.nameEN = i.ToString();
					item.price = i * 1;
					item.reputation = i * 10;
					item.product = i * 100;

					items.Add(item);
				}

			}
			SetShowText();
			ReloadText();
		}

		void SetShowText()
		{
			ItemData.ins.nameJP = items[target].nameJP;
			ItemData.ins.nameEN = items[target].nameEN;
			ItemData.ins.price = items[target].price;
			ItemData.ins.product = items[target].product;
			ItemData.ins.reputation = items[target].reputation;
			ItemData.ins.size = items[target].size;
		}
		private void AddTest_Click(object sender, RoutedEventArgs e)
		{
			var btn = sender as CountUpButton;
			if (btn == null)
				return;
			target = btn.insID;
			
			SetShowText();
			ReloadText();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			AddItemButton();
			target = buttons.Count - 1;
			SetShowText();
			ReloadText();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SaveFile();
			Close();
		}
		
		public static readonly string FILE_PATH = "items.dat";


		void AddItemButton()
		{
			var addTest = new CountUpButton();
			buttons.Add(addTest);
			addTest.Content = "New Item";
			addTest.Click += AddTest_Click;
			this.ListPanel.Children.Add(addTest);

			var item = new ItemData();
			item.nameJP = "nanashi";
			item.nameEN = "nanashi";
			item.price = 0;
			item.reputation = 0;
			item.product = 0;
			item.size = 0;
			items.Add(item);
			
		}
		private void LoadFile()
		{
			items = new List<ItemData>();
			using (var fs = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read))
			{
				using (var rb = new BinaryReader(fs))
				{
					var itemsCount = rb.ReadInt32();
					for(var i =0; i < itemsCount; i++)
					{
						var item = new ItemData();
						item.nameJP = rb.ReadString();
						item.nameEN = rb.ReadString();
						item.price = rb.ReadSingle();
						item.reputation = rb.ReadSingle();
						item.product = rb.ReadSingle();
						item.size = rb.ReadInt32();
						items.Add(item);
						var addTest = new CountUpButton();
						buttons.Add(addTest);
						addTest.Content = item.nameJP;
						addTest.Click += AddTest_Click;
						ListPanel.Children.Add(addTest);

					}
				}
			}

		}
		private void SaveFile()
		{
			using (var fs = new FileStream(FILE_PATH, FileMode.Create, FileAccess.Write))
			{
				using(var wb = new BinaryWriter(fs))
				{
					var id = 0;
					wb.Write(items.Count);
					foreach (var item in this.items)
					{
						wb.Write(item.nameJP);
						wb.Write(item.nameEN);
						wb.Write(item.price);
						wb.Write(item.reputation);
						wb.Write(item.product);
						wb.Write(item.size);
						id++;

					}
				}
			}
		}

		private void textbox_LostFocus(object sender, RoutedEventArgs e)
		{
			items[target].nameJP = ItemData.ins.nameJP;
			items[target].nameEN = ItemData.ins.nameEN;
			items[target].price = ItemData.ins.price;
			items[target].product = ItemData.ins.product;
			items[target].reputation = ItemData.ins.reputation;
			items[target].size = ItemData.ins.size;
			ReloadText();
		}
		private void ReloadText()
		{
			var ins = ItemData.ins;
			TextNameJP.Text = ins.nameJP;
			TextNameEN.Text = ins.nameEN;
			TextPrice.Text = ins.price.ToString();
			TextReputation.Text = ins.reputation.ToString();
			TextProduct.Text = ins.product.ToString();
			//TextSize.Text = ins.size.ToString();
			int i = 0;
			foreach(var btn in buttons)
			{
				btn.Content = items[i].nameJP;
				btn.SetColor(target);
				i++;
			}
			LabelID.Content = "ID:" + target.ToString("D2");
		}

		private void textBox_GotFocus(object sender, RoutedEventArgs e)
		{
			var text = sender as TextBox;
			if (text == null)
				return;
			text.SelectAll();
		}

		private void textBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var text = sender as TextBox;
			if (text == null) return;
			if(text.IsFocused) return;
			e.Handled = true;
			text.Focus();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show(this,"選択中のアイテムを消去しますか？\nこの操作は取り消せません。", "確認：アイテム削除", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if(result == MessageBoxResult.Yes)
			{
				// ターゲットのアイテムデータを消去
				items.RemoveAt(target);
				// ターゲットのボタンを消去
				ListPanel.Children.Remove(buttons[buttons.Count - 1]);
				buttons.RemoveAt(buttons.Count - 1);
				CountUpButton.Delete();
				// ターゲットを０にする
				target = 0;

				SetShowText();
				ReloadText();
			}
		}

		private void Button_Click_Size(object sender, RoutedEventArgs e)
		{
			var button = sender as SizeSelectButton;
			if(button == null) return;
			button.SetColor();
		}
	}
}
