using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public GameObject jumper;
    public ParticleSystem particleSystem;

    public Dictionary<string, MathFunction> stacker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPlay()
    {
        stacker = new Dictionary<string, MathFunction>
        {
            { typeof(Parabolic).Name, new Parabolic(1, 0.5f) }
        };
        jumper.GetComponent<MoveSet>().AddFunc(stacker[typeof(Parabolic).Name]);
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

            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            ing.Applyer(stacker[nameType]);

            Destroy(other.gameObject);
        }
    }
}
