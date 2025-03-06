using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _preyCounter;
    [SerializeField] private TextMeshProUGUI _predatorCounter;
    
    private int _deadPreyCount = 0;
    private int _deadPredatorCount = 0;
    
    public void IncreaseDeadPreyCount()
    {
        _deadPreyCount++;
        UpdateUI();
    }
    
    public void IncreaseDeadPredatorCount()
    {
        _deadPredatorCount++;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        _preyCounter.text = $"Dead Prey Count: {_deadPreyCount}";
        _predatorCounter.text = $"Dead Predator Count: {_deadPredatorCount}";
    }
}