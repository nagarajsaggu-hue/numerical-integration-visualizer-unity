using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;

namespace oompe.lib
{
    public class PlotterDemo : MonoBehaviour
    {
        private FunctionPlotter plotter;

        [Tooltip("Width of the plotting line")]
        [Range(0f, 0.2f)]
        [SerializeField] private float lineWidth = 0.005f;

        [Tooltip("Background color of the plot")]
        [SerializeField] private Color backgroundColor = new Color(1,1,1,1);

        [Tooltip("Color of the function line")]
        [SerializeField] private Color functionColor = new Color(0.156f, 0.4671216f, 1, 1);

        [Tooltip("Color of additional lines")]
        [SerializeField] private Color lineColor = new Color(0.8f,0.8f,0,1);

        [Tooltip("Color of spheres")]
        [SerializeField] private Color sphereColor = new Color(0.8f,0,0,1);

        [Tooltip("Number of pixels per Unity unit")]
        [SerializeField] private int Resolution = 70;

        [Tooltip("Path to the axes' prefab.")]
        [SerializeField] private string pathToAxesPrefab = "oompe.lib/PlotInformation";

        // Start is called before the first frame update
        void Start()
        {
            string functionString = ("f(x) = (3.16985*x)+sin(2*pi*2*x)");
            plotter = new FunctionPlotter(new Function(functionString), 0, 20);
            plotter.LineWidth = lineWidth;
            plotter.FunctionLineColor = functionColor;
            plotter.BackgroundColor = backgroundColor;
            plotter.AdditionalLineColor = lineColor;
            plotter.SphereColor = sphereColor;
            plotter.Resolution = Resolution;
            plotter.AxesPrefabPath = pathToAxesPrefab;

            //plotter.AddLine(new Vector2(-1,3), new Vector2(1,3));
            //plotter.AddPoint(new Vector2(0, 4), 0.02f);

            plotter.Plot(gameObject);
        }

        private void Update()
        {
            //empty
        }
    }
}
