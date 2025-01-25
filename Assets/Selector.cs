using UnityEngine;

public class Selector : MonoBehaviour
{
    public Generator gen;

    public GameObject higher;
    public GameObject longeur;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHigher()
    {
        gen.prefabToSpawn = higher;
    }
}
