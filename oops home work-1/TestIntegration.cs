using UnityEngine;
using System;
using oompe.lib;

public class TestIntegration : MonoBehaviour
{
    public object Optionally { get; private set; }

    void Start()
    {
        //Test METHOD1
        //Debug.Log("Testing METHOD1:");
         //METHOD1 method1 = new METHOD1();
        //method1.CalculateEnergy();

        //Test METHOD2
        // Debug.Log("Testing METHOD2:");
        // METHOD2 method2 = new METHOD2();
        // method2.CalculateEnergy();

        // Test METHOD3
        Debug.Log("Testing METHOD3:");
       METHOD3 method3 = new METHOD3();
       method3.StartInterpolateArea();    // Call the public method

        //ptionally, you can also test PlotterDemo
      Debug.Log("Testing PlotterDemo:");
        oompe.lib.PlotterDemo plotterDemo = new oompe.lib.PlotterDemo();
        plotterDemo.RunPlotterDemo();  // Call the public method
    }
}
