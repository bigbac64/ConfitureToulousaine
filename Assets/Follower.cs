using UnityEngine;

public class Follower : MonoBehaviour
{

    public GameObject followed;
    public bool isFollow = false;
    public float high = 5f;
    public float botView = -8.75f;

    public bool isSlide = false;
    public float moveSpeed = 5f;

    public float maxHeight = 10f;
    public float maxWidth = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followed != null && isFollow)
        {
            transform.position = new Vector3(followed.transform.position.x, followed.transform.position.y + high, transform.position.z);
            transform.rotation = Quaternion.Euler(botView, 0, 0);
        }

        if (isSlide)
        {
            // Récupère les entrées des touches fléchées
            float moveHorizontal = Input.GetAxis("Horizontal"); // Gauche/Droite
            if (transform.position.x <= 0 && moveHorizontal < 0)
            {
                moveHorizontal = 0;
            }
            if (transform.position.x >= maxWidth && moveHorizontal > 0)
            {
                moveHorizontal = 0;
            }
            
            float moveVertical = Input.GetAxis("Vertical"); // Haut/Bas
            if(transform.position.y <= 5 && moveVertical < 0)
            {
                moveVertical = 0;
            }
            if ( moveVertical > 0 && transform.position.y >= maxHeight)
            {
                moveVertical = 0;
            }

            // Calcule la direction de déplacement
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

            // Applique le déplacement à l'objet
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }


}
