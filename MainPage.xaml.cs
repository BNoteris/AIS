using AIS.Back.DBConfig;
using AIS.Back.Service;
using System.Diagnostics;

namespace AIS

    
{


    public partial class MainPage : ContentPage
    {


        public static readonly UserService _userService = new UserService();


        public MainPage()
        {
            InitializeComponent();
            setNull();

        }

        private void setNull()
        {

            usernameEntry.Text = "";
            passwordEntry.Text = "";
            _userService.Username = "";
            _userService.Password = "";
            _userService.firstName = "";
            _userService.lastName = "";
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

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


                //Debug.WriteLine(username + " " + password);

                DBConfig dB = new DBConfig();
                bool exists = dB.verifyUserExistance(username, password);

                if (exists)
                {
                    string DBuser = dB.createQuerryString(string.Format("SELECT DBuser FROM ais.users WHERE username = '{0}' AND password = '{1}'", username, password), "temp", "temp");
                    string firstName = dB.createQuerryString(string.Format("SELECT firstName FROM ais.users WHERE DBuser = '{0}'", DBuser), "temp", "temp");
                    string lastName = dB.createQuerryString(string.Format("SELECT lastName FROM ais.users WHERE DBuser = '{0}'", DBuser), "temp", "temp");
                    //Debug.WriteLine("User exists");
                    int userTypeID = dB.getUserTypeID(username, password);
                    //Debug.WriteLine("User type ID = " + userTypeID);

                    _userService.Username = DBuser;
                    _userService.Password = password;
                    _userService.firstName = firstName;
                    _userService.lastName = lastName;
                    
                    switch (userTypeID)
                    {
                        case 1:
                            sendAdmin();
                            break;
                        case 2:
                            sendLecturer();
                            break;
                        case 3:
                            sendStudent();
                            break;
                        default:
                            throw new Exception("Error?");
                    }

                }
                else //Debug.WriteLine("Does not exist");
                ErrorLabel.IsVisible = true;

            }

        }

        private async void sendStudent()
        {
            await Shell.Current.Navigation.PushAsync(new Student());
        }
        private async void sendLecturer()
        {
            await Shell.Current.Navigation.PushAsync(new Lecturer());
        }
        private async void sendAdmin()
        {
            await Shell.Current.Navigation.PushAsync(new Administrator());
        }
    }
}
