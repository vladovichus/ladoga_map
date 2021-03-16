using UnityEngine;
using UnityEditor;

public class PaletteWindow : EditorWindow
{
	private string _stringForConvert = "0, 0, 0";
	private string _bytedString = "";
	
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	// Add menu named "My Window" to the Window menu
	[MenuItem("Tools/Palette")]
	private static void Init()
	{
		PaletteWindow window = (PaletteWindow) GetWindow(typeof(PaletteWindow));
		window.Show();
		window.name = "Palette";
	}

	
	
	
	private void OnGUI()
	{
//		GUILayout.Label("Palette Toolset", EditorStyles.boldLabel);
		
		GUILayout.Label("Uber Color Convertor", EditorStyles.boldLabel);
		_stringForConvert = EditorGUILayout.TextField(_stringForConvert);
		
		
		
		GUILayout.Label("Byted RGBA Convertor", EditorStyles.boldLabel);
		_bytedString = EditorGUILayout.TextField("Text Field", _bytedString);
//		if ()
		
//		EditorGUILayout.TextField("Text Field", myString);

		groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
		myBool = EditorGUILayout.Toggle("Toggle", myBool);
		myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup();
	}
	
	
}