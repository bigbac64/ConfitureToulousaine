using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject canette;
    public GameObject pilier;
    public GameObject fleur;
    public GameObject mousse;
    public GameObject slime;
    public GameObject tesson;

    public GameObject UICanette;
    public GameObject UIPilier;
    public GameObject UIFleur;
    public GameObject UIMousse;
    public GameObject UISlime;
    public GameObject UITesson;

    public Dictionary<string, int> inventory;
    public Dictionary<string, GameObject> ui;
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

        ui = new Dictionary<string, GameObject>
        {
            {"canette", UICanette },
            {"pilier", UIPilier },
            {"fleur", UIFleur },
            {"mousse", UIMousse },
            {"slime", UISlime },
            {"tesson", UITesson },
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
        ui[obj].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = obj + " - " + inventory[obj];
    }
}
