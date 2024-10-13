using JjhKiosk.Support.ControlBase;
using JjhKiosk.Support.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

namespace JjhKiosk.Support.Controls
{
    /// <summary>
    /// ControlSlider.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ControlSlider : UserControl, INotifyPropertyChanged
    {
        private ContentControl _backContent;
        private ContentControl _frontContent;

        private Storyboard _slideLeftToRight;
        private Storyboard _slideRightToLeft;
        private Storyboard _slideTopToBottom;
        private Storyboard _slideBottomToTop;

        private Duration? _duration;
        private ContentControl _lastContent;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ContentControlBase View
        {
            get { return (ContentControlBase)GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        public SlideType SlideType
        {
            get { return (SlideType)GetValue(SlideTypeProperty); }
            set { SetValue(SlideTypeProperty, value); }
        }

        public ControlSlider()
        {
            InitializeComponent();

            _slideLeftToRight = (Storyboard)Resources["SlideLeftToRight"];
            _slideRightToLeft = (Storyboard)Resources["SlideRightToLeft"];
            _slideTopToBottom = (Storyboard)Resources["SlideTopToBottom"];
            _slideBottomToTop = (Storyboard)Resources["SlideBottomToTop"];

            _backContent = content2;
            _frontContent = content1;
        }

        public Duration? Duration
        {
            get
            {
                if (_duration == null)
                {
                    _duration = new Duration(new TimeSpan(0, 0, 1));
                }
                return _duration;
            }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged();
                }

            }
        }

        public void SetAnimationSpeed(int millisecons)
        {
            Duration = new Duration(new TimeSpan(0, 0, 0, 0, millisecons));
        }

        public void InitContent(object newContent)
        {
            _frontContent.Content = null;
            _backContent.Content = newContent;
        }

        public void Slide(object newContent, SlideType slideType)
        {
            if (_backContent == null)
            {
                InitContent(newContent);
                return;
            }

            _frontContent = _backContent == content2 ? content1 : content2;

            _frontContent.Visibility = Visibility.Visible;
            _frontContent.Content = newContent;
            _lastContent = _frontContent;
            switch (slideType)
            {
                case SlideType.LeftToRight:
                    BeginSlideStoryboard(_slideLeftToRight);
                    break;
                case SlideType.RightToLeft:
                    BeginSlideStoryboard(_slideRightToLeft);
                    break;
                case SlideType.TopToBottom:
                    BeginSlideStoryboard(_slideTopToBottom);
                    break;
                case SlideType.BottomToTop:
                    BeginSlideStoryboard(_slideBottomToTop);
                    break;
            }
        }

        public void BeginSlideStoryboard(Storyboard storyboard)
        {
            Storyboard.SetTarget(storyboard.Children[0], _frontContent);
            Storyboard.SetTarget(storyboard.Children[1], _backContent);
            storyboard.Begin();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Slide_Completed(object sender, EventArgs e)
        {
            if (_lastContent != _backContent)
            {
                _backContent.Visibility = Visibility.Collapsed;
                _backContent = _frontContent;
            }

        }





        // Using a DependencyProperty as the backing store for SliderType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SlideTypeProperty =
            DependencyProperty.Register("SlideType", typeof(SlideType), typeof(ControlSlider), new UIPropertyMetadata(SlideType.LeftToRight));




        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(ContentControlBase), typeof(ControlSlider), new UIPropertyMetadata(null, ViewChanged));

        private static void ViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ControlSlider? slider = (ControlSlider?)d;

            if (slider == null) return;

            if (e.NewValue != e.OldValue)
            {
                slider.Slide(e.NewValue, slider.SlideType);
            }
        }
    }
}
