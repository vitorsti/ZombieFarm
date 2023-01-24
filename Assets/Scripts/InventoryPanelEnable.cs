using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPanelEnable : MonoBehaviour, IPointerEnterHandler {

	public Image inventoyrPanel;
	public string textString;
	public Image imageDisplay;
	public Sprite sprite;
	public Text text;

	// Use this for initialization
	void Start () {
		
		inventoyrPanel.enabled = false;
		text.enabled = false;	
	}


	public void OnPointerEnter(PointerEventData pointerEventData){

		if((inventoyrPanel.enabled == false) && (text.enabled == false)){

			inventoyrPanel.enabled = true;
			text.enabled = true;		
		}
				
		text.text = textString;
		imageDisplay.sprite = sprite;
	}
}
