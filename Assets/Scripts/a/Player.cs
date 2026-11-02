using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Eliminar fruta
        if (collision.gameObject.tag == "Apple")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.linearVelocityY = 0f;

            rb.AddForce(Vector3.up * 10f, ForceMode2D.Impulse);
            //Destroy(collision.gameObject);
        }
    }
}
