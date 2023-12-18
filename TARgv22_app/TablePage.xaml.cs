using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView table;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection picture;
        Button callButton, smsButton, mailButton;
        EntryCell tel, email, insertText, name;

        public TablePage()
        {
            tel = new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta telefoni number",
                Keyboard = Keyboard.Telephone
            };
            email = new EntryCell
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email
            };
            insertText = new EntryCell
            {
                Label = "Sms:",
                Placeholder = "Kirjuta teksti",
                Keyboard = Keyboard.Default
            };
            name = new EntryCell
            {
                Label = "Nimi:",
                Placeholder = "Sisesta nimi",
                Keyboard = Keyboard.Default
            };


            switchCell = new SwitchCell
            {
                Text = "Näita rohkem"
            };
            switchCell.OnChanged += SwitchCell_OnChanged;

            callButton = new Button
            {
                Text = "Helista",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            callButton.Clicked += CallButton_Clicked;
            smsButton = new Button
            {
                Text = "Saada sms",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            smsButton.Clicked += SmsButton_Clicked;
            mailButton = new Button
            {
                Text = "Saada email",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            mailButton.Clicked += MailButton_Clicked;

            imageCell = new ImageCell
            {
                ImageSource = ImageSource.FromFile("bees.png"),
                Text = "Bees",
                Detail = "Info"
            };
            picture = new TableSection();

            table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Sisesta andmed")
                {
                    new TableSection("Info:")
                    {
                        new EntryCell
                        {
                            Label = "Nimi:",
                            Placeholder = "Sisesta nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontakti andmed:")
                    {
                        new EntryCell
                        {
                            Label = "Telefon:",
                            Placeholder = "Sisesta telefoni number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email:",
                            Placeholder = "Sisesta email",
                            Keyboard = Keyboard.Email
                        },
                        switchCell
                    },
                    picture,


                }
            };
            Content = table;
        }

        private void MailButton_Clicked(object sender, System.EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel.Text, "Tere!", insertText.Text);
            }
        }

        private void SmsButton_Clicked(object sender, System.EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel.Text, "Tere, " + name.Text + "!\n" + insertText.Text);
            }
        }

        private void CallButton_Clicked(object sender, System.EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel.Text);
            }
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                picture.Title = "Picture";
                picture.Add(imageCell);
                switchCell.Text = "Peida";
                picture.Add(tel);
                picture.Add(email);
                picture.Add(insertText);
                picture.Add(name);
            }
            else
            {
                picture.Title = "";
                picture.Remove(imageCell);
                switchCell.Text = "Näita";
                picture.Remove(tel);
                picture.Remove(email);
                picture.Remove(insertText);
                picture.Remove(name);
            }
        }
    }
}