using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public List<Button> buttonList = new List<Button>();
	public Button[] hotBar = new Button[3];
	public bool inventory;
	public GameObject inventoyrPanel;
	public Transform originalPosition;

	void Awake(){


	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (buttonList.Count == 1) { 
			buttonList [0].transform.position = hotBar [0].transform.position;
		}if (buttonList.Count == 2) {
			buttonList [1].transform.position = hotBar [1].transform.position;
		}if (buttonList.Count == 3) {
			buttonList [2].transform.position = hotBar [2].transform.position;
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			inventory = !inventory;
		}

	}


	public void OriginalPosition(Button button){

		button.transform.position = originalPosition.position;
	}
}
