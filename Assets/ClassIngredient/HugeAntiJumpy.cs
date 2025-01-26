using UnityEngine;

public class HugeAntiJumpy : MonoBehaviour, Ingrediant
{
    public float force = -5f;
    [Range(0.2f, 0.001f)]
    public float smoothness = 0.05f;

    public float posStep = 3f;

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
        return new Jump(0f, force, smoothness);
    }

    public void Applyer(MathFunction e)
    {
        ((Jump)e).accumulePos(posStep);
    }

}