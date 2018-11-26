using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHighlight : MonoBehaviour {

    public GameObject highlight;
    public GameObject animalInfo;
    private bool isShowingInfo;

	// Use this for initialization
	void Start () {
        highlight.SetActive(false);
        isShowingInfo = false;
	}
	void Update(){
		if(isShowingInfo == true)
		{
			if(Input.GetMouseButton(1)) { // if right click, close panel
				animalInfo.SetActive(false);
				isShowingInfo = false;
			}
		}
	}

	private void OnMouseDown(){
		animalInfo.SetActive(true); // DOES NOT WORK. WANT IT TO DISPLAY ANIMAL INFO WHEN IT IS CLICKED
		isShowingInfo = true;
	}
	private void OnMouseUp(){
		//animalInfo.SetActive(false);
	}
    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
