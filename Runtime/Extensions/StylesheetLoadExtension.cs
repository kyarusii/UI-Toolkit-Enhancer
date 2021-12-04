using UnityEngine;
using UnityEngine.UIElements;

public static class StylesheetLoadExtension
{
	/// <summary>
	/// 미리 제공되는 에디터 스타일시트를 로드합니다
	/// </summary>
	/// <param name="target"></param>
	/// <param name="path"></param>
	/// <returns></returns>
	public static bool LoadStylesheet(this VisualElement target, string path)
	{
		var asset = Resources.Load<StyleSheet>(path);
		
		if (asset == null)
		{
			Debug.LogWarning($"런타임 로드 실패 : {path}");
			return false;
		}
		
		target.styleSheets.Add(asset);

		return true;
	}
}