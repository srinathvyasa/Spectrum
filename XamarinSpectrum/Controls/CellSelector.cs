using System;
using Xamarin.Forms;

namespace XamarinSpectrum.Controls
{
    public class CellSelector : ViewCell
    {
		public static readonly BindableProperty HighlightProperty =
			BindableProperty.Create("Highlight", typeof(string), typeof(CellSelector), "default");

		public string Highlight
		{
			get { return (string)GetValue(HighlightProperty); }
			set { SetValue(HighlightProperty, value); }
		}
	}
}
