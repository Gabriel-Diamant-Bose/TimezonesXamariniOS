using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace timezonesios
{
    public partial class FirstViewController : UIViewController
    {
        protected FirstViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
		
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            details.Text = "";

            // setup our picker
            var pickerModel = new TZones(details);
            picker.Model = pickerModel;

        }
    }

    public class TZones : UIPickerViewModel
    {
        List<string> names = new List<string>();

        private UITextView details;

        public TZones(UITextView details)
        {
            this.details = details;

            NSTimeZone tmpTimeZone;

            //Loop through all known timezones...
            for (int i = 0; i < NSTimeZone.KnownTimeZoneNames.Count; i++)
            {
                // grab the timezone
                tmpTimeZone = NSTimeZone.FromName(NSTimeZone.KnownTimeZoneNames[i]);

                // add it to our list
                names.Add(tmpTimeZone.Name);
            }
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return names.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0)
                return names[(int)row];
            else
                return row.ToString();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            NSTimeZoneNameStyle style = new NSTimeZoneNameStyle();
            NSLocale locale = NSLocale.CurrentLocale;

            // get selected zone, as a string
            string selectedZone = names[(int)pickerView.SelectedRowInComponent(0)];

            // convert selected zone ino timezone
            NSTimeZone selectedTimeZone = NSTimeZone.FromName(selectedZone);

            // dispay timezone localized name & offset from GMT
            details.Text = $"{selectedTimeZone.GetLocalizedName(style, locale)}\nHours From GMT: {selectedTimeZone.GetSecondsFromGMT/60/60}";

        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            if (component == 0)
                return 240f;
            else
                return 40f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }

}
