﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new BoxViewPage(), new TimerPage(),new DateTimePage(), new StepperSliderPage() , new Valgusfoor(),new FrameGridPage(), new ImagePage(), new PickerPage(), new TablePage(), new NavigPage(),new Failide_Page(), new Eesti_sonad()};
        
        List<string> teksts = new List<string> { "Ava Entry leht", "Ava BoxView leht", "Ava Timer leht","Ava DateTime leht", "Ava StepperSlider leht", "Ava töö Valgusfoor","Ava Grid leht","Ava leht pildiga","Ava loetelu", "Ava tabel", "Ava map", "Ava failide loetelu","EEsti"};
        StackLayout st;
        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.Red,
                    TextColor = Color.White
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView sv=new ScrollView { Content=st };
            Content = sv;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}