using AIS.Back.Custom;
using AIS.Back.DBConfig;
using System.Data;

namespace AIS;

public partial class Student : ContentPage
{
	public Student()
	{
		InitializeComponent();
        currentlyLoggedIn();
	}

    private void currentlyLoggedIn()
    {

        string logged = "Prisijunges kaip " + MainPage._userService.firstName + " " + MainPage._userService.lastName;
        loggedIn.Text = logged;
    }

    private async void onLogoutClicked(object sender, EventArgs e)
    {

        await Shell.Current.Navigation.PushAsync(new MainPage());
    }

    private void OnVGClicked(object sender, EventArgs e)
    {

        interfaceViewGrades.IsVisible = true;
        Back.IsVisible = true;
        ViewGrade.IsEnabled = false;

        listLectures();
    }

    private void OnBackClicked(object sender, EventArgs e)
    {

        interfaceViewGrades.IsVisible = false;
        Back.IsVisible = false;
        ViewGrade.IsEnabled = true;

        viewGradePicker1.ItemsSource = null;
        viewGradeList1.ItemsSource = null;
    }

    private async void listLectures(){

        DBConfig dB = new DBConfig();

        int groupID = dB.createQuerryInt(string.Format("SELECT groupID FROM ais.student WHERE firstName = '{0}' AND lastName = '{1}'", MainPage._userService.firstName, MainPage._userService.lastName),
            MainPage._userService.Username, MainPage._userService.Password);
        string query = string.Format("SELECT lectureID FROM ais.lecturergroups WHERE groupID = '{0}'", groupID);
        var lecturesListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(lecturesListUnusable, new List<string> { "lectureID" });

        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)
        {

            string value = row["lectureID"].ToString();
            string displayText = dB.createQuerryString(string.Format("SELECT lectureName FROM ais.lectures WHERE lectureID = '{0}'", Int32.Parse(value)), MainPage._userService.Username, MainPage._userService.Password);

            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        viewGradePicker1.ItemsSource = pickerItems;
    }

    private async void OnViewGradePicker1Index(object sender, EventArgs e)
    {

        DBConfig dB = new DBConfig();

        CustomPickerItem selectedLecture = (CustomPickerItem)viewGradePicker1.SelectedItem;

        if(selectedLecture != null ) {

        int lectureID = Int32.Parse(selectedLecture.Value);
        int studentID = dB.createQuerryInt(string.Format("SELECT studentID FROM ais.student WHERE firstName = '{0}' AND lastName = '{1}'", MainPage._userService.firstName, MainPage._userService.lastName),
            MainPage._userService.Username, MainPage._userService.Password);
        int lecturerID = dB.createQuerryInt(string.Format("SELECT lecturerID from ais.grades WHERE studentID = '{0}' AND lectureID = '{1}'", studentID.ToString(), selectedLecture.Value),
            MainPage._userService.Username, MainPage._userService.Password);
        string query = string.Format("SELECT grade_typeID, grade FROM ais.grades WHERE studentID = '{0}' AND lectureID = '{1}'", studentID, lectureID);
        string lecturersName = dB.createQuerryString(string.Format("SELECT firstName from ais.lecturer WHERE lecturerID = '{0}'", lecturerID), MainPage._userService.Username, MainPage._userService.Password); ;
        string lecturersSurname = dB.createQuerryString(string.Format("SELECT lastName from ais.lecturer WHERE lecturerID = '{0}'", lecturerID), MainPage._userService.Username, MainPage._userService.Password);
        var gradesListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(gradesListUnusable, new List<string> { "grade_typeID", "grade" });

        List<CustomListView> listerItems = new List<CustomListView>();

        foreach (DataRow row in dT.Rows)
        {

            string grade_typeID = row["grade_typeID"].ToString();
            string grade = row["grade"].ToString();
            string gradeType = dB.getGradeTypeString(Int32.Parse(grade_typeID), MainPage._userService.Username, MainPage._userService.Password);

            string title = lecturersName + " " + lecturersSurname + " - " + gradeType + " " + grade;
            

            listerItems.Add(new CustomListView(title));
        };

        viewGradeList1.ItemsSource = listerItems;

        }
    }
}