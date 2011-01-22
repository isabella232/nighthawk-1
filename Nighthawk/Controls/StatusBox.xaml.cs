﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/**
Nighthawk - ARP/NDP spoofing, simple SSL stripping and password sniffing for Windows
Copyright (C) 2010  Klemen Bratec

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
**/
namespace Nighthawk
{
	public partial class StatusBox : UserControl
	{			
		public static DependencyProperty TextProperty = DependencyProperty.Register(
				"Text", typeof(String), typeof(StatusBox));
		
		public static DependencyProperty EnabledProperty = DependencyProperty.Register(
				"Enabled", typeof(bool), typeof(StatusBox));
	
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		
		public bool Enabled
		{
			get { return (bool)GetValue(EnabledProperty); }
			set {
				// set rectangle fill and tooltip when changing state
				if(value) {
					RectangleBox.Fill = (LinearGradientBrush)Resources["BrushEnabled"];
					ToolTip = "Enabled";
				} else {
					RectangleBox.Fill = (LinearGradientBrush)Resources["BrushDisabled"];
					ToolTip = "Disabled";
				}

				SetValue(EnabledProperty, value);
			}
		}
		
		public StatusBox()
		{
			this.InitializeComponent();
		}

		private void StatusBoxControl_Loaded(object sender, RoutedEventArgs e)
		{
			// set rectangle fill and tooltip on first load
			if ((bool)GetValue(EnabledProperty))
			{
				RectangleBox.Fill = (LinearGradientBrush)Resources["BrushEnabled"];
				ToolTip = "Enabled";
			}
		}
	}
}