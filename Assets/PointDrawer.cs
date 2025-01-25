using UnityEngine;
using System.Collections.Generic;

public class PointDrawer : MonoBehaviour
{
    public Functions functions;
    public GameObject pointPrefab; // Préfab pour les points
    public float pointSize = 10f; // Taille des points
    public float spacing = 1f;

    public float every = 10f;
    private float current = 0f;

    private List<GameObject> points;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = new List<GameObject> ();
        DrawPoints();
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        if (current > every)
        {
            DrawPoints();
            current = 0f;
        }
    }

    void Clear()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Destroy(points[i]);
        }

        points.Clear();
    }

    void DrawPoints()
    {
        if (functions == null || pointPrefab == null)
        {
            Debug.LogError("Missing references in PointDrawer script.");
            return;
        }
        Clear();

        float panelWidth = gameObject.GetComponent<RectTransform>().rect.width;
        float panelHeight = gameObject.GetComponent<RectTransform>().rect.height;

        // trouver max Y
        float _y = 1f; float _x = 0;
        for (; _y > 0; _x += 0.5f)
        {
            _y = functions.RunDerived(_x);
        }
        float maxY = functions.RunAway(_x);

        //trouver max X
        _y = 1;
        for (_x = 0; _y > 0; _x += 0.5f)
        {
            _y = functions.RunAway(_x);
        }
        float maxX = _x;


        int numPoints = 50;
        float startX = functions.startX;

        for (float i = startX; i < numPoints + startX; i+=0.2f)
        {
            float x = i * spacing;
            float y = functions.RunAway(x);
            Debug.Log("x " + x + " y " + y);
            if (y < 0f)
            {
                return;
            }
            Debug.Log("i");

            // Convertir les coordonnées en position locale du panneau
            Vector2 localPosition = new Vector2((x - startX) * panelWidth / maxX, y * panelHeight/ 2 / maxY);
            Vector2 anchoredPosition = new Vector2(localPosition.x - panelWidth / 2, localPosition.y - panelHeight );

            // Créer un point
            GameObject point = Instantiate(pointPrefab, gameObject.GetComponent<RectTransform>());
            points.Add(point);
            RectTransform pointRect = point.GetComponent<RectTransform>();
            pointRect.sizeDelta = new Vector2(pointSize, pointSize);
            pointRect.anchoredPosition = anchoredPosition;
        }
    }
}
