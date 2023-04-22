using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace VerandaTool01
{
	internal class SizeSelectButton : Button
	{
		public static List<SizeSelectButton> list = new List<SizeSelectButton>();
		public bool isSelected;
		public int num;
		public SizeSelectButton()
		{
			Background = new SolidColorBrush(Colors.LightGray);
			num = list.Count();
			Content = num.ToString();
			if(num == 12)
			{
				isSelected = true;
				Background = new SolidColorBrush(Colors.SkyBlue);
				Content = "中心";
			}
			list.Add(this);
		}
		public void SetColor()
		{
			if(num == 12)
			{
				isSelected = true;
				return;
			}
			if (isSelected)
			{
				Background = new SolidColorBrush(Colors.LightGray);
			}
			else
			{
				Background = new SolidColorBrush(Colors.SkyBlue);
			}
			isSelected = !isSelected;
		}
		public void SetButtonActive(bool isActive)
		{
			if(num == 12)
			{
				isSelected = true;
				Background = new SolidColorBrush(Colors.SkyBlue);
				return;
			}
			if (isActive)
			{
				Background = new SolidColorBrush(Colors.SkyBlue);
			}
			else
			{
				Background = new SolidColorBrush(Colors.LightGray);
			}
			isSelected = isActive;
		}
		public bool GetIsActive()
		{
			return isSelected;
		}
		public Vector2Int GetPos()
		{
			return new Vector2Int((num % 5) - 2, (num / 5) - 2);
			
		}
	}
}
