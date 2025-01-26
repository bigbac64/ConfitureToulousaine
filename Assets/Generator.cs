using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public string name;
    public Inventory inventory;
    public bool canSelectable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && prefabToSpawn != null && canSelectable)
        {
            if(inventory.inventory[name] > 0)
            {
                SpawnObjectAtMousePosition();
            }
        }
    }

    public void SpawnObjectAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("droppable"))
        {
            inventory.SetObject(name, -1);
            Vector3 spawnPosition = hit.point;
            spawnPosition.z = 0; // Fixe la coordonnée Z à 0
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
