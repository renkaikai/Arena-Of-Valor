using UnityEngine;

public class ItemBase : ScriptableObject
{
    // Basic properties
    public int id;
    public new string name;
    public Sprite icon;
    public GameObject prefab;    
    
    public string description;
    public float price;
    // Effect properties
    public AudioClip audioEffect;
}
