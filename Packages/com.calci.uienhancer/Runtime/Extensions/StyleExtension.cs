using UnityEngine.UIElements;

public static class StyleExtension
{
	/// <summary>
	/// 단일 값 패딩 적용
	/// </summary>
	/// <param name="style"></param>
	/// <param name="length"></param>
	public static void SetPadding(this IStyle style, StyleLength length)
	{
		style.SetPadding(length, length);
	}

	/// <summary>
	/// 위 & 아래, 왼쪽 & 오른쪽 패딩 적용
	/// </summary>
	/// <param name="style"></param>
	/// <param name="topBottom"></param>
	/// <param name="leftRight"></param>
	public static void SetPadding(this IStyle style,
		StyleLength topBottom, StyleLength leftRight)
	{
		style.SetPadding(topBottom, leftRight, topBottom);
	}
	
	/// <summary>
	/// 위, 왼쪽 & 오른쪽, 아래 패딩 적용
	/// </summary>
	/// <param name="style"></param>
	/// <param name="top"></param>
	/// <param name="leftRight"></param>
	/// <param name="bottom"></param>
	public static void SetPadding(this IStyle style,
		StyleLength top, StyleLength leftRight, StyleLength bottom)
	{
		style.SetPadding(top, leftRight, bottom, leftRight);
	}

	/// <summary>
	/// 각각 다른 값 지정
	/// </summary>
	/// <param name="style"></param>
	/// <param name="top"></param>
	/// <param name="right"></param>
	/// <param name="bottom"></param>
	/// <param name="left"></param>
	public static void SetPadding(this IStyle style,
		StyleLength top, StyleLength right,
		StyleLength bottom, StyleLength left)
	{
		style.paddingTop = top;
		style.paddingRight = right;
		style.paddingBottom = bottom;
		style.paddingLeft = left;
	}

	public static void SetMargin(this IStyle style, StyleLength length)
	{
		style.SetMargin(length, length);
	}

	public static void SetMargin(this IStyle style,
		StyleLength topBottom, StyleLength leftRight)
	{
		style.SetMargin(topBottom, leftRight, topBottom);
	}
	
	public static void SetMargin(this IStyle style,
		StyleLength top, StyleLength leftRight, StyleLength bottom)
	{
		style.SetMargin(top, leftRight, bottom, leftRight);
	}

	public static void SetMargin(this IStyle style,
		StyleLength top, StyleLength right,
		StyleLength bottom, StyleLength left)
	{
		style.marginTop = top;
		style.marginRight = right;
		style.marginBottom = bottom;
		style.marginLeft = left;
	}
}