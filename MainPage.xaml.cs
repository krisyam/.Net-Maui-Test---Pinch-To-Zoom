namespace Pinch_To_Zoom
{
    public partial class MainPage : ContentPage
    {
        double initialDistance;

        public MainPage()
        {
            InitializeComponent();
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            image.GestureRecognizers.Add(pinchGesture);
        }
        private void OnPinchUpdated(object? sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                initialDistance = e.Scale;
            }
            else if (e.Status == GestureStatus.Running)
            {
                double currentDistance = e.Scale;
                double delta = currentDistance / initialDistance;
                image.Scale *= delta;
            }
        }

    }

}
