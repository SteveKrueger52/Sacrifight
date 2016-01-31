﻿using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	public int playerNum;
	string[] items = new string[5];
	int idx = 0;
	Animation anim;
	Animator anim2;
	public int convertcooldown = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		anim2 = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = (InputManager.Devices.Count > playerNum) ? InputManager.Devices[playerNum] : null;
		if (inputDevice == null)
		{
			Destroy(this.gameObject);
		}
		else
		{
			UpdateCubeWithInputDevice(inputDevice);
		}
	}

	void UpdateCubeWithInputDevice(InputDevice device)
	{
		if (device.Action2) {
			anim2.SetBool ("Stab", true);
		}
		else {
			anim2.SetBool ("Stab", false);
		}
		if (device.LeftStick.X == 0f && device.LeftStick.Y == 0f) {
			anim2.SetBool ("moving", false);
		} else {
			anim2.SetBool ("moving", true);
		}
		transform.Translate (new Vector3 (Time.deltaTime * device.LeftStick.X, Time.deltaTime * device.LeftStick.Y, 0f), Space.World);	
	}

} 