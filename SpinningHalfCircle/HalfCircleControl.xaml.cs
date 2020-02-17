using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpinningHalfCircle
{
    /// <summary>
    /// Interaction logic for PartCircleControl.xaml
    /// </summary>
    public partial class HalfCircleControl : UserControl
    {
        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public static readonly DependencyProperty BrushProperty =
           DependencyProperty.Register("Brush", typeof(Brush), typeof(HalfCircleControl), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
           DependencyProperty.Register("Thickness", typeof(double), typeof(HalfCircleControl), new PropertyMetadata(40d));

        public KeyTime Duration
        {
            get { return (KeyTime)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(KeyTime), typeof(HalfCircleControl), new PropertyMetadata(KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))));

        public TimeSpan Delay
        {
            get { return (TimeSpan)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(TimeSpan), typeof(HalfCircleControl), new PropertyMetadata(new TimeSpan(0)));

        public double Speed
        {
            get { return (double)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(double), typeof(HalfCircleControl), new PropertyMetadata(1d, (o,e)=>
            {
                var ctrl = o as HalfCircleControl;
                ctrl._rotateStoryboard.Begin(); // otherweise binding doest not work.
            }));

        private Storyboard _rotateStoryboard;

        public HalfCircleControl()
        {
            InitializeComponent();
            _rotateStoryboard = TryFindResource("RotateStoryboard") as Storyboard;
        }
    }
}
