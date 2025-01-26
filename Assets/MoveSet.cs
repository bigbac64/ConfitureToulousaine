using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public GameObject manager;
    private Functions func;
    private Inventory inventory;
    private UIGestion ui;
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

    public bool isMoving = false;


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
        inventory = manager.GetComponent<Inventory>();
        ui = manager.GetComponent<UIGestion>();
        func.startX = transform.position.x;
        func.startY = transform.position.y;

        StartCoroutine(UpdateOperation());
    }

    public void AddFunc(MathFunction func)
    {
        if (this.func == null)
            this.func = manager.GetComponent<Functions>();
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


    }

    IEnumerator UpdateOperation()
    {
        while (true)
        {

            DrawLine(); 
            // Attend une seconde avant de répéter
            yield return new WaitForSeconds(0.2f);
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
        IRecolte recept = collision.gameObject.GetComponent<IRecolte>();
        if (recept != null)
        {
            Dictionary<string, int> getr = recept.recolte(transform.position.x);
            ui.closeMixer();
            ui.showResume();
            int i = 1;
            foreach (string key in getr.Keys)
            {
                ui.writeResume(i, key, getr[key].ToString());
                Debug.Log("recolted " + getr[key]);
                inventory.SetObject(key, getr[key]);
                i++;
            }
        }
        isMoving = false;
    }

    public void ResetPlay()
    {
        transform.position = new Vector3(func.startX, func.startY, 0);
        isMoving = false;
        forward = 0f;
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
