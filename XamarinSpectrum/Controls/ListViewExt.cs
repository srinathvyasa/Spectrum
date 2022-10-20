using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinSpectrum.Controls
{
    public class ListViewExt : Xamarin.Forms.ListView
    {

        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create("ItemClickCommand", typeof(ICommand), typeof(ListViewExt), null);

        public static BindableProperty AutoScrollProperty = BindableProperty.Create("AutoScroll", typeof(bool), typeof(ListViewExt), false, BindingMode.TwoWay);


        public static readonly BindableProperty ScrollToItemProperty = BindableProperty.Create("ScrollToItem", typeof(object), typeof(ListViewExt), null, BindingMode.TwoWay,
            propertyChanged: OnScrollToPropertyChanged);

        public static readonly BindableProperty CellResizedProperty = BindableProperty.Create("CellResized", typeof(bool), typeof(ListViewExt), false, propertyChanged: OnCellResized);



        private DataTemplateSelector currentItemSelector;

        public ListViewExt()
        {

            this.ItemTapped += this.OnItemTapped;
            this.ItemAppearing += OnItemAppearing;
            this.ItemSelected += OnItemSelected;
        }

        public ListViewExt(ListViewCachingStrategy strategy) : base(strategy)
        {
            this.ItemTapped += this.OnItemTapped;
            this.ItemAppearing += OnItemAppearing;
            this.ItemSelected += OnItemSelected;
        }

        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }

        public object ScrollToItem
        {
            get { return this.GetValue(ScrollToItemProperty); }
            set { this.SetValue(ScrollToItemProperty, value); }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = null;
            }
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (AutoScroll && e?.SelectedItem != null)
            {
                ScrollTo(e.SelectedItem, ScrollToPosition.MakeVisible, Device.RuntimePlatform == Device.iOS);
            }

            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            if (Device.RuntimePlatform == Device.Android)
                ((ListView)sender).SelectedItem = null; // disables the visual selection state
        }

        protected void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e.Item == null || SelectedItem == null)
                return;

            if (AutoScroll)
            {
                ScrollTo(SelectedItem, ScrollToPosition.MakeVisible, true);
                AutoScroll = false;
            }
             ((ListView)sender).SelectedItem = null;
        }

        public bool AutoScroll
        {
            get
            {
                return (bool)GetValue(AutoScrollProperty);
            }
            set
            {
                SetValue(AutoScrollProperty, value);
            }
        }

        public bool CellResized
        {
            get
            {
                return (bool)GetValue(CellResizedProperty);
            }

            set
            {
                SetValue(CellResizedProperty, value);
            }
        }

        static void OnScrollToPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var position = ScrollToPosition.MakeVisible;

                ((ListViewExt)bindable).ScrollTo(newValue, position, Device.RuntimePlatform == Device.Android);
            }
        }

        private static void OnCellResized(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ListViewExt)?.ViewCellSizeChangedEvent?.Invoke();
            }
        }

        public Action ViewCellSizeChangedEvent { get; set; }


    }
}

