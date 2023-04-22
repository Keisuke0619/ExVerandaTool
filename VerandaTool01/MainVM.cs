using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerandaTool01
{
	internal class MainVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		ItemData data = ItemData.ins;
		public string NameJP { get {  return data.nameJP; }  set { data.nameJP = value; } }
		public string NameEN { get {  return data.nameEN; }  set { data.nameEN = value; } }
		public float Price { get {  return data.price; }  set { data.price = value; } }
		public float Product { get {  return data.product; }  set { data.product = value; } }
		public float Reputation { get {  return data.reputation; }  set { data.reputation = value; } }
		public List<Vector2Int> Size { get {  return data.size; }  set { data.size = value; } }
		
		
	}
}
