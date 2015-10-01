using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[ExecuteInEditMode]
public class DemoiOSTTS : MonoBehaviour {
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private string edtVariance = "1.1";
	private string edtPitch = "125";
	private string edtVolume = "1";
	private string edtVoiceSpeed = "1.1";
	private string edtText = "Please input the text to speak";


	void OnGUI() {
		if (GUI.Button(new Rect(50f, 40f, 120f, 25f), new GUIContent("Get Variance", null, ""))) {
			ZPAY.iOSTTExpert.showAlert("GetVariance function returns: " + ZPAY.iOSTTExpert.GetVariance().ToString());
		}
		edtVariance = GUI.TextField(new Rect(254f, 40f, 100f, 25f), edtVariance, 5);
		if (GUI.Button(new Rect(50f, 80f, 120f, 25f), new GUIContent("Get Pitch", null, ""))) {
			ZPAY.iOSTTExpert.showAlert("GetPitch function returns: " + ZPAY.iOSTTExpert.GetPitch().ToString());
		}
		if (GUI.Button(new Rect(370f, 80f, 130f, 25f), new GUIContent("Set Pitch", null, ""))) {
			ZPAY.iOSTTExpert.SetPitch(float.Parse(edtPitch));
		}
		GUI.Label(new Rect(180f, 45f, 100f, 25f), new GUIContent("Variance:", null, ""));
		if (GUI.Button(new Rect(370f, 39f, 130f, 25f), new GUIContent("Set Variance", null, ""))) {
			ZPAY.iOSTTExpert.SetVariance(float.Parse(edtVariance));
		}
		GUI.Label(new Rect(200f, 85f, 200f, 25f), new GUIContent("Pitch:", null, ""));
		edtPitch = GUI.TextField(new Rect(254f, 80f, 100f, 25f), edtPitch, 5);
		if (GUI.Button(new Rect(50f, 120f, 120f, 25f), new GUIContent("Get Volume", null, ""))) {
			ZPAY.iOSTTExpert.showAlert("GetVolume function returns: " + ZPAY.iOSTTExpert.GetVolume().ToString());
		}
		if (GUI.Button(new Rect(50f, 160f, 120f, 25f), new GUIContent("Get Voice Speed", null, ""))) {
			ZPAY.iOSTTExpert.showAlert("GetSpeed function returns: " + ZPAY.iOSTTExpert.GetSpeed().ToString());
		}
		GUI.Label(new Rect(185f, 125f, 100f, 25f), new GUIContent("Volume:", null, ""));
		GUI.Label(new Rect(190f, 165f, 100f, 25f), new GUIContent("Speed:", null, ""));
		edtVolume = GUI.TextField(new Rect(250f, 120f, 100f, 25f), edtVolume, 10);
		edtVoiceSpeed = GUI.TextField(new Rect(250f, 160f, 100f, 25f), edtVoiceSpeed, 10);
		if (GUI.Button(new Rect(370f, 120f, 130f, 25f), new GUIContent("Set Volume", null, ""))) { }
		if (GUI.Button(new Rect(370f, 160f, 130f, 25f), new GUIContent("Set Voice Speed", null, ""))) {
			ZPAY.iOSTTExpert.SetSpeed(float.Parse(edtVoiceSpeed));
		}
		GUI.Label(new Rect(50f, 18f, 130f, 25f), new GUIContent("Voice Parameters", null, ""));
		edtText = GUI.TextArea(new Rect(50f, 230f, 300f, 90f), edtText, 999);

		if (GUI.Button(new Rect(50f, 370f, 130f, 25f), new GUIContent("Set Voice \"kal16\"", null, ""))) {
			ZPAY.iOSTTExpert.SetVoice("cmu_us_kal16");
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(240f, 370f, 130f, 25f), new GUIContent("Set voice \"kal\"", null, ""))) {			//cmu_us_slt
			ZPAY.iOSTTExpert.SetVoice("cmu_us_kal");
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(50f, 410f, 130f, 25f), new GUIContent("Set voice \"rms\"", null, ""))) {			//cmu_us_rms
			ZPAY.iOSTTExpert.SetVoice("cmu_us_rms");
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(240f, 410f, 130f, 25f), new GUIContent("Set voice \"awb\"", null, ""))) {			//cmu_us_awb
			ZPAY.iOSTTExpert.SetVoice("cmu_us_awb");
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(50f, 450f, 130f, 25f), new GUIContent("Set voice \"slt\"", null, ""))) {			//cmu_us_slt
			ZPAY.iOSTTExpert.SetVoice("cmu_us_slt");
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(370f, 229f, 130f, 25f), new GUIContent("Start Talking", null, ""))) {
			ZPAY.iOSTTExpert.StartTalking(edtText);
		}
		if (GUI.Button(new Rect(240f, 450f, 130f, 25f), new GUIContent("Get Voice", null, ""))) { ZPAY.iOSTTExpert.showAlert("GetVoice function returns: " + ZPAY.iOSTTExpert.GetVoice()); }
		if (GUI.Button(new Rect(370f, 270f, 130f, 25f), new GUIContent("Stop Talking", null, ""))) {
			ZPAY.iOSTTExpert.StopTalking();
		}
		GUI.Label( new Rect(513f, 43f, 130f, 25f), new GUIContent("0 to 1.1", null, ""));
		GUI.Label( new Rect(513f, 84f, 130f, 25f), new GUIContent("0 to 125", null, ""));
		GUI.Label( new Rect(512f, 124f, 130f, 25f), new GUIContent("0 to 1", null, ""));
		GUI.Label( new Rect(511f, 164f, 130f, 25f), new GUIContent("0 to 1.1", null, ""));
	}
}


