using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float gravity;
    [SerializeField] private TMP_Text scoreText;

    private float timer;
    private int score;

    List<GameObject> appleList = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            timer = 0f;

            GameObject newApple = Instantiate(applePrefab);

            newApple.transform.position = new Vector3(Random.Range(-3.2f, 3.2f), 5.5f, 0);

            appleList.Add(newApple);
        }

        List<GameObject> appleListToRemove = new List<GameObject>();

        foreach (GameObject apple in appleList)
        {
            apple.transform.position += Vector3.down * gravity * ((score + 1.0f) / 10.0f) * Time.deltaTime;

            float distance = Vector3.Distance(apple.transform.position, playerPosition.position);
            if (distance < 0.5f)
            {
                appleListToRemove.Add(apple);
                score++;
                scoreText.text = "Score: " + score;
            }
            else if (apple.transform.position.y < -5.5f)
            {
                appleListToRemove.Add(apple);
            }
        }

        foreach (GameObject apple in appleListToRemove)
        {
            appleList.Remove(apple);
            Destroy(apple);
        }

        appleListToRemove.Clear();
    }
}
