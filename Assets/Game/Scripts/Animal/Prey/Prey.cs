using UnityEngine;

public abstract class Prey : Animal
{
    protected override void Start()
    {
        base.Start();
        Type = AnimalType.Prey;
    }
    
    protected override void HandleCollision(Animal otherAnimal)
    {
        if (otherAnimal.Type == AnimalType.Predator)
        {
            Die();
        }
        else if (otherAnimal.Type == AnimalType.Prey)
        {
            ChooseRandomDirection();
        }
    }
}