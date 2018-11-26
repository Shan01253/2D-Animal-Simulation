using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteraction : MonoBehaviour {

    public bool isEating = false;
    public GameObject currentInterObject = null;

    public int min = 0;
    public int max = 4;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grass"))
        {
            currentInterObject = other.gameObject;
            EatInteractable(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("grass"))
        {
            if (other.gameObject == currentInterObject)
            {
                currentInterObject = null;  
            }
        }   
    }

    private void EatInteractable(Collider2D other)
    {
        //Debug.Log("do I eat?");
        if ((int) Random.Range(min, max) >= (max /2))
        {
            Destroy(other.gameObject);
            isEating = true;
           // Debug.Log("I ate");
        } else
        {
            isEating = false;
           // Debug.Log("not hungry");
        }
    }
}
