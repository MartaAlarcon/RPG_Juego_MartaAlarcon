using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public GameObject player;  
    public float pickupDistance = 2.0f;  
    public GameObject objectInPlayer;

    public float floatHeight = 0.5f;  
    public float floatSpeed = 1.0f;  

    public float rotationSpeed = 50f; 

    private bool isCollected = false;
    private float initialY;  

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (!isCollected)
        {
            // Flotaci�n hacia arriba y hacia abajo, pero asegur�ndose que no pase del terreno
            float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

            // Asegurarnos de que la posici�n Y nunca baje de su posici�n inicial
            float newY = initialY + yOffset;

            // Actualizamos la posici�n del objeto, limitando la Y para que no baje demasiado
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Rotaci�n constante sobre s� mismo
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Vector3.Distance(player.transform.position, transform.position) < pickupDistance && !isCollected)
        {
            CollectObject();
        }
    }

    void CollectObject()
    {
        

        Destroy(gameObject);
        objectInPlayer.SetActive(true);    
        isCollected = true;
    }
}
