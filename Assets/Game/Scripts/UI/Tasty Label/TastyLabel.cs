using UnityEngine;
using TMPro;

public class TastyLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _labelText = "Вкусно!";
    [SerializeField] private float _floatSpeed = 0.5f;
    [SerializeField] private float _fadeSpeed = 0.5f;
    
    private float _initialAlpha = 1f;
    private CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        if (_text == null)
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            _canvasGroup = gameObject.GetComponentInChildren<CanvasGroup>();
            _canvasGroup.alpha = _initialAlpha;
        }
        
        _text.text = _labelText;
    }
    
    private void Update()
    {
        transform.localPosition += Vector3.up * _floatSpeed * Time.deltaTime;
        
        _canvasGroup.alpha -= _fadeSpeed * Time.deltaTime;
    }
}