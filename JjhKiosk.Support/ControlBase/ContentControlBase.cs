using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JjhKiosk.Support.ControlBase
{
    public class ContentControlBase : ContentControl
    {
        private FrameworkElement _view;

        public ContentControlBase()
        {
            InitializeAutoWire();
        }

        internal void InitializeAutoWire()
        {
            _view = this;

            ViewModelLocationProvider.AutoWireViewModelChanged(_view, AutoWireViewModelChanged);
        }

        public virtual void AutoWireViewModelChanged(object view, object dataContext)
        {
            if (view != null && dataContext != null)
            {
                _view = view as FrameworkElement;
                _view.DataContext = dataContext;
            }
        }
    }
}
