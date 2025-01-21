using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float stregth = 5f;
    [SerializeField] private Sprite[] sprites;

    private int spriteIndex = 0;
    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * stregth;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction *Time.deltaTime;
    }

    private void AnimateSprite() { 
        spriteIndex++;

        if (spriteIndex >= sprites.Length) { 
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Obstacle") {
            gameManager.GameOver();
        } else if (collision.gameObject.tag == "Scoring") {
            gameManager.IncreaseScore();
        }
    }
}
