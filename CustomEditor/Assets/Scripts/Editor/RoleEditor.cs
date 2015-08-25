using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(RoleObject))]
public class RoleEditor : Editor{
	public Object RawAsset{ get;set; }

	public override void OnInspectorGUI(){
		if(!RawAsset){
			GUILayout.Label("请通过相应的编辑器来进行编辑");
			return;
		}

		DrawDefaultInspector();
		GUILayout.Space(50);
		GUILayout.Button("Save");
	}


}

