using UnityEngine;
using Zenject;

public class AnimalFactory : MonoBehaviour
{
    [Inject] private DiContainer _container;
    
    [SerializeField] private GameObject _frogPrefab;
    [SerializeField] private GameObject _snakePrefab;
    
    public Animal CreateFrog(Vector3 position, Transform parent)
    {
        GameObject frogObject = _container.InstantiatePrefab(_frogPrefab, position, Quaternion.identity, parent);
        return frogObject.GetComponent<Animal>();
    }
    
    public Animal CreateSnake(Vector3 position, Transform parent)
    {
        GameObject snakeObject = _container.InstantiatePrefab(_snakePrefab, position, Quaternion.identity, parent);
        return snakeObject.GetComponent<Animal>();
    }
}