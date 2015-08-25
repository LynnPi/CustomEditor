using UnityEngine;
using System.Collections;
using UnityEditor;

public class RoleEditorWindow : EditorWindow{
	private bool _previewGUIComponent = false;
	private Object _rawAsset;
	private RoleEditor _roleEditor;
	private static Texture WindowTitleTexture{
		get{
			return Resources.Load("title_tex") as Texture;
		}
	}

	[MenuItem("Custom Editor/Role Eidtor Window")]
	public static void ShowCustomEditorWindow(){
		var window = EditorWindow.CreateInstance<RoleEditorWindow>();

		string titleText = "Role";

		window.titleContent = WindowTitleTexture ? 
				new GUIContent(titleText, WindowTitleTexture) :
				new GUIContent(titleText);

		window.Show();
	}

	void OnGUI(){
		if(_previewGUIComponent){
			PreviewGUIComponent();
			return;
		}

		if(!Application.isPlaying){
			EditorGUILayout.HelpBox("需要运行状态下才能编辑！", MessageType.Info);
			ResetEditor();
			return;
		}

		EditorGUI.BeginChangeCheck();
		Object obj = EditorGUILayout.ObjectField("拖动编辑对象至此",_rawAsset, typeof(Object), false);
		if(EditorGUI.EndChangeCheck()){
			ResetEditor();
			if(obj){
				_roleEditor = Editor.CreateEditor(obj, typeof(RoleEditor)) as RoleEditor;
				if(_roleEditor){
					_roleEditor.RawAsset = _rawAsset = obj;
				}
			}
			return;
		}

		if(_roleEditor){
			_roleEditor.OnInspectorGUI();
		}


	}
	private void ResetEditor(){
		_roleEditor = null;
		_rawAsset = null;
	}

	private void PreviewGUIComponent(){
		EditorGUILayout.HelpBox ("This is a HelpBox", MessageType.Info);
		EditorGUILayout.LabelField("This is a LabelField");
		EditorGUILayout.PrefixLabel("This is a PrefixLabel");
		EditorGUILayout.Toggle("This is a Toggle", true);
		GUILayout.Button("This is a Button");
	}
}

