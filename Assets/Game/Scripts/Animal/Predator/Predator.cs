using UnityEngine;

public abstract class Predator : Animal
{
    [SerializeField] private GameObject _tastyLabelPrefab;
    [SerializeField] private float _labelDuration = 2f;
    
    protected override void Start()
    {
        base.Start();
        Type = AnimalType.Predator;
    }
    
    protected override void HandleCollision(Animal otherAnimal)
    {
        if (otherAnimal.Type == AnimalType.Prey)
        {
            otherAnimal.Die();
            ShowTastyLabel();
        }
        else if (otherAnimal.Type == AnimalType.Predator)
        {
            bool thisAnimalSurvives = Random.value > 0.5f;

            if(otherAnimal.GetLifeTime() >= GetLifeTime())
            {
                thisAnimalSurvives = true;
            }
            else
            {
                thisAnimalSurvives = false;
            }
            
            if (thisAnimalSurvives)
            {
                otherAnimal.Die();
                ShowTastyLabel();
            }
            else
            {
                Die();
            }
        }
    }
    
    private void ShowTastyLabel()
    {
        Transform labelObject = Instantiate(_tastyLabelPrefab, transform).transform;
        labelObject.localPosition = new Vector3(0, 1, 0);

        labelObject.LookAt(labelObject.position + Camera.main.transform.rotation * Vector3.forward,Camera.main.transform.rotation * Vector3.up);
        
        labelObject.rotation = Quaternion.Euler(labelObject.rotation.eulerAngles.x, labelObject.rotation.eulerAngles.y, labelObject.rotation.eulerAngles.z);
        
        Destroy(labelObject.gameObject, _labelDuration);
    }
}
