using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject finish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        finish.SetActive(true);
    }
}
