using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animals/New Animal")]
public class Animal : ScriptableObject {

    new public string name = "New Animal";
    public GameObject icon = null;
    public bool isDefaultItem = false;
    public int cost = 0;
    public int health = 100;
    public int hunger = 100;
    public Sprite sprite = null;

}
