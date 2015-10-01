using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System;

// Capture Bar-code from Camera
public class capturecamera : MonoBehaviour {
	
	// Initialization
	void Start () {
		m_Texture = new Texture2D (width, height, TextureFormat.ARGB32, false);
		renderer.material.mainTexture = m_Texture;
		m_Pixels = m_Texture.GetPixels (0);
		ZPAY.iOSBarCodeExpert.m_PixelsHandle = GCHandle.Alloc(m_Pixels, GCHandleType.Pinned);
		if (renderer)
			renderer.material.mainTexture = m_Texture;
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
	private int iWidth = 100;
	public int width = 256;
	public int height = 256;
	private Texture2D m_Texture;
	private Color[] m_Pixels;
	//====================ScanBarcode ======================

	private string slideWidth = "300";
	private string slideType = "1";
	private string flashType = "1";

	void OnGUI() {
		GUI.Label(new Rect(50f, 30f, 200f, 50f), new GUIContent("Width and Height: (300 - 500)", null, ""));
		slideWidth = GUI.TextField(new Rect(50f, 50f, 300f, 20f), slideWidth);
		GUI.Label(new Rect(50f, 90f, 300f, 20f), new GUIContent("Flash (0..1)", null, ""));
		flashType = GUI.TextField(new Rect(50f, 110f, 300f, 20f), flashType);
		if(GUI.Button(new Rect(50f, 204f, 300f, 20f), new GUIContent("Scan QR", null, ""))) {
			int iType = 1;
			int iFlash = 1;
			int.TryParse(slideWidth, out iWidth);
			int.TryParse(slideType, out iType);
			int.TryParse(flashType, out iFlash);
			// Filename is needed.
			ZPAY.iOSBarCodeExpert.ScanBarcode(iWidth, "decode.jpg", m_Texture.GetNativeTextureID(), (iFlash >= 1));
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