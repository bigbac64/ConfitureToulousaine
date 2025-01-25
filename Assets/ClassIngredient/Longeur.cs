using UnityEngine;

public class Longeur : MonoBehaviour, Ingrediant
{
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
        return new Parabolic();
    }

    public void Applyer(MathFunction e)
    {
        ((Parabolic)e).accumulate(-0.12f, 2.5f);
    }
}
