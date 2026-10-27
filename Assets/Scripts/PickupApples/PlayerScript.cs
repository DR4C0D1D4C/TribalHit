using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < 3.5)
            transform.position += Vector3.right * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && transform.position.x > -3.5)
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
