using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System;

public class generatebarcode : MonoBehaviour {
	
	// Use this for initialization
	public int CubeHeight = 300;
	public int CubeWidth = 300;
	private Texture2D m_Texture;
	private Color[] m_Pixels;

	void Start() {
		// Create texture that will be updated in the plugin
		m_Texture = new Texture2D (CubeWidth, CubeHeight, TextureFormat.ARGB32, false);
		renderer.material.mainTexture = m_Texture;
		
		// Create the pixel array for the plugin to write into at startup    
		m_Pixels = m_Texture.GetPixels (0);
		// "pin" the array in memory, so we can pass direct pointer to it's data to the plugin,
		// without costly marshaling of array of structures.
		ZPAY.iOSBarCodeExpert.m_PixelsHandle = GCHandle.Alloc(m_Pixels, GCHandleType.Pinned);
		
		//	takeScreenShot(m_Texture.GetNativeTextureID());
		// Assign texture to the renderer
		if (renderer)
			renderer.material.mainTexture = m_Texture;
		// or gui texture
		else if (GetComponent(typeof(GUITexture)))
		{
			GUITexture gui = GetComponent(typeof(GUITexture)) as GUITexture;
			gui.texture = m_Texture;
		}
		else
		{
			Debug.Log("Game object has no renderer or gui texture to assign the generated texture to!");
		}
		ZPAY.iOSBarcodeHandler.ActionPluginError = new Action<string>(AcPluginError);
		ZPAY.iOSBarcodeHandler.ActionScanBarCode = new Action<string>(AcScanBarCode);
	}
	void OnDisable() {
		// Free the pinned array handle.
		ZPAY.iOSBarCodeExpert.m_PixelsHandle.Free();
	}
	//====================ScanBarcode ======================

	private string slideWidth = "300";
	private int iWidth = 300;
	private string slideType = "1";
	private string edtQR = "Text to encode";

	void OnGUI(){
		GUI.Label( new Rect(50f, 30f, 200f, 50f), new GUIContent("Width and Height: (300 - 500)", null, ""));
		slideWidth = GUI.TextField(new Rect(50f, 50f, 300f, 20f), slideWidth);
		GUI.Label( new Rect(50f, 90f, 300f, 20f), new GUIContent("Type: (1..11)", null, ""));
		slideType = GUI.TextField(new Rect(50f, 110f, 300f, 20f), slideType);
		GUI.Label( new Rect(50f, 30f, 200f, 50f), new GUIContent("String to encode", null, ""));
		edtQR = GUI.TextField(new Rect(50f, 190f, 300f, 20f), edtQR);
		if(GUI.Button( new Rect(50f, 163f, 300f, 20f), new GUIContent("Generate Bar Code", null, ""))){
			int iType = 1;
			int.TryParse(slideWidth, out iWidth);
			int.TryParse(slideType, out iType);
			ZPAY.iOSBarCodeExpert.EncodeBarcode(edtQR, iWidth, "decode.jpg", m_Texture.GetNativeTextureID(), iType);
			renderer.material.mainTexture = m_Texture;
		}
		if(GUI.Button(new Rect(50f, 241f, 100f, 50f), new GUIContent("Back", null, ""))) {
			Application.LoadLevel("mainmenu");
		}
	}
	// Action Callbacks
	public void AcPluginError(string sStr) {
		Debug.Log("The plugin reported an error: " + sStr);
	}
	public void AcScanBarCode(string sStr) {
		ZPAY.iOSBarCodeExpert.ShowAlert(sStr, "Barcode");
	}
}