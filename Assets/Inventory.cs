using NUnit.Framework.Internal;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private Generator gen;

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
    public GameObject UIJump;

    public Dictionary<string, int> inventory;
    public Dictionary<string, GameObject> ui;
    private Dictionary<string, GameObject> prefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gen = GetComponent<Game>().gen;

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
            {"jump", UIJump },
        };

        inventory = new Dictionary<string, int>{
            {"canette", 20 },
            {"pilier", 20 },
            {"fleur", 20 },
            {"mousse", 20 },
            {"slime", 10 },
            {"tesson", 0 },
            {"jump", 1 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setJump(int count)
    {
        if (inventory["jump"] + count < 0)
        {
            return;
        }
        inventory["jump"] += count;
        ui["jump"].transform.Find("counter").GetComponent<TextMeshProUGUI>().text = inventory["jump"].ToString();
    }

    public void SetObject(string obj, int count)
    {
        if (inventory[obj] + count < 0)
        {
            return;
        }
        inventory[obj] += count;
        ui[obj].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = obj + " - " + inventory[obj];
    }

    public void SelectHigher()
    {
        gen.prefabToSpawn = pilier;
        gen.name = "pilier";
    }

    public void SelectLongeur()
    {
        gen.prefabToSpawn = canette;
        gen.name = "canette";
    }

    public void SelectHugeJump()
    {
        gen.prefabToSpawn = fleur;
        gen.name = "fleur";
    }

    public void SelectHugeAntiJump()
    {
        gen.prefabToSpawn = mousse;
        gen.name = "mousse";
    }

    public void SelectReJump()
    {
        gen.prefabToSpawn = slime;
        gen.name = "slime";
    }
}
