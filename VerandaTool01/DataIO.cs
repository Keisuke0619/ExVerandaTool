using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VerandaTool01
{
	public class Vector2Int
	{
		int x;
		int y;
	}
	public class ItemData
	{
		public static ItemData ins = new ItemData();
		public string nameJP = "ななし";		// 日本語名
		public string nameEN = "No name";		// 英語名
		public float price = 0.0f;			// 価格
		public float product = 0.0f;		// 生産性
		public float reputation = 0.0f;    // 評判上昇値
		public Vector2Int[] size;
	}
	internal class DataIO
	{
		
	}
}
