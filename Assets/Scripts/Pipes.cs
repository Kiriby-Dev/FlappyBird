using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GameManager.RegisterPipe(this); // Registra este Pipe
    }

    private void OnDisable()
    {
        GameManager.UnregisterPipe(this); // Elimina este Pipe del registro
    }
}
