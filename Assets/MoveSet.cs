using System.Collections;
using UnityEditor;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public GameObject manager;
    private Functions func;
    private LineRenderer lineRenderer;

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
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.051f;
        lineRenderer.endWidth = 0.051f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        func = manager.GetComponent<Functions>();
        func.startX = transform.position.x;
        func.startY = transform.position.y;

        StartCoroutine(UpdateOperation());
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

    IEnumerator UpdateOperation()
    {
        while (true)
        {

            DrawLine(); 
            // Attend une seconde avant de répéter
            yield return new WaitForSeconds(0.1f);
        }
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

    private void DrawLine()
    {
        lineRenderer.positionCount = 0;

        float y = 0.1f;

        for (float t = gameObject.transform.position.x; y > 0; t += 0.1f)
        {
            if (t > 1000)
                return;
            y = func.RunAway(t);
            Vector3 currentPoint = new Vector3(t, y, 0);

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPoint);
        }
    }
}
