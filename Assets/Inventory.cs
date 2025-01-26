using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject canette;
    public GameObject pilier;
    public GameObject fleur;
    public GameObject mousse;
    public GameObject slime;
    public GameObject tesson;

    public Dictionary<string, int> inventory;
    private Dictionary<string, GameObject> prefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prefab = new Dictionary<string, GameObject>
        {
            {"canette", canette },
            {"pilier", pilier },
            {"fleur", fleur },
            {"mousse", mousse },
            {"slime", slime },
            {"tesson", tesson },
        };

        inventory = new Dictionary<string, int>{
            {"canette", 0 },
            {"pilier", 0 },
            {"fleur", 0 },
            {"mousse", 0 },
            {"slime", 0 },
            {"tesson", 0 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObject(string obj, int count)
    {
        inventory[obj] += count;
    }
}
