using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class EditorStylesheetLoadExtension
{
	/// <summary>
	/// 미리 제공되는 에디터 스타일시트를 로드합니다
	/// </summary>
	/// <param name="target"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	public static bool LoadEditorStylesheet(this VisualElement target, string path)
	{
		const string rootPath = "Packages/com.calci.uienhancer/Stylesheets/Editor/";
		string resolvedPath = rootPath + path + ".uss"; 
		
		var asset = AssetDatabase.LoadAssetAtPath<StyleSheet>(resolvedPath);
		
		if (asset == null)
		{
			Debug.LogWarning($"에디터 로드 실패 : {resolvedPath}");
			return false;
		}
		
		target.styleSheets.Add(asset);

		return true;
	}
}