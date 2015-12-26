using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Autofac;
using TranscendenceChat_UAP.Common;
using TranscendenceChat_UAP.ViewModels;

namespace TranscendenceChat_UAP.Locator
{
    public class ViewModels
    {
        public ViewModels()
        {
            if (DesignMode.DesignModeEnabled)
            {
                App.Container = AutoFacConfiguration.Configure();
            }
        }

        public static LoginPageViewModel LoginPageVm => App.Container.Resolve<LoginPageViewModel>();
    }
}
