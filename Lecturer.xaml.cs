using AIS.Back.Custom;
using AIS.Back.DBConfig;
using System.Data;
using System.Diagnostics;

namespace AIS;

public partial class Lecturer : ContentPage
{
	public Lecturer()
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

    private void OnAGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        EditGrade.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddGrade.IsVisible = true;
        AddGrade.IsEnabled = false;

        groupListNew();
        gradeTypes();
        availableGrades();

        //Debug.WriteLine("Testing userSerive visibility, username is " + MainPage._userService.Username + " password is: " + MainPage._userService.Password);

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceAddGrade.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnEGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        AddGrade.IsVisible = false;
        Back.IsVisible = true;
        EditGrade.IsEnabled = false;
        interfaceEditGrade.IsVisible = true;

        groupListNew();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        //interfaceEditGrade.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        //Editing visibility

        AddGrade.IsVisible = true;
        EditGrade.IsVisible = true;
        Back.IsVisible = false;

        //Editing functionality

        AddGrade.IsEnabled = true;
        EditGrade.IsEnabled = true;


        //Interfaces visibility

        interfaceAddGrade.IsVisible = false;
        interfaceEditGrade.IsVisible = false;



        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Center;

        //Reset pickers

        resetPicker();
    }

    private async void OnAddGradeBtnClicked(object sender, EventArgs e)
    {

        CustomPickerItem selectedGroup = (CustomPickerItem)addGradePicker1.SelectedItem;
        CustomPickerItem selectedLecture = (CustomPickerItem)addGradePicker2.SelectedItem;
        CustomPickerItem selectedStudent = (CustomPickerItem)addGradePicker3.SelectedItem;
        CustomPickerItem selectedGradeType = (CustomPickerItem)addGradePicker4.SelectedItem;
        CustomPickerItem selectedGrade = (CustomPickerItem)addGradePicker5.SelectedItem;

        if (selectedGroup != null && selectedLecture != null && selectedStudent != null && selectedGradeType != null && selectedGrade != null)
        {

            int lectureID = Int32.Parse(selectedLecture.Value);
            int studentID = Int32.Parse(selectedStudent.Value);
            int gradeTypeID = Int32.Parse(selectedGradeType.Value);

            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite siam studentui ivesti si pazymi?", "Taip", "Ne");
            if (answer)
            {

                DBConfig dB = new DBConfig();
                int lecturerID = dB.createQuerryInt(string.Format("SELECT lecturerID FROM ais.lecturer WHERE firstName = '{0}' AND lastName = '{1}'", MainPage._userService.firstName, MainPage._userService.lastName),
                    MainPage._userService.Username, MainPage._userService.Password);

                dB.createQuerry(string.Format("INSERT INTO ais.grades (studentID, lecturerID, lectureID, grade_typeID, grade) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    new object[5] { studentID, lecturerID, lectureID, gradeTypeID, selectedGrade.Value }),
                    MainPage._userService.Username, MainPage._userService.Password);

                await DisplayAlert("Patvirtinimas", "Naujas pazymys sekmingai sukurtas", "Gerai");

                addGradePicker4.ItemsSource = null;
                addGradePicker5.ItemsSource = null;
                gradeTypes();
                availableGrades();
            }
        }
        else await DisplayAlert("Klaida", "Patikrinkite ar pasirinkote visus parametrus", "Gerai");

    }

    private async void OnEditGradeBtnClicked(object sender, EventArgs e)
    {

        int resultInt;
        string result;

        CustomPickerItem selectedGroup = (CustomPickerItem)editGradePicker1.SelectedItem;
        CustomPickerItem selectedLecture = (CustomPickerItem)editGradePicker2.SelectedItem;
        CustomPickerItem selectedStudent = (CustomPickerItem)editGradePicker3.SelectedItem;
        CustomPickerItem selectedGrade = (CustomPickerItem)editGradePicker4.SelectedItem;


        //gradeID	studentID	lecturerID	lectureID	grade_typeID	grade	

        if (selectedGroup != null && selectedLecture != null && selectedStudent != null && selectedGrade != null)
        {

            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite redaguoti sio studento pazymi?", "Taip", "Ne");

            int id = Int32.Parse(selectedGrade.Value);
            DBConfig dB = new DBConfig();

            if (answer)
            {

                do
                {

                    result = await DisplayPromptAsync("Pazymio keitimas", "Iveskite nauja pazymi", accept: "Patvirtinti", cancel: "Atsaukti");
                    //resultInt = Int32.Parse(result);
                    bool checkIfInt = int.TryParse(result, out resultInt); 

                    if (resultInt > 0 && resultInt <= 10 && checkIfInt)
                    {

                        dB.createQuerry(string.Format("UPDATE ais.grades SET grade = '{0}' WHERE gradeID = '{1}'", resultInt, id), MainPage._userService.Username, MainPage._userService.Password);

                        editGradePicker4.ItemsSource = null;
                        OnEGPicker3Index(sender, e);

                        await DisplayAlert("Patvirtinimas", "Pazymys atnaujintas", "Gerai");
                    }
                    else

                    {
                        await DisplayAlert("Pranesimas", "Skaicius neivestas, arba neegzistuoja normoje nuo 1 iki 10", "Gerai");
                    }
                } while (resultInt <= 0 && resultInt > 10);

            }
            else;
        }
        else await DisplayAlert("Klaida", "Patikrinkite ar pasirinkote visus parametrus", "Gerai");
    }

    private void resetPicker()
    {
        addGradePicker1.ItemsSource = null;
        addGradePicker2.ItemsSource = null;
        addGradePicker3.ItemsSource = null;
        addGradePicker4.ItemsSource = null;
        addGradePicker5.ItemsSource = null;
        editGradePicker1.ItemsSource = null;
        editGradePicker2.ItemsSource = null;
        editGradePicker3.ItemsSource = null;
        editGradePicker4.ItemsSource = null;
    }

    private async void groupListNew()
    {

        DBConfig dB = new DBConfig();

        int lecturerID = dB.createQuerryInt(string.Format("SELECT lecturerID FROM ais.lecturer WHERE firstName = '{0}' AND lastName = '{1}'", MainPage._userService.firstName, MainPage._userService.lastName),
            MainPage._userService.Username, MainPage._userService.Password);

        //Debug.WriteLine("Lecturer ID is " + lecturerID);
        string query = string.Format("SELECT groupID FROM ais.lecturergroups WHERE lecturerID = '{0}'", lecturerID);
        var groupListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(groupListUnusable, new List<string> { "groupID" });

        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();
        bool duplicateItem;

        foreach (DataRow row in dT.Rows)

        {

            string value = row["groupID"].ToString();
            string displayText = dB.createQuerryString(string.Format("SELECT groupName FROM ais.groups WHERE groupID = '{0}'", Int32.Parse(value)), MainPage._userService.Username, MainPage._userService.Password);
            if (pickerItems != null)
            {

                duplicateItem = false;

                for (int i = 0; i < pickerItems.Count(); i++)
                {

                    if (value == pickerItems.ElementAt(i).Value)
                    {

                        duplicateItem = true;
                        break;
                    }
                    
                }

                if(!duplicateItem) pickerItems.Add(new CustomPickerItem(displayText, value));

            }   else pickerItems.Add(new CustomPickerItem(displayText, value));

        };

        addGradePicker1.ItemsSource = pickerItems;
        editGradePicker1.ItemsSource = pickerItems;
        
    }

    private async void gradeTypes()
    {

        string query = "SELECT grade_type_ID FROM ais.grade_type";
        DBConfig dB = new DBConfig();
        var gradeListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);

        DataTable dT = dB.transformToDT(gradeListUnusable, new List<string> { "grade_type_ID" });

        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)
        {

            string value = row["grade_type_ID"].ToString();
            string displayText = row["grade_type_ID"].ToString();

            int gradeID = Int32.Parse(displayText);
            displayText = dB.getGradeTypeString(gradeID, MainPage._userService.Username, MainPage._userService.Password);

            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        addGradePicker4.ItemsSource = pickerItems;
    }

    private async void availableGrades()
    {

        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        for (int i = 1; i <= 10; i++)
        {

            string value = i.ToString();
            string displayText = i.ToString();

            pickerItems.Add(new CustomPickerItem(displayText, value));

        }

        addGradePicker5.ItemsSource = pickerItems;
    }

    private async void OnAddGradePicker1Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)addGradePicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT lectureID FROM ais.lecturergroups WHERE groupID = '{0}'", groupID);
            DBConfig dB = new DBConfig();
            var lecturesListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(lecturesListUnusable, new List<string> { "lectureID" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["lectureID"].ToString();
                string displayText = dB.createQuerryString(string.Format("SELECT lectureName FROM ais.lectures WHERE lectureID = '{0}'", Int32.Parse(value)), MainPage._userService.Username, MainPage._userService.Password);

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            addGradePicker2.ItemsSource = pickerItems;

        }
    }

    private async void OnAddGradePicker2Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)addGradePicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT studentID, firstName, lastName FROM ais.student WHERE groupID = '{0}'", groupID);
            DBConfig dB = new DBConfig();
            var studentsListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(studentsListUnusable, new List<string> { "studentID", "firstName", "lastName" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["studentID"].ToString();
                string displayText1 = row["firstName"].ToString();
                string displayText2 = row["lastName"].ToString();
                string displayText = displayText1 + " " + displayText2;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            addGradePicker3.ItemsSource = pickerItems;

        }
    }

    private async void OnEGPicker1Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT lectureID FROM ais.lecturergroups WHERE groupID = '{0}'", groupID);
            DBConfig dB = new DBConfig();
            var lecturesListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(lecturesListUnusable, new List<string> { "lectureID" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["lectureID"].ToString();
                string displayText = dB.createQuerryString(string.Format("SELECT lectureName FROM ais.lectures WHERE lectureID = '{0}'", Int32.Parse(value)), MainPage._userService.Username, MainPage._userService.Password);

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            editGradePicker2.ItemsSource = pickerItems;
            

        }
    }

    private async void OnEGPicker2Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT studentID, firstName, lastName FROM ais.student WHERE groupID = '{0}'", groupID);
            DBConfig dB = new DBConfig();
            var studentsListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(studentsListUnusable, new List<string> { "studentID", "firstName", "lastName" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["studentID"].ToString();
                string displayText1 = row["firstName"].ToString();
                string displayText2 = row["lastName"].ToString();
                string displayText = displayText1 + " " + displayText2;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            editGradePicker3.ItemsSource = pickerItems;
            editGradePicker4.SelectedItem = null;

        }
    }

    private async void OnEGPicker3Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker3.SelectedItem;
        CustomPickerItem selectedLecture = (CustomPickerItem)editGradePicker2.SelectedItem;

        if (selectedItem != null && selectedLecture != null)
        {

            int studentID = Int32.Parse(selectedItem.Value);
            int lectureID = Int32.Parse(selectedLecture.Value);

            string query = string.Format("SELECT gradeID, grade, grade_typeID FROM ais.grades WHERE studentID = '{0}' AND lectureID = '{1}'", studentID, lectureID);
            DBConfig dB = new DBConfig();
            var gradeListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);

            DataTable dT = dB.transformToDT(gradeListUnusable, new List<string> { "gradeID", "grade", "grade_typeID" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["gradeID"].ToString();
                string displayText1 = row["grade"].ToString();
                string displayText2 = row["grade_typeID"].ToString();

                int gradeID = Int32.Parse(displayText2);
                displayText2 = dB.getGradeTypeString(gradeID, MainPage._userService.Username, MainPage._userService.Password);
                string displayText = displayText1 + " " + displayText2;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            editGradePicker4.ItemsSource = pickerItems;
        }
    }


}