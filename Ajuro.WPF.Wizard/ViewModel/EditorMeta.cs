﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Ajuro.WPF.Wizard.ViewModel
{
	public class EditorMeta
	{
		public EditorMeta()
		{
			Id = MainWindow.IdSequence++;
		}

		private int id { get; set; }
		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				NotifyPropertyChanged();
			}
		}
		private List<object> parent { get; set; }
		public List<object> Parent
		{
			get { return parent; }
			set
			{
				parent = value;
				NotifyPropertyChanged();
			}
		}
		private bool isObject { get; set; }
		public bool IsObject
		{
			get { return isObject; }
			set
			{
				isObject = value;
				NotifyPropertyChanged();
			}
		}
		private bool showLabel { get; set; }
		public bool ShowLabel
		{
			get { return showLabel; }
			set
			{
				showLabel = value;
				NotifyPropertyChanged();
			}
		}
		private string currentValue { get; set; }
		public string CurrentValue
		{
			get { return currentValue; }
			set
			{
				currentValue = value;
				string data = File.ReadAllText(MainModel.DataJsonPath);
				var o = JObject.Parse(data);
				JToken acme = o.SelectToken("$.Collections[" + Index + "].Placeholder");
				if (acme != null)
				{
					acme.Replace(value);
				}
				var str = JsonConvert.SerializeObject(o);
				File.WriteAllText("Resources\\sample.json", str);
				NotifyPropertyChanged();
			}
		}

		private string currentLabel { get; set; }
		public string CurrentLabel
		{
			get { return currentLabel; }
			set
			{
				currentLabel = value;
				NotifyPropertyChanged();
			}
		}

		public int Index { get; internal set; }

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}