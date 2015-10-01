using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace ZPAY {
	///<summary>iOS Text to Speech Expert for iOS</summary>
	public class iOSTTExpert {
	//============== TTS Plugin =======
	///<summary>Show iOS Alert</summary>
	///<param name="msg">Message to Popup</param>
	[DllImport("__Internal")]
	public static extern void showAlert(string msg);

	///<summary>Start Talking</summary>
	///<param name="str">Text to talk</param>
	[DllImport("__Internal")]
	public static extern void StartTalking(string str);
	
	///<summary>Start Talking with detailed parameters</summary>
	///<param name="str">Text to talk</param> 
	///<param name="_speed">TTS Voice Speech</param>
	///<param name="_pitch">TTS Speech</param>
	///<param name="_variance">TTS Voice Variance</param>
	///<remarks>Default Value for speed is 1.1. Min:0 Max: 1.1
	///Pitch: Default Value:125 min:0 max:125.
	///Variance: Default Value:11 Min:0 Max:11.
	///</remarks>
	[DllImport("__Internal")]
	public static extern void StartTalking2(string str, float _pitch, float _variance, float _speed);

	///<summary>Stop TTS Talking</summary>
	[DllImport("__Internal")]
	public static extern void StopTalking();

			
	///<summary>Set Volume</summary>
	///<param name="_volume">Set the volume</param>
	///<value>The float values are from 0 to 1</value>
	///<remarks>Default Value:1 min:0 max:1</remarks>
	[DllImport("__Internal")]
	public static extern void SetVolume(float _volume);
	///<summary>Get Volume</summary>
	///<returns>Get the Volume</returns>
	///<value>The float values are from 0 to 1</value>
	[DllImport("__Internal")]
	public static extern float GetVolume();


	///<summary>Get TTS Voice Pitch</summary>
	///<returns>Returns the TTS pitch</returns>
	[DllImport("__Internal")]
	public static extern float GetPitch();
	///<summary>Set TTS Voice Pitch</summary>
	///<param name="_pitch">Set the TTS voice pitch</param>
	///<value>Default Value:125 min:0 max:125</value>
	[DllImport("__Internal")]
	public static extern void SetPitch(float _pitch);

	///<summary>Get TTS Voice Name</summary>
	///<returns>Return the TTS Voice name</returns>
	[DllImport("__Internal")]
	public static extern string GetVoice();
	///<summary>Set Voice</summary>
	///<param name="voicename">Set the TTS voice name</param>
	///<remarks>Parameters are: "cmu_us_kal" or "cmu_us_kal16" or "cmu_us_rms" or "cmu_us_awb" or "cmu_us_slt"</remarks>
	[DllImport("__Internal")]
	public static extern void SetVoice(string voicename);


	///<summary>Set TTS Voice Dictation Speed</summary>
	///<param name="_speed">Speed</param>
	///<value>Default Value:1.1 Min:0 Max:1.1</value>
	[DllImport("__Internal")]
	public static extern void SetSpeed(float _speed);
	///<summary>Get TTS Voice Dictation Speed</summary>
	///<returns>Return the speed</returns>
	[DllImport("__Internal")]
	public static extern float GetSpeed();
		
		
	///<summary>Get Voice Variance</summary>
	///<returns>Return the TTS Voice Variance</returns>
	[DllImport("__Internal")]
	public static extern float GetVariance();
	///<summary>Set Voice Variance</summary>
	///<param name="_variance">Volume Parameter</param>
	///<remarks>Default Value:11 Min:0 Max:11</remarks>
	[DllImport("__Internal")]
	public static extern void SetVariance(float _variance);
	//=========================================================

	///<summary>Voice Change event</summary>
	///<param name="data">Empty string returned from iOS Plugin</param>
	///<remarks>This event is triggered when TTS voice has changed.</remarks>
	public void OnChangeVoice(string data) {
	}
	///<summary>Stop Talking event</summary>
	///<param name="data">Empty string returned from iOS Plugin</param>
	///<remarks>This event is triggered when TTS talking has stopped.</remarks>
	public void OnStopTalking(string data)  {
	}
	///<summary>Talking Complete event.</summary>
	///<param name="data">Empty string returned from iOS Plugin</param>
	///<remarks>This event is triggered when TTS talking is completed.</remarks>
	public void OnTalkingComplete(string data) {
	}
	///<summary>Start Talking event</summary>
	///<param name="data">Empty string returned from iOS Plugin</param>
	///<remarks>This event is triggered when TTS talking has started</remarks>
	public void OnStartTalking(string data) {
	}
}
}