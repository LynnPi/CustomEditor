using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class EditorMenu : EditorWindow{

	[MenuItem("Assets/Create/__Custom/RoleDefine")]
	public static void CreateRoleInstance(){
		ScriptableObject instance = ScriptableObject.CreateInstance<RoleObject>();

		string savePath = Path.Combine(Application.dataPath, "RoleDefines") ;
		Debug.Log("savePath: " + savePath);
		if(!Directory.Exists(savePath)){
			Directory.CreateDirectory(savePath);
		}
		string fullPath = Path.Combine(savePath, "untitled_role_define.asset");
		string relativePath = fullPath.Substring(fullPath.IndexOf("Assets/"));
		Debug.Log("relativePath: " + relativePath);
		string finalPath = AssetDatabase.GenerateUniqueAssetPath(relativePath);

		AssetDatabase.CreateAsset(instance, finalPath);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}
}

