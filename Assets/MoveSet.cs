using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public float heightCourbe = 5f;
    public float forceCourbe = 5f;

    public float frequencyInstability = 0f;
    public float forceInstability = 0f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    /// <summary>
    /// Calcule la position sur une trajectoire parabolique selon le temps donné.
    /// </summary>
    /// <param name="time">Position temporelle (normalisée entre 0 et 1).</param>
    /// <param name="maxHeight">Hauteur maximale de la parabole.</param>
    /// <param name="force">Puissance d'éjection sur l'axe X.</param>
    /// <param name="moveX"></param>
    /// <returns>La position y (float) sur la parabole.</returns>
    public float FnParabolic(float time, float maxHeight, float force)
    {
        return -1 / force * Mathf.Pow(time - Mathf.Sqrt(maxHeight * force) - gameObject.transform.position.x, 2) + maxHeight + gameObject.transform.position.y;
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
        return strength / (1+ Mathf.Exp(- smoothness * (x - pos + 1 + smoothness / 10)));
    }

    
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Vector3 previousPoint = Vector3.zero;

        float y = 0f;
        
        for (float t = gameObject.transform.position.x; y >= 0; t += 0.01f)
        {
            y = FnParabolic(t, heightCourbe, forceCourbe);
            Vector3 currentPoint = new Vector3(t, y, 0);

            if (t > 0)
            {
                Gizmos.DrawLine(previousPoint, currentPoint);
            }

            previousPoint = currentPoint;
        }
    }
}
