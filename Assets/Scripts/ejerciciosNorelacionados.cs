using UnityEngine;

public class ejerciciosNorelacionados : MonoBehaviour
{
    float posX1 = 2.0f, posY1 = 3.0f;
    float posX2 = 5.0f, posY2 = 1.0f;
    float posX3 = 3.0f, posY3 = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Modulo(posX1, posY1);
        Modulo(posX2, posY2);
        Modulo(posX3, posY3);
        CalcDistancia(posX1, posY1, posX2, posY2);
        CalcDistancia(posX1, posY1, posX3, posY3);
        CalcDistancia(posX2, posY2, posX3, posY3);
    }

    private void Modulo(float x, float y)
    {
        float modulo = Mathf.Sqrt(x * x + y * y);

        Debug.Log("El modulo de " + x + " y " + y + " es igual a " + modulo);
    }

    private void CalcDistancia(float x1, float y1, float x2, float y2)
    {
        Vector2 distancia = new Vector2(x2 - x1, y2 - y1);
        Debug.Log("La distancia entre " + x1 + "/" + y1 + " y " + x2 + "/" + y2 + " es igual a " + distancia);
    }
}
