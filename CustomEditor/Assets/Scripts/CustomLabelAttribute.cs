using UnityEngine;
using System.Collections;

namespace PLY.CustomAttribute{
	public class CustomLabelAttribute : PropertyAttribute{
		public string Label{ get; set;}
		public string Tooltips{ get; set;}

		public CustomLabelAttribute(){}
		
		public CustomLabelAttribute(string label){
			Label = label;
		}

		public CustomLabelAttribute(string label, string tooltips){
			Label = label;
			Tooltips = tooltips;
		}
	}
}

