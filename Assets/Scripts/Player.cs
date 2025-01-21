using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float stregth = 5f;
    [SerializeField] private Sprite[] sprites;

    private int spriteIndex;
    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
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

        if (spriteIndex > sprites.Length) { 
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
