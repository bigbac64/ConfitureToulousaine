using UnityEngine;

public class Waving : MonoBehaviour, Ingrediant
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
        return new Wave(0, 1);
    }

    public void Applyer(MathFunction e)
    {
        ((Wave)e).accumulate(0.3f, 0);
    }

}