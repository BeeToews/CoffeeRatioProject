using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateCoffee : MonoBehaviour
{
    [SerializeField]
    private InputField beanInput, waterInput;
    [SerializeField]
    private Text beanWeightText, waterVolumeText, coffeeRatioText;

    private float beanMass, waterVolume;
    public float beanRatio, waterRatio;

    public void OnEnable()
    {
        if (beanRatio == 0 || waterRatio == 0)
        {
            beanRatio = 1;
            waterRatio = 16;
        }

        coffeeRatioText.text = "Ratio: " + beanRatio.ToString("F2") + "/" + waterRatio.ToString("F2") + "\nBeans to Water";
    }

    public void CalculateCoffeeRatio()
    {
        if (beanInput.text != "")
        {
            beanMass = float.Parse(beanInput.text);
            waterVolume = beanMass / (beanRatio / waterRatio);

            beanInput.text = "";
            waterInput.text = "";
        }
        else if (waterInput.text != "")
        {
            waterVolume = float.Parse(waterInput.text);
            beanMass = waterVolume * (beanRatio / waterRatio);

            beanInput.text = "";
            waterInput.text = "";
        }

        beanWeightText.text = beanMass.ToString("F2");
        waterVolumeText.text = waterVolume.ToString("F2");
    }

    public void ChangeBeanRatio(float newBeanRatio)
    {
        beanRatio = newBeanRatio;
    }
    public void ChangeWaterRatio(float newWaterRatio)
    {
        waterRatio = newWaterRatio;
    }
}
