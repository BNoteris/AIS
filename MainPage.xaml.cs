using AIS.Back.DBConfig;
using System.Diagnostics;

namespace AIS
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnRouterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///TestPage");
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {

            var usernameEntry = FindByName("usernameEntry") as Entry;
            string username = usernameEntry.Text;

            var passwordEntry = FindByName("passwordEntry") as Entry;
            string password = passwordEntry.Text;

            if (username == "" && password == "" || username == "" || password == "") ErrorLabel.IsVisible = true;
            else
            {


                Debug.WriteLine(username + " " + password);

                DBConfig dB = new DBConfig();
                bool exists = dB.verifyUserExistance(username, password);

                if (exists)
                {
                    Debug.WriteLine("User exists");
                    int userTypeID = dB.getUserTypeID(username, password);
                    dB.setCredentials(username, password);
                    switch (userTypeID)
                    {
                        case 1:
                            dB.openConnectionExists();
                            sendAdmin();
                            break;
                        case 2:
                            dB.openConnectionExists();
                            sendLecturer();
                            break;
                        case 3:
                            dB.openConnectionExists();
                            sendStudent();
                            break;
                        default:
                            throw new Exception("Error?");
                    }

                }
                else Debug.WriteLine("Does not exist");
                ErrorLabel.IsVisible = true;

            }

        }

        private async void sendStudent()
        {
            await Shell.Current.GoToAsync("");
        }
        private async void sendLecturer()
        {
            await Shell.Current.GoToAsync("");
        }
        private async void sendAdmin()
        {
            await Shell.Current.GoToAsync("");
        }
    }

}
