using UnityEngine;

public class Wavy : MonoBehaviour, Ingrediant
{
    public float frequency = 10f;
    public float force = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public MathFunction Type()
    {
        return new Wave(0.1f, 2f);
    }

    public void Applyer(MathFunction e)
    {
        ((Wave)e).accumulate(frequency, force);
    }

}