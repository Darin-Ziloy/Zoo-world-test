using System.Collections;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private AnimalFactory _animalFactory;
    
    [SerializeField] private float _spawnInterval = 1.5f;
    [SerializeField] private Vector3 _spawnAreaSize = new Vector3(10f, 0f, 10f);
    [SerializeField] private Transform _animalParent;

    private void Start()
    {
        StartCoroutine(SpawnAnimalsRoutine());
    }

    private IEnumerator SpawnAnimalsRoutine()
    {
        while (true)
        {
            SpawnRandomAnimal();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnRandomAnimal()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2),
            0,
            Random.Range(-_spawnAreaSize.z / 2, _spawnAreaSize.z / 2)
        );

        bool isPredator = Random.value > 0.5f;
        
        if (isPredator)
        {
            _animalFactory.CreateSnake(spawnPosition, _animalParent);
        }
        else
        {
            _animalFactory.CreateFrog(spawnPosition, _animalParent);
        }
    }
}