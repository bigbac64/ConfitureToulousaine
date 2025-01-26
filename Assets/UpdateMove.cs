using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    Functions func;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        func = GameObject.Find("Manager").GetComponent<Functions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float value = Random.value;

        if (value > 0.7f)
            func.AddSatck(new Jump(other.transform.position.x + 2, Random.Range(1f, 10f), Random.Range(0.2f, 2.3f)));
        else if (value > 0.4f)
            func.AddSatck(new Spike(other.transform.position.x + 2, Random.Range(1f, 10f), Random.Range(0.2f, 2.3f)));
        else
            func.AddSatck(new Wave(Random.Range(0.2f, 1.2f), Random.Range(0.2f, 1.3f)));

        Destroy(gameObject);
    }
}
