using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace VerandaTool01
{
	internal class CountUpButton : Button
	{
		public static int instanceCount = 0;
		public int insID { get; private set; }
		public CountUpButton()
		{
			insID = instanceCount;
			instanceCount++;
		}
		public void SetColor(int id)
		{
			if(insID == id) 
			{
				this.Background = new SolidColorBrush(Colors.Pink);
			}
			else
			{
				this.Background = new SolidColorBrush(Colors.LightGray);
			}
		}
		public static void Delete()
		{
			instanceCount--;
		}
	}

}
