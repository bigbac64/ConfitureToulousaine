using UnityEngine;

public class GainJump : MonoBehaviour, Ingrediant
{
    GameObject manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("Manager");
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
        manager.GetComponent<Inventory>().setJump(1);
    }

}
