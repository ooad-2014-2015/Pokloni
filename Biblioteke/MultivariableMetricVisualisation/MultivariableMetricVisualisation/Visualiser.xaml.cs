using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultivariableMetricVisualisation
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Visualizer : UserControl {
     
        private int numberOfSides;
        private List<double> acutalAttributes;

        public List<double> ActualAtrributes {
            get { return acutalAttributes; }
            set {
                if (value.Count != NumberOfAttributes) { //make sure actual atributes represent fraction/precentage of ideal attribute
                    throw new Exception("Number of attributes missmatch");
                }
                if (value.Any(item => item > 1.0 || item <= 0.0)) {
                    throw new Exception("Bad vals");
                }
                acutalAttributes = value;
                for (int i = 0; i < acutalAttributes.Count; i++) {
                    acutalAttributes[i] *= 100;
                }

            }
        }

        public int NumberOfAttributes {
            get { return numberOfSides; }
            set {
                if (value < 3) {
                    throw (new Exception("You need to have at least 3 attributes"));
                }
                numberOfSides = value;
            }
        }
        public Visualizer(int numberOfDesiredAttributes) {
            InitializeComponent();
            NumberOfAttributes = numberOfDesiredAttributes;
            acutalAttributes = new List<double>(NumberOfAttributes);
        }

        public Visualizer() {
        }
        public void DrawMainPolygon() {
            mainPolygon.Points = CalculateVertices(NumberOfAttributes, 100, 0, new Point(mainPolygon.Width * 0.5, mainPolygon.Height * 0.5));

            //drawing main polygon (which represents ideal attributes)
            //it's center is in center of controll, and radius equal to 1/3 of control height
        }

        public void DrawActualAttributes() {
            if (ActualAtrributes.Count != NumberOfAttributes) {
                throw new Exception("Attribute count missmatch");
            }
            actualAttributesPolygon.Points = CalculateVertices(NumberOfAttributes, ActualAtrributes, 0, new Point(mainPolygon.Width * 0.5, mainPolygon.Height * 0.5));
        }

        public void ClearAttributes() {
            actualAttributesPolygon.Points = new PointCollection();
        }

        internal PointCollection CalculateVertices(int sides, List<double> radius, int startingAngle, Point center) {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            int j = 0;
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                Point tempPoint = DegreesToXY(angle, radius[j++], center);
                points.Add(tempPoint);
                angle += step;
            }
            return new PointCollection(points.ToArray());
        }

        internal PointCollection CalculateVertices(int sides, double radius, int startingAngle, Point center) {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }
            return new PointCollection(points.ToArray());
        }

        internal Point DegreesToXY(double degrees, double radius, Point origin) {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
        }
    }
}
