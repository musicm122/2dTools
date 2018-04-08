using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class FloatIncrementButton : MonoBehaviour
{

    [SerializeField]
    InputField DisplayValue;

    [SerializeField]
    Button Increment;

    [SerializeField]
    Button Decrement;

    [SerializeField]
    public float Value;

    [SerializeField]
    public float IncrementAmount = 1.0f;

    public Action<float> OnUpdate;

    void AddListeners()
    {
        Increment.onClick.AddListener(IncrementValue);
        Decrement.onClick.AddListener(DecrementValue);
    }

    void RemoveListeners()
    {
        Increment.onClick.RemoveListener(IncrementValue);
        Decrement.onClick.RemoveListener(DecrementValue);
    }

    void IncrementValue()
    {
        Value += IncrementAmount;
        UpdateValues();
    }

    void DecrementValue()
    {
        Value -= IncrementAmount;
        UpdateValues();
    }

    void UpdateValues()
    {
        this.DisplayValue.text = Value.ToString();
        OnUpdate(Value);
    }

    // Use this for initialization
    void Start()
    {
        AddListeners();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValues();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }
}
