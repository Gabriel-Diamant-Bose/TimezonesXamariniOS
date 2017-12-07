// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace timezonesios
{
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView details { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView picker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (details != null) {
                details.Dispose ();
                details = null;
            }

            if (picker != null) {
                picker.Dispose ();
                picker = null;
            }
        }
    }
}