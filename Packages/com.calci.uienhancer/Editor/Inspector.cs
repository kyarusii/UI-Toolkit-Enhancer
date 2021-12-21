using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Inspector : UnityEditor.Editor
{
	protected VisualElement root;

	protected virtual bool DrawHeaderAttribute { get; } = false;
	protected virtual bool Grouping { get; } = true;

	protected readonly Dictionary<GroupAttribute, List<PropertyField>> groupedOrderedProperties
		= new Dictionary<GroupAttribute, List<PropertyField>>();

	protected virtual void OnCreateGUI()
	{
		
	}

	public override VisualElement CreateInspectorGUI()
	{
		root = new VisualElement();

		var targetType = target.GetType();

		serializedObject.UpdateIfRequiredOrScript();
		var iterator = serializedObject.GetIterator();

		for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
		{
			if (DrawHeaderAttribute)
			{
				var fieldInfo = targetType.GetField(iterator.propertyPath);
				if (fieldInfo != null &&
				    fieldInfo.GetCustomAttribute(typeof(UnityEngine.HeaderAttribute), false) is HeaderAttribute
					    attribute)
				{
					var header = new Label(attribute.header);
					header.AddToClassList("header");
					root.Add(header);
				}
			}

			var propertyField = new PropertyField(iterator);
			if (iterator.propertyPath == "m_Script")
			{
				propertyField.SetEnabled(false);
				root.Add(propertyField);}
			else
			{
				if (Grouping)
				{
					// Grouping 된 것
					var fieldInfo = targetType.GetField(iterator.propertyPath);
					if (fieldInfo != null &&
					    fieldInfo.GetCustomAttribute(typeof(GroupAttribute), false) is GroupAttribute
						    attribute)
					{
						if (!groupedOrderedProperties.TryGetValue(attribute, out var list))
						{
							list = new List<PropertyField>();
						}

						list.Add(propertyField);
						groupedOrderedProperties[attribute] = list;
					}
					else
					{
						// 보통 필드
						root.Add(propertyField);
					}
				}
			}
		}

		if (Grouping)
		{
			var keys = groupedOrderedProperties.Keys.OrderBy(e => e.order);
			foreach (GroupAttribute ga in keys)
			{
				var fold = new Foldout();
				root.Add(fold);

				fold.text = ga.@group;
				
				var list = groupedOrderedProperties[ga];
				foreach (PropertyField propertyField in list)
				{
					fold.Add(propertyField);
				}
			}
		}

		serializedObject.ApplyModifiedProperties();

		OnCreateGUI();
		return root;
	}
}