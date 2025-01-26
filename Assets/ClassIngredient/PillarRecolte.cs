using System.Collections.Generic;
using UnityEngine;

public class PillarRecolte : MonoBehaviour, IRecolte
{
    public float scopePilier = 0.3f;
    public float scopeMousse = 0.2f;

    public float rangeMousse = 50f;
    public float diffPilier = 0.6f;
    public float diffMousse = 0.3f;

    public float luckySlime = 0.90f;

    public Dictionary<string, int> recolte(float x)
    {
        float found = x * diffPilier;
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            { "pilier", Random.Range(1 + Mathf.FloorToInt(found * (1 - scopePilier)), 1 + Mathf.FloorToInt(found * (1 + scopePilier))) },
        };

        found = x * diffMousse;
        if (x > rangeMousse)
        {
            dict.Add("Fleur", Random.Range(1 + Mathf.FloorToInt(found * (1 - scopeMousse)), 1 + Mathf.FloorToInt(found * (1 + scopeMousse))));
        }

        if (Random.value > luckySlime)
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
