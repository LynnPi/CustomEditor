using UnityEditor;
using UnityEngine;
using PLY.CustomAttribute;

namespace PLY.PropertyDrawers{
	[CustomPropertyDrawer( typeof( CustomLabelAttribute ) )]
	public class CustomLabelDrawer : PropertyDrawer{
		private CustomLabelAttribute CustomAttribute{
			get { return attribute as CustomLabelAttribute; }
		}
		
		public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
			SerializedPropertyType propertyType = property.propertyType;
			switch( propertyType ){
			case SerializedPropertyType.Vector2:
			case SerializedPropertyType.Vector3:
				return 32;
			default:
				return base.GetPropertyHeight( property, label );
			}
		}
		
		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ){
			if( property.depth <= 0 ){
				position.xMin += 4;
			}
			label.text = CustomAttribute.Label;
			label.tooltip = CustomAttribute.Tooltips;
			position.height = base.GetPropertyHeight( property, label );
			EditorGUI.BeginProperty( position, label, property );
			SerializedPropertyType propertyType = property.propertyType;
			switch( propertyType ){
			case SerializedPropertyType.Integer:
				EditorGUI.BeginChangeCheck();
				int num1 = EditorGUI.IntField( position, label, property.intValue );
				if( EditorGUI.EndChangeCheck() ){
					property.intValue = num1;
					break;
				}
				else
					break;
			case SerializedPropertyType.Boolean:
				EditorGUI.BeginChangeCheck();
				bool flag2 = EditorGUI.Toggle( position, label, property.boolValue );
				if( EditorGUI.EndChangeCheck() ){
					property.boolValue = flag2;
					break;
				}
				else
					break;
			case SerializedPropertyType.Float:
				EditorGUI.BeginChangeCheck();
				float num2 = EditorGUI.FloatField( position, label, property.floatValue );
				if( EditorGUI.EndChangeCheck() ){
					property.floatValue = num2;
					break;
				}
				else
					break;
			case SerializedPropertyType.String:
				EditorGUI.BeginChangeCheck();
				string str1 = EditorGUI.TextField( position, label, property.stringValue );
				if( EditorGUI.EndChangeCheck() ){
					property.stringValue = str1;
					break;
				}
				else
					break;
			case SerializedPropertyType.Color:
				EditorGUI.BeginChangeCheck();
				Color color = EditorGUI.ColorField( position, label, property.colorValue );
				if( EditorGUI.EndChangeCheck() ){
					property.colorValue = color;
					break;
				}
				else
					break;
			case SerializedPropertyType.Enum:
				//EditorGui.Popup( position, property, label );
				break;
			case SerializedPropertyType.Vector2:
				EditorGUI.BeginChangeCheck();
				Vector2 v2 = EditorGUI.Vector2Field( position, label.text, property.vector2Value );
				if( EditorGUI.EndChangeCheck() ){
					property.vector2Value = v2;
				}
				break;
			case SerializedPropertyType.Vector3:
				EditorGUI.BeginChangeCheck();
				Vector3 v3 = EditorGUI.Vector3Field( position, label.text, property.vector3Value );
				if( EditorGUI.EndChangeCheck() ){
					property.vector3Value = v3;
				}
				break;
			case SerializedPropertyType.Rect:
				EditorGUI.BeginChangeCheck();
				Rect rect = EditorGUI.RectField( position, label, property.rectValue );
				if( EditorGUI.EndChangeCheck() ){
					property.rectValue = rect;
				}
				break;
			case SerializedPropertyType.Character:
				var chArray1 = new char[1];
				int index = 0;
				int num4 = (ushort)property.intValue;
				chArray1[ index ] = (char)num4;
				char[] chArray2 = chArray1;
				bool changed = GUI.changed;
				GUI.changed = false;
				string str2 = EditorGUI.TextField( position, label, new string( chArray2 ) );
				if( GUI.changed ){
					if( str2.Length == 1 )
						property.intValue = str2[ 0 ];
					else
						GUI.changed = false;
				}
				GUI.changed = GUI.changed | changed;
				break;
			case SerializedPropertyType.Bounds:
				EditorGUI.BeginChangeCheck();
				Bounds b = EditorGUI.BoundsField( position, label, property.boundsValue );
				if( EditorGUI.EndChangeCheck() ){
					property.boundsValue = b;
				}
				break;
			case SerializedPropertyType.AnimationCurve:
				EditorGUI.BeginChangeCheck();
				AnimationCurve ac = EditorGUI.CurveField(position, label, property.animationCurveValue);
				if( EditorGUI.EndChangeCheck() ){
					property.animationCurveValue = ac;
				}
				break;
			default:
				base.OnGUI(position, property, label);
				Debug.Log( "Unsupported:" + property.name + ", " + propertyType );
				//EditorGUI.LabelField( position, "Unsupported", propertyType.ToString() );
				break;
			}
			EditorGUI.EndProperty();
		}
	}
}