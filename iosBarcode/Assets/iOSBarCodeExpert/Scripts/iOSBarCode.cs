using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace ZPAY {
	///<summary>iOS BarCode Expert for iOS</summary>
	public class iOSBarCodeExpert {
		/*
		Type:
		case 1:
			BarcodeFormatQRCode
			Charset: All ASCII characters
			Length: Variable
		case 2:
			BarcodeFormatAztec
			Charset: All ASCII characters
			Length: Variable
		case 3:
			BarcodeFormatCodabar
			+should end with one of the following: 'T', 'N', '*' or 'E'
			+should start with one of the following: 'A', 'B', 'C' or 'D'
			Charset: A-Z, 0-9, -,.*$/+% 
			Length: max. 12 digits
		case 4:
			BarcodeFormatCode128
			Charset: All ASCII characters
			Length: Variable
		case 5:
			BarcodeFormatCode39
			Charset: A-Z, 0-9, -,.*$/+%
			Length: Variable
		case 6:
			BarcodeFormatDataMatrix
			Charset: All ASCII characters
			Length: Variable
			MinWidth: 15 pixels
		case 7:
			BarcodeFormatEan13
			Charset: 0-9 
			Length: max. 12 digits
			MinWidth: 128 pixels
		case 8:
			BarcodeFormatEan8
			Charset: 0-9 
			Length: max. 8 digits
			MinWidth: 128 pixels
		case 9:
			BarcodeFormatITF
			Charset: 0-9 
			Length: max. 12 digits
			MinWidth: 128 pixels
		case 10:
			BarcodeFormatPDF417
			Charset: All ASCII characters
			Length: Variable
			MinWidth: 300 pixels
		case 11:
			BarcodeFormatUPCA
			Charset: 0-9 
			Length: max. 12 digits
			MinWidth: 128 pixels
		*/
		///<summary>Scan a barcode or QR code by file</summary>
		///<param name="width">width of bar code</param>
		///<param name="filename">filename</param>
		///<param name="texture">handle to texture</param>
		///<returns>Return Decoded string</returns>
		[DllImport("__Internal")]
		public static extern string ScanBarcodeByFile(int width, string filename, int texture);
		//return path image file
		///<summary>Scan a barcode or QR code by camera</summary>
		///<param name="width">width of bar code</param>
		///<param name="filename">filename</param>
		///<param name="texture">handle to texture</param>
		///<param name="flashlight">Turn on flash-light during Photo-capture</param>
		///<returns>Return Decoded string</returns>
		[DllImport("__Internal")]
		public static extern string ScanBarcode(int width, string filename, int texture, bool flashlight);
		//return path image file
		///<summary>Encode a barcode from existing text</summary>
		///<param name="str">String to encode</param>
		///<param name="width">width of bar code</param>
		///<param name="filename">filename</param>
		///<param name="texture">handle to texture</param>
		///<param name="type">Type of Barcode</param>
		///<returns>Return Encode string</returns>
		[DllImport("__Internal")]
		public static extern string EncodeBarcode(string str, int width, string filename, int texture, int type);
		
		///<summary>Show iOS Alert</summary>
		///<param name="msg">Message to Popup</param>
		///<param name="title">Title of Messagebox to Popup</param>
		[DllImport("__Internal")]
		public static extern void ShowAlert(string msg, string title);

		///<summary>Pixel Handle</summary>
		public static GCHandle m_PixelsHandle;
	}
}