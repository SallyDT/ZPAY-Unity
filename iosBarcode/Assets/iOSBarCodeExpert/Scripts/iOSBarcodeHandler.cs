using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System;

namespace ZPAY {
	///<summary>iOS BarCode Expert Callback Handler</summary>
	public class iOSBarcodeHandler : MonoBehaviour {
		///<summary>PluginError Callback</summary>
		public static Action<string> ActionPluginError;

		///<summary>Scan Barcode Callback</summary>
		public static Action<string> ActionScanBarCode;

		///<summary>Plugin error Event</summary>
		///<param name="errMsg">Empty string returned from iOS Plugin</param>
		///<remarks>This event is triggered when Barcode Plugin reported an error</remarks>
		public void OnPluginError(string errMsg) {
			if(ActionPluginError != null) {
				ActionPluginError(errMsg);
			}
			//Debug.Log("The plugin reported an error: " + errMsg);
		}
		
		///<summary>Scan Barcode Event</summary>
		///<param name="data">Data from Barcode Capture from Camera</param>
		///<remarks>This event is triggered when Barcode is captured</remarks>
		public void OnScanBarcode(string data) {
			if(ActionScanBarCode != null) {
				ActionScanBarCode(data);
			}
			//ZPAY.iOSBarCodeExpert.ShowAlert(data, "ALERT!");
		}
	}
}

