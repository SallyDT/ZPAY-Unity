using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

public class mainmenu : MonoBehaviour {
	void OnGUI() {
		GUI.Label(new Rect(50f, 30f, 200f, 50f), new GUIContent("Bar Code & QR Code Expert", null, ""));
		if(GUI.Button(new Rect(50f, 69f, 150f, 50f), new GUIContent("Generate", null, ""))) { Application.LoadLevel("generatebarcode"); }
		if(GUI.Button(new Rect(50f, 133f, 150f, 50f), new GUIContent("Capture from Photo", null, ""))) { Application.LoadLevel("capturephoto"); }
		if(GUI.Button(new Rect(50f, 193f, 150f, 50f), new GUIContent("Capture from Camera", null, ""))) { Application.LoadLevel("capturecamera"); }
	}
}