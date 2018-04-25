using System;
using System.Collections.Generic;
using System.Linq;
using SuaveControls.FloatingActionButton;
using Foundation;
using UIKit;
using SuaveControls.FloatingActionButton.iOS.Renderers;

namespace iLibras.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            FloatingActionButtonRenderer.InitRenderer();
            return base.FinishedLaunching(app, options);
        }
    }
}
