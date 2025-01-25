using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public GameObject manager;
    private Functions func;

    public float time = 5f;
    public float speed = 0.05f;
    private float forward = 0f;

    public float heightCourbe = 5f;
    public float forceCourbe = 5f;

    public float frequencyInstability = 0f;
    public float forceInstability = 0f;

    public float forceJump = 0f;
    public float smoothJump = 0f;

    private bool isMoving = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        func = manager.GetComponent<Functions>();
        func.startX = transform.position.x;
        func.startY = transform.position.y;

    }

    public void AddFunc(MathFunction func)
    {
        this.func.AddSatck(func);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.y >= 0 && isMoving)
        {
            forward += speed;
            float y = func.RunAway(forward);
            Vector3 pos = gameObject.transform.position;
            pos.y = y;
            pos.x = forward;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isMoving)
            Jump();

        if(Input.GetKeyUp(KeyCode.P))
            isMoving = true;

    }

    public void Jump()
    {
        if (isMoving)
        {
            func.AddSatck(new Jump(transform.position.x + 2, forceJump, smoothJump));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isMoving = false;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            if (func == null) 
                func = manager.GetComponent<Functions>();

            func.startX = transform.position.x;
            func.startY = transform.position.y;

            func.ResetStack();
            func.AddSatck(new Parabolic(heightCourbe, forceCourbe));
            func.AddSatck(new Wave(frequencyInstability, forceInstability));
            func.AddSatck(new Jump(10, 4, 5));
            func.AddSatck(new Spike(15, 3, 8));
            func.AddSatck(new Jump(34, -5, 20));
        }

        Gizmos.color = Color.red;
        Vector3 previousPoint = gameObject.transform.position;

        float y = 0f;

        for (float t = gameObject.transform.position.x; y >= 0; t += 0.01f)
        {
            if (t > 1000)
                return;
            y = func.RunAway(t);
            Vector3 currentPoint = new Vector3(t, y, 0);

            Gizmos.DrawLine(previousPoint, currentPoint);

            previousPoint = currentPoint;
        }
    }
}
