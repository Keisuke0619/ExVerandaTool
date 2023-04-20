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
		public bool isSelected;
		
		public SizeSelectButton()
		{
			Background = new SolidColorBrush(Colors.LightGray);
		}
		public void SetColor()
		{
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
	}
}
