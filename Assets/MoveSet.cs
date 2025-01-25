using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public float time = 5f;
    public float speed = 0.1f;
    private float timeElapsed = 0f;
    private float forward = 0f;

    public float heightCourbe = 5f;
    public float forceCourbe = 5f;

    public float frequencyInstability = 0f;
    public float forceInstability = 0f;

    public float forceJump = 0f;
    public float smoothJump = 0f;

    private float startX;
    private float startY;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startX = gameObject.transform.position.x;
        startY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= time && gameObject.transform.position.y >= 0)
        {
            forward += speed;
            float y = FnParabolic(forward, heightCourbe, forceCourbe) + FnInstability(forward, frequencyInstability, forceInstability) + FnJump(forward, 45, forceJump, smoothJump);
            Vector3 pos = gameObject.transform.position;
            pos.y = y;
            pos.x = forward;
            gameObject.transform.position = pos;
            timeElapsed = 0;
        }

    }


    /// <summary>
    /// Calcule la position sur une trajectoire parabolique selon le temps donné.
    /// </summary>
    /// <param name="time">Position temporelle (normalisée entre 0 et 1).</param>
    /// <param name="maxHeight">Hauteur maximale de la parabole.</param>
    /// <param name="force">Puissance d'éjection sur l'axe X.</param>
    /// <returns>La position y (float) sur la parabole.</returns>
    public float FnParabolic(float time, float maxHeight, float force)
    {
        return -1 / force * Mathf.Pow(time - Mathf.Sqrt(maxHeight * force) - startX, 2) + maxHeight + startY;
    }

    /// <summary>
    /// Fonction représentant une distorsion appliquée à la trajectoire.
    /// </summary>
    /// <param name="x">Position ou trouver y</param>
    /// <param name="frequency">Fréquence du motif appliqué.</param>
    /// <param name="strength">Amplitude de la distorsion.</param>
    /// <returns></returns>
    public float FnInstability(float x, float frequency, float strength)
    {
        // can add as +
        return frequency * Mathf.Sin(strength * x);
    }

    /// <summary>
    /// Fonction représentant un pique sur la trajectoire.
    /// </summary>
    /// <param name="x">Position ou trouver y</param>
    /// <param name="pos">Position ou placer le pique</param>
    /// <param name="height">Hauteur du pique à ajouter</param>
    /// <param name="smoothness">Lissage du pique</param>
    /// <returns></returns>
    public float FnSpike(float x, float pos, float height, float smoothness)
    {
        // can add as +
        return height * Mathf.Exp(-Mathf.Pow(x - pos + 1 + smoothness / 10, 2) / (2 * Mathf.Pow(smoothness, 2)));
    }

    /// <summary>
    /// Fonction représentant un saut, comme un pique mais avec une continuité de la courbe
    /// </summary>
    /// <param name="x">Position ou trouver y</param>
    /// <param name="pos">Position ou placer le saut</param>
    /// <param name="strength">force du saut</param>
    /// <param name="smoothness">Lissage du saut</param>
    /// <returns></returns>
    public float FnJump(float x, float pos, float strength, float smoothness)
    {
        // le "pos + 1 + roughness / 10" est pour que le jump se declanche apres la pos de x
        return strength / (1 + Mathf.Exp(-smoothness * (x - pos + 1 + smoothness / 10)));
    }


    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) { 
            startX = gameObject.transform.position.x;
            startY = gameObject.transform.position.y;
        }

        Gizmos.color = Color.red;
        Vector3 previousPoint = gameObject.transform.position;

        float y = 0f;

        for (float t = gameObject.transform.position.x; y >= 0; t += 0.01f)
        {
            y = FnParabolic(t, heightCourbe, forceCourbe) + FnInstability(t, frequencyInstability, forceInstability) + FnJump(t, 45, forceJump, smoothJump);
            Vector3 currentPoint = new Vector3(t, y, 0);

            Gizmos.DrawLine(previousPoint, currentPoint);

            previousPoint = currentPoint;
        }
    }
}
