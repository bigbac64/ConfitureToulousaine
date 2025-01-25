using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public GameObject jumper;

    public Dictionary<string, MathFunction> stacker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stacker = new Dictionary<string, MathFunction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingrediant"))
        {
            Ingrediant ing = other.GetComponent<Ingrediant>();
            string nameType = ing.Type().GetType().Name;

            if (!stacker.ContainsKey(nameType))
            {
                stacker.Add(nameType, ing.Type());
                jumper.GetComponent<MoveSet>().AddFunc(stacker[nameType]);
            }
            
            ing.Applyer(stacker[nameType]);

            Destroy(other.gameObject);
        }
    }
}
