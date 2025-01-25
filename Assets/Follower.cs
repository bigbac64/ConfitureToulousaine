using UnityEngine;

public class Follower : MonoBehaviour
{

    public GameObject followed;
    public float high = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followed != null)
        {
            
            transform.position = new Vector3(followed.transform.position.x, followed.transform.position.y + high, transform.position.z);
        }
    }


}
