using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DictionaryPage : ContentPage
    {
        Button start;
        bool help = false;
        Label name;
        Label score;
        int point = 0;
        Button button;
        Button finish;

        private Dictionary<int, string> buttonLabels = new Dictionary<int, string>
        {
            { 1, "Coбака" },
            { 2, "Кошка" },
            { 3, "Дверь" },
            { 4, "Окно" },
            { 5, "Яблоко" },
            { 6, "Солнце" },
            { 7, "Стул" },
            { 8, "Стол" },
            { 9, "Луна" },
        };

        private List<string> translation = new List<string>
        {
            "Koer",
            "Kass",
            "Uks",
            "Aken",
            "Õun",
            "Päike",
            "Tool",
            "Laud",
            "Kuu"
        };

        public DictionaryPage()
        {
            name = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.FromHex("#253158"),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2
            };

            score = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.FromHex("#253158"),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2,
            };


            start = new Button
            {
                Text = "Начать игру!",
                FontSize = 20,
                TextColor = Color.FromHex("#253158"),
                BorderColor = Color.FromHex("#00a693"),
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.FromHex("#c9f8a9"),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            start.Clicked += Start_Clicked;

            finish = new Button
            {
                Text = "Выйти из игры",
                FontSize = 20,
                TextColor = Color.FromHex("#253158"),
                BorderColor = Color.FromHex("#00a693"),
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.FromHex("#c9f8a9"),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            finish.IsVisible = false;
            finish.Clicked += Finish_ClickedAsync;

            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };

            // Создаем и добавляем кнопки в цикле, используя текст из словаря.
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    int buttonNumber = row * 3 + column + 1;
                    string buttonText = buttonLabels[buttonNumber];

                    button = new Button
                    {
                        Text = buttonText,
                        FontSize = 20,
                        TextColor = Color.FromHex("#253158"),
                        BorderColor = Color.FromHex("#00a693"),
                        CornerRadius = 10,
                        HeightRequest = 100,
                        BorderWidth = 2,
                        BackgroundColor = Color.FromHex("#c9f8a9"),

                    };
                    grid.Children.Add(button, column, row);
                    button.Clicked += Button_ClickedAsync;
                }
            }

            Content = new StackLayout { Children = { name, score, start, grid, finish } };
        }

        private async void Finish_ClickedAsync(object sender, EventArgs e)
        {
            Button sampel = sender as Button;
            await Navigation.PopAsync();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (help == true)
            {
                Button button = (Button)sender;
                string result = await DisplayPromptAsync("Задание:", $"Переведите на эстонский язык слово '{button.Text}': ", "OK", keyboard: Keyboard.Chat);
                if (result == translation[0] & button.Text == buttonLabels[1])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[1] & button.Text == buttonLabels[2])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[2] & button.Text == buttonLabels[3])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[3] & button.Text == buttonLabels[4])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[4] & button.Text == buttonLabels[5])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[5] & button.Text == buttonLabels[6])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[6] & button.Text == buttonLabels[7])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[7] & button.Text == buttonLabels[8])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else if (result == translation[8] & button.Text == buttonLabels[9])
                {
                    button.BackgroundColor = Color.FromHex("#abdd9e");
                    point += 1;
                    score.Text = "Ваш результат " + point.ToString() + ".";
                }
                else
                {
                    button.BackgroundColor = Color.FromHex("#ee6e73");
                    DisplayAlert("Результат:", "Упс! Нужно немножко доучиться.", "ОК");
                }
            }
            else
            {
                DisplayAlert("Внимание!", "Сначала нажмите кнопку 'Начать игру'", "ОК");
            }

        }
        private async void Start_Clicked(object sender, EventArgs e)
        {
            help = true;
            string result = await DisplayPromptAsync("Вопрос", "Напишите свое имя: ", "OK", keyboard: Keyboard.Chat);
            name.Text = "Привет, " + result + "!";
            score.Text = "Ваш результат: " + point + ".";
            score.IsVisible = true;
            start.BackgroundColor = Color.FromHex("#ee6e73");
            start.IsVisible = false;
            if (start.IsVisible == false)
            {
                finish.IsVisible = true;
            }
        }
    }
}