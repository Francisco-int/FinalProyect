using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Referencias a los prefabs que queremos spawnear
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;

    // Rango de posiciones para el spawn
    public float spawnRangeX;
    public float spawnRangeZ;

    // Start se llama antes del primer frame update
    void Start()
    {
        // Llamamos a la función para spawnear los objetos al iniciar el juego
        InvokeRepeating("SpawnObjects", 1, 5);
    }

    void SpawnObjects()
    {
        // Generamos una posición aleatoria para el primer objeto
        Vector3 randomPosition1 = new Vector3(
            Random.Range(spawnRangeX, -spawnRangeX),2,
            Random.Range(spawnRangeZ, -spawnRangeZ)
        );

        // Generamos una posición aleatoria para el segundo objeto
        Vector3 randomPosition2 = new Vector3(
            Random.Range(spawnRangeX, -spawnRangeX), 2,
            Random.Range(spawnRangeZ, -spawnRangeZ)
        );

        // Instanciamos los objetos en las posiciones aleatorias
        Instantiate(objectToSpawn1, randomPosition1, Quaternion.identity);
        Instantiate(objectToSpawn2, randomPosition2, Quaternion.identity);
    }
}

