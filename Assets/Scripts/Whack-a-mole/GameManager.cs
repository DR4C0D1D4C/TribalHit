using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO

    // Prefab del enemigo que vamos a generar
    [SerializeField] GameObject enemyPrefab;
    GameObject createdEnemy;

    [SerializeField] private int speed = 3;
    // ARRAY:
    // Las posiciones posibles son conocidas y no cambiarán
    // durante la ejecución del juego.
    [SerializeField] private Transform[] spawnPoints;
    // Número de enemigos que queremos generar en cada ronda
    [SerializeField] private int numberOfEnemies = 8;
    // LIST:
    // El número de enemigos vivos sí cambiará durante la partida.
    private List<GameObject> activeEnemies = new List<GameObject>();
    //Score

    private int score = 0;
    void Start()
    {
        //TODO: Llamamos a la generación de enemigos
        GenerarEnemigos();

    }

    void Update()
    {
        //TODO:  Reiniciamos la ronda pulsando R
        EnemyMove(activeEnemies);
    }

    //Generar oleada
    private void GenerarEnemigos()
    {
        //TODO: 
        // Evitamos intentar generar más enemigos
        // que posiciones disponibles.
        numberOfEnemies = Random.Range(1, spawnPoints.Length);
        // ARRAY auxiliar:
        // Nos permite saber qué posiciones ya hemos utilizado.
        //
        // false = libre
        // true = ocupada
        bool[] usedSpawnPoint = new bool[spawnPoints.Length];
        // FOR:
        // Sabemos cuántos enemigos queremos generar.
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Elegimos una posición aleatoria.
            int position = Random.Range(0, spawnPoints.Length);
            // WHILE:
            // Mientras esa posición ya esté ocupada,
            // buscamos otra.
            while (usedSpawnPoint[position])
            {
                position = Random.Range(0, spawnPoints.Length);
            }
            // Marcamos esa posición como utilizada.
            usedSpawnPoint[position] = true;
            // Creamos el enemigo.
            createdEnemy = Instantiate(enemyPrefab, spawnPoints[position].position, Quaternion.identity);
            // Guardamos el enemigo en nuestra lista
            // de enemigos actualmente vivos.
            activeEnemies.Add(createdEnemy);
            // Le damos al enemigo una referencia
            // al GameManager.
            EnemyScript eScript = createdEnemy.GetComponent<EnemyScript>();
            eScript.Initialize(this);
        }
    }


    //Si se destruye un enemigo, incrementamos el score

    public void EnemigoDestruido(GameObject enemy)
    {
        //TODO: 
        // Eliminamos la referencia de la lista.

        activeEnemies.Remove(enemy);

        score += 100;

        Debug.Log("Enemigo destruido, score = " + score);
        // Cuando la lista esté vacía,
        // hemos terminado la ronda.
        if (activeEnemies.Count == 0)
        {
            Debug.Log("Fin de la ronda, score = " + score);
        }
    }


    //Reiniciar la ronda

    private void ReiniciarEnemigos()
    {
        //TODO: 
        // Primero eliminamos cualquier enemigo
        // que todavía esté vivo.
        EliminarEnemigos();
        // Generamos una nueva oleada.
        GenerarEnemigos();
    }

    // Elminar a todos los enemigos
    private void EliminarEnemigos()
    {
        //TODO: 
        // FOREACH:
        // Queremos hacer la misma operación
        // con todos los enemigos de la lista.
        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }
        // Dejamos vacía la lista.
        activeEnemies.Clear();
    }

    private void EnemyMove(List<GameObject> enemies)
    {
        foreach (var enemy in enemies)
        {
            int modifier = 1;

            if (Random.Range(0, 2) == 0)
            {
                if (enemy.transform.position.x >= 10) modifier = -5;

                enemy.transform.position += new Vector3(speed * modifier * Time.deltaTime, 0, 0);
            }
            else
            {
                if (enemy.transform.position.x <= -11) modifier = -5;

                enemy.transform.position += new Vector3(-speed * modifier * Time.deltaTime, 0, 0);
            }
        }
    }
}