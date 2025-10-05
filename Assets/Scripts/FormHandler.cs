using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Collections;
using Unity.VisualScripting;


public class FormHandler : MonoBehaviour
{
    public List<TMP_InputField> inputFields;
    public Camera MainCamera;
    public GameObject Asteroid;
    public Canvas Canvas;
    public TMP_Text TMP_TextDensity;
    public TMP_Text TMP_TextError;

    private float length = 0f, width = 0f, height = 0f, mass = 0f, massdecimal = 0f, masspower = 0f, density = 0f, volume = 0f;
    public float speed = 0f;
    private const float MaxMass = 9.38e20f;

    private void Density()
    {
        if (this.length != 0f && this.width != 0f && this.height != 0f && this.mass != 0f)
        {
            volume = (4 * (float)Math.PI * this.length * this.width * this.height) / 3;
            this.density = this.mass / this.volume;
        }
    }

    private void Start()
    {
        foreach (TMP_InputField field in inputFields)
            field.onValueChanged.AddListener(value => OnFieldChanged(field, value));
    }

    private void OnFieldChanged(TMP_InputField field, string value)
    {
        if (field.name == "InputL")
        {
            if (field.text != "")
                length = float.Parse(field.text);
            else length = 0f;
        }
        else if (field.name == "InputW")
        {
            if (field.text != "")
                width = float.Parse(field.text);
            else width = 0f;
        }
        else if (field.name == "InputH")
        {
            if (field.text != "")
                height = float.Parse(field.text);
            else height = 0f;
        }
        else if (field.name == "InputM")
        {
            if (field.text != "")
                massdecimal = float.Parse(field.text);
            else massdecimal = 0f;
        }
        else if (field.name == "InputS")
        {
            if (field.text != "")
                speed = float.Parse(field.text);
            else speed = 0f;
        }
        else if (field.name == "InputMP")
        {
            if (field.text != "")
                masspower = float.Parse(field.text);
            else masspower = 0f;
        }
        if (this.massdecimal != 0f && this.masspower != 0f)
        {
            mass = (float)(this.massdecimal * Math.Pow(10, this.masspower));
            Debug.Log($"Mass changed: {mass}");
        }
        
        Density();
        if (density != 0f)
        {
            TMP_TextDensity.text = $"Density: {density}";
        }
        Debug.Log($"{field.name} changed: {value}");
    }

    private void ShowError(string message)
    {
        if (TMP_TextError != null)
        {
            TMP_TextError.text = message;
            TMP_TextError.gameObject.SetActive(true);
        }
    }

    private void HideError()
    {
        if (TMP_TextError != null)
            TMP_TextError.gameObject.SetActive(false);
    }

    public void StartSimulation()
    {
        if (length <= 0f || width <= 0f || height <= 0f)
        {
            ShowError("Error: dimensions must be greater than 0!");
            return;
        }

        if (mass <= 0f)
        {
            ShowError("Error: mass must be greater than 0!");
            return;
        }

        if (mass > MaxMass)
        {
            ShowError($"Error: mass cannot exceed {MaxMass:e2} kg!");
            return;
        }

        if (speed <= 0f)
        {
            ShowError("Error: speed must be greater than 0!");
            return;
        }

        Cursor.visible = false;
        HideError();
        MainCamera.GetComponent<MoveCamera>().MoveBack();
        Asteroid.GetComponent<AsteroidVision>().TogglePoint();
        Canvas.GetComponent<CanvasToggler>().ToggleCanvas();

        Debug.Log($"{length}, {width}, {height}, {massdecimal}, {masspower}, {speed}");
    }
}
