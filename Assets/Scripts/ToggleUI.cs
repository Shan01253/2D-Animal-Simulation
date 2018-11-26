using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour {

    public GameObject toggleStore;
    public GameObject togglePause;
    public GameObject toggleAnimalInfo;

	// Use this for initialization
	void Start () {
        toggleStore.SetActive(false);
        togglePause.SetActive(false);
        toggleAnimalInfo.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        //**STORE**//
        if (Input.GetKeyDown("s"))
        {
            ToggleUIStore();
        }
        if (Input.GetKeyDown("p"))
        {
            ToggleUIPause();
        }
	}

    public void ToggleUIAnimalInfo(){
        toggleAnimalInfo.SetActive(!toggleAnimalInfo.activeSelf);
    }
    public void ToggleUIStore()
    {
        toggleStore.SetActive(!toggleStore.activeSelf);
    }

    public void ToggleUIPause()
    {
        togglePause.SetActive(!togglePause.activeSelf);
        if(togglePause.activeSelf == true)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
}
