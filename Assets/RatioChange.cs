using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioChange : MonoBehaviour
{
    [SerializeField]
    private InputField beanRatioInput, waterRatioInput;
    [SerializeField]
    private Text coffeeRatioText;

    private float newBeanRatio, newWaterRatio;

    public CanvasChange canvasChangeScript;
    public CalculateCoffee coffeeCalculatorScript;

    //https://dotnetfiddle.net/nBzr0i this is some code about simplifying fractions

    public void OnEnable()
    {
        coffeeRatioText.text = "Ratio: " + coffeeCalculatorScript.beanRatio + "/" + coffeeCalculatorScript.waterRatio + " \nBeans to Water";
    }

    public void ChangeCoffeeRatio()
    {
        if(beanRatioInput.text != "")
        {
            newBeanRatio = float.Parse(beanRatioInput.text);
            coffeeCalculatorScript.ChangeBeanRatio(newBeanRatio);
        }
        else
        {
            newBeanRatio = coffeeCalculatorScript.beanRatio;
        }
        if(waterRatioInput.text != "")
        {
            newWaterRatio = float.Parse(waterRatioInput.text);
            coffeeCalculatorScript.ChangeWaterRatio(newWaterRatio);
        }
        else
        {
            newWaterRatio = coffeeCalculatorScript.waterRatio;
        }

        

        coffeeRatioText.text = "Ratio: " + newBeanRatio.ToString("F2") + "/" + newWaterRatio.ToString("F2") + " \nBeans to Water";
        canvasChangeScript.RatioToCalculatorCanvas();
    }
}
