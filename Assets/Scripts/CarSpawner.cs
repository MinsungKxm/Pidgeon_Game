using UnityEngine;

public class CarSpawner : MonoBehaviour {
    public GameObject[] carPrefabs;

    public float spawnInterval = 3.0f;

    void Start() {
        InvokeRepeating(
            "SpawnCar",
            0.0f,
            spawnInterval
        );
    }

    void SpawnCar() {
        int randomIndex = Random.Range(0, carPrefabs.Length);

        GameObject randomCar = carPrefabs[randomIndex];

        Instantiate(
            randomCar,
            transform.position,
            transform.rotation
        );
    }
}