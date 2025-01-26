using System.Collections.Generic;
using UnityEngine;

public class GroundRecolte : MonoBehaviour, IRecolte
{
    public float scopeCanette = 0.3f;
    public float scopeFleur = 0.5f;

    public float rangeFleur = 100f;
    public float diffCanette = 0.5f;
    public float diffFleur = 0.2f;

    public float luckySlime = 0.95f;

    public Dictionary<string, int> recolte(float x)
    {
        float found = x * diffCanette;
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            { "canette", Random.Range(1 + Mathf.FloorToInt(found * (1 - scopeCanette)), 1 + Mathf.FloorToInt(found * (1 + scopeCanette))) },
        };

        found = x * diffFleur;
        if(x > rangeFleur)
        {
            dict.Add("Fleur", Random.Range(1 + Mathf.FloorToInt(found * (1 - scopeFleur)), 1 + Mathf.FloorToInt(found * (1 + scopeFleur))));
        }

        if(Random.value > luckySlime)
        {
            dict.Add("slime", Random.Range(1, 3));
        }

        return dict;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
