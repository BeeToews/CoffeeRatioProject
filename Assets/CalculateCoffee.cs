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
    public int beanRatio, waterRatio;

    public void OnEnable()
    {
        //If the ratio hasn't been set, default to 1/16
        if (beanRatio == 0 || waterRatio == 0)
        {
            beanRatio = 1;
            waterRatio = 16;
        }

        coffeeRatioText.text = "Ratio: " + beanRatio.ToString() + "/" + waterRatio.ToString() + "\nBeans to Water";
    }

    public void CalculateCoffeeRatio()
    {
        //Checking calculation inputs (Will take bean mass over water volume)
        //Calculation is beans = water/(beanRatio/waterRatio)
        //or water = beans * (beanRatio/waterRatio)
        if (beanInput.text != "")
        {
            beanMass = float.Parse(beanInput.text);
            waterVolume = beanMass / ((float)beanRatio / waterRatio);

            beanInput.text = "";
            waterInput.text = "";
        }
        else if (waterInput.text != "")
        {
            waterVolume = float.Parse(waterInput.text);
            beanMass = waterVolume * ((float)beanRatio / waterRatio);

            beanInput.text = "";
            waterInput.text = "";
        }

        //bean and water weight will round to 2 decimal points (0.01)
        beanWeightText.text = beanMass.ToString("F2");
        waterVolumeText.text = waterVolume.ToString("F2");
    }

    //Allows other scripts to change the bean and water ratio
    public void ChangeBeanRatio(int newBeanRatio)
    {
        beanRatio = newBeanRatio;
    }
    public void ChangeWaterRatio(int newWaterRatio)
    {
        waterRatio = newWaterRatio;
    }
}
