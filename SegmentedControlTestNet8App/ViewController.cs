namespace SegmentedControlTestNet8App;

[Register ("ViewController")]
public class ViewController : UIViewController {
    UISegmentedControl segmentedControl = new();

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Set background color for visibility
        View.BackgroundColor = UIColor.White;

        // Create and configure UISegmentedControl
        segmentedControl.InsertSegment("Option 1", 0, false);
        segmentedControl.InsertSegment("Option 2", 1, false);
        segmentedControl.InsertSegment("Option 3", 2, false);
        segmentedControl.Frame = new CGRect(50, 200, 300, 40); // Set position and size

        // Customize text attributes for normal and selected states
        var normalTextAttributes = new UIStringAttributes
        {
            ForegroundColor = UIColor.Gray,
            Font = UIFont.SystemFontOfSize(16)
        };
        segmentedControl.SetTitleTextAttributes(normalTextAttributes, UIControlState.Normal);

        var selectedTextAttributes = new UIStringAttributes
        {
            ForegroundColor = UIColor.White,
            Font = UIFont.BoldSystemFontOfSize(16)
        };
        segmentedControl.SetTitleTextAttributes(selectedTextAttributes, UIControlState.Selected);

        // Add the UISegmentedControl to the view
        View.AddSubview(segmentedControl);

        // Retrieve and output attributes
        OutputSegmentAttributes(UIControlState.Normal);
        OutputSegmentAttributes(UIControlState.Selected);
    }

    private void OutputSegmentAttributes(UIControlState state)
    {
        var attributes = segmentedControl.GetTitleTextAttributes(state);

        if (attributes != null)
        {
            // Output Font information
            if (attributes.Font != null)
            {
                Console.WriteLine($"[{state}] Font: {attributes.Font.Name}, Size: {attributes.Font.PointSize}");
            }
            else
            {
                Console.WriteLine($"[{state}] Font is null");
            }

            // Output ForegroundColor information
            if (attributes.ForegroundColor != null)
            {
                Console.WriteLine($"[{state}] ForegroundColor: {attributes.ForegroundColor}");
            }
            else
            {
                Console.WriteLine($"[{state}] ForegroundColor is null");
            }
        }
        else
        {
            Console.WriteLine($"[{state}] Attributes are null");
        }
    }
}

