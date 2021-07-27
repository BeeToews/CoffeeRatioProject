using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RatioChange : MonoBehaviour
{
    [SerializeField]
    private InputField beanRatioInput, waterRatioInput;
    [SerializeField]
    private Text coffeeRatioText;

    private int newBeanRatio, newWaterRatio;

    public CanvasChange canvasChangeScript;
    public CalculateCoffee coffeeCalculatorScript;   


    public void OnEnable()
    {
        //Make sure the correct ratio is displayed when the canvas loads
        coffeeRatioText.text = "Ratio: " + coffeeCalculatorScript.beanRatio + "/" + coffeeCalculatorScript.waterRatio + " \nBeans to Water";
    }

    public void ChangeCoffeeRatio()
    {
        //Sets the new ratio if it's been changed
        if(beanRatioInput.text != "")
        {
            newBeanRatio = int.Parse(beanRatioInput.text);            
        }
        else
        {
            newBeanRatio = coffeeCalculatorScript.beanRatio;
        }
        if(waterRatioInput.text != "")
        {
            newWaterRatio = int.Parse(waterRatioInput.text);            
        }
        else
        {
            newWaterRatio = coffeeCalculatorScript.waterRatio;
        }
        //Reduce fractions
        Reduce(newBeanRatio, newWaterRatio);

        //Changes the ratio in the calculator script
        coffeeCalculatorScript.ChangeBeanRatio(newBeanRatio);
        coffeeCalculatorScript.ChangeWaterRatio(newWaterRatio);

        //Changes the ratio display before changing canvas'
        coffeeRatioText.text = "Ratio: " + newBeanRatio.ToString() + "/" + newWaterRatio.ToString() + " \nBeans to Water";
        canvasChangeScript.RatioToCalculatorCanvas();
    }

    //This doesn't need another script if it's only being called here
    //https://dotnetfiddle.net/nBzr0i credit where it's due
    private void Reduce(int numerator, int denominator)
    {
        //assign an integer to the gcd value
        int gcdNum = Gcd(numerator, denominator);
        if (gcdNum != 0)
        {
            numerator = numerator / gcdNum;
            denominator = denominator / gcdNum;
        }

        if (denominator < 0)
        {
            denominator = denominator * -1;
            numerator = numerator * -1;
        }

        Debug.Log(numerator + "/" + denominator);

        newBeanRatio = numerator;
        newWaterRatio = denominator;
    }

    private int Gcd(int numerator, int denominator)
    {
        // assigned x and y to the answer Numerator/Denominator, as well as an  
        // empty integer, this is to make code more simple and easier to read
        int x = Math.Abs(numerator);
        int y = Math.Abs(denominator);
        int m;
        // check if numerator is greater than the denominator, 
        // make m equal to denominator if so
        if (x > y)
            m = y;
        else
            // if not, make m equal to the numerator
            m = x;
        // assign i to equal to m, make sure if i is greater
        // than or equal to 1, then take away from it
        for (int i = m; i >= 1; i--)
        {
            if (x % i == 0 && y % i == 0)
            {
                //return the value of i
                return i;
            }
        }

        return 1;
    }
}
