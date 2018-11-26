using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Animal animal;

    public MoneyManager moneyManager;


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int animalCost = animal.cost;
        if(animalCost <= moneyManager.money)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(animal.icon, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            gameObject.transform.localPosition = new Vector3(0, 1, 0);
            moneyManager.money -= animalCost;

            Debug.Log("you have " + moneyManager.money + " left over");
        } else
        {
            gameObject.transform.localPosition = new Vector3(0, 1, 0);
            Debug.LogWarning("Not Enough Money!");
        }
    }
}
