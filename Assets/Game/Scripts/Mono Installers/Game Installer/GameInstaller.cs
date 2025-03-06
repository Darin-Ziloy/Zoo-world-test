using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AnimalFactory _animalFactory;
    [SerializeField] private UIManager _uiManager;
    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        Container.Bind<AnimalFactory>().FromInstance(_animalFactory).AsSingle();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
    }
}