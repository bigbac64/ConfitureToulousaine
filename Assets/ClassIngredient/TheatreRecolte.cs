using System.Collections.Generic;
using UnityEngine;

public class TheatreRecolte : MonoBehaviour, IRecolte
{
    public float scopeTesson = 0.2f;

    public float diffTesson = 0.3f;

    public float luckySlime = 0.75f;

    public Dictionary<string, int> recolte(float x)
    {
        float found = x * diffTesson;
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            { "tesson", Random.Range(1 + Mathf.FloorToInt(found * (1 - scopeTesson)), 1 + Mathf.FloorToInt(found * (1 + scopeTesson))) },
        };

        if (Random.value > luckySlime)
        {
            dict.Add("slime", Random.Range(3, 5));
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
