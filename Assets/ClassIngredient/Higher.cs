using UnityEngine;

public class Higher : MonoBehaviour, Ingrediant
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
        ((Parabolic)e).accumulate(1.2f, 0.08f);
    }

}
