using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Car.Wheel))]
public class WheelDrawer : PropertyDrawer
{
	const float groundedCheck = 15;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		Rect groundedRect = new Rect(position.width, position.y, groundedCheck, position.height);

		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Calculate rects
		Rect wheelRect = new Rect(position.x, position.y, position.width - groundedCheck, position.height);
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(wheelRect, property.FindPropertyRelative("wheel"), GUIContent.none);

		EditorGUI.EndProperty();
	}
}
