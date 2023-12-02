using AIS.Back.Custom;
using AIS.Back.DBConfig;
using AIS.Back.Service;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AIS;

public partial class Administrator : ContentPage

{
    public Administrator()
    {
        InitializeComponent();


    }
    private void OnASClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        EditGrade.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddStudent.IsVisible = true;
        AddStudent.IsEnabled = false;

        groupList();

        Debug.WriteLine("Testing userSerive visibility, username is " + MainPage._userService.Username + " password is: " + MainPage._userService.Password);

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceAddStudent.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnRSClicked(object sender, EventArgs e)
    {

        //Editing visibility

        AddStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        EditGrade.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        interfaceRemoveStudent.IsVisible = true;
        RemoveStudent.IsEnabled = false;

        groupList();


        //studentListPerGroup();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceRemoveStudent.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnALClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddStudent.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        EditGrade.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddLecturer.IsVisible = true;
        AddLecturer.IsEnabled = false;

        groupList();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceAddLecturer.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnRLClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        EditGrade.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        interfaceRemoveLecturer.IsVisible = true;
        RemoveLecturer.IsEnabled = false;

        lecturerList();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceRemoveLecturer.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnEGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        interfaceEditGrade.IsVisible = true;
        EditGrade.IsEnabled = false;

        groupList();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceEditGrade.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnCGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        RemoveGroup.IsVisible = false;
        EditGrade.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddGroup.IsVisible = true;
        CreateGroup.IsEnabled = false;

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceAddGroup.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnRGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        CreateGroup.IsVisible = false;
        EditGrade.IsVisible = false;
        Back.IsVisible = true;
        interfaceRemoveGroup.IsVisible = true;
        RemoveGroup.IsEnabled = false;

        groupList();


        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceRemoveGroup.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        //Editing visibility

        AddStudent.IsVisible = true;
        RemoveStudent.IsVisible = true;
        AddLecturer.IsVisible = true;
        RemoveLecturer.IsVisible = true;
        EditGrade.IsVisible = true;
        CreateGroup.IsVisible = true;
        RemoveGroup.IsVisible = true;
        Back.IsVisible = false;

        //Editing functionality

        AddStudent.IsEnabled = true;
        RemoveStudent.IsEnabled = true;
        AddLecturer.IsEnabled = true;
        RemoveLecturer.IsEnabled = true;
        EditGrade.IsEnabled = true;
        CreateGroup.IsEnabled = true;
        RemoveGroup.IsEnabled = true;


        //Interfaces visibility

        interfaceAddStudent.IsVisible = false;
        interfaceRemoveStudent.IsVisible = false;
        interfaceAddLecturer.IsVisible = false;
        interfaceRemoveLecturer.IsVisible = false;
        interfaceEditGrade.IsVisible = false;
        interfaceAddGroup.IsVisible = false;
        interfaceRemoveGroup.IsVisible = false;

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Center;

        //Reset pickers

        resetPickers();


    }

    private async void OnAddStudentBtnClicked(object sender, EventArgs e)
    {

        var fNameEntry = FindByName("fNameEntry") as Entry;
        string fName = fNameEntry.Text;

        var lNameEntry = FindByName("lNameEntry") as Entry;
        string lName = lNameEntry.Text;

        if (lName == "" && fName == "" || fName == "" || lName == "" || lName == null && fName == null || fName == null || lName == null)
        {

            await DisplayAlert("Klaida", "Patikrinkite asmens duomenis", "Gerai");
        }
        else
        {

            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite itraukti nauja studenta i sarasa?", "Taip", "Ne");

            if (answer)
            {

                CustomPickerItem selectedItem = (CustomPickerItem)addStudentPicker.SelectedItem;

                if (selectedItem != null)
                {

                    int id = Int32.Parse(selectedItem.Value);

                    Debug.WriteLine("Testuojami duomenys. Studento vardas: " + fName + " studento pavarde: " + lName + " studento grupe: " + id);

                    DBConfig dB = new DBConfig();

                    string newUser = dB.generateUser(MainPage._userService.Username, MainPage._userService.Password);

                    string query = string.Format("INSERT INTO ais.users (username, password, DBuser, firstName, lastName, user_typeID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", new object[6] { fName, lName, newUser, fName, lName, 3 });
                    dB.createQuerry(string.Format("INSERT INTO ais.student (firstName, lastName, groupID) VALUES ('{0}', '{1}', '{2}')", fName, lName, id), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(query, MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("CREATE USER '{0}' IDENTIFIED BY '{1}'", newUser, lName), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.grades TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.lectures TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);

                    resetPickers();
                    groupList();


                    await DisplayAlert("Patvirtinimas", "Studentas itrauktas i akademine informacine sistema", "Gerai");

                }
            }
        }
    }

    private async void OnRemoveStudentClicked(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)removeStudentPicker2.SelectedItem;

        if (selectedItem == null) {

            await DisplayAlert("Klaida", "Nepasirinkta jokia grupe ar studentas", "Gerai");
        }
        else {

        bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite istrinti si studenta?", "Taip", "Ne");

        if (answer)
        {


            if (selectedItem != null)
            {

                int id = Int32.Parse(selectedItem.Value);

                DBConfig dB = new DBConfig();

                
                string fName = dB.createQuerryString(string.Format("SELECT firstName FROM ais.student WHERE studentID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                string lName = dB.createQuerryString(string.Format("SELECT lastName FROM ais.student WHERE studentID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);

                string DBuser = dB.createQuerryString(string.Format("SELECT DBuser FROM ais.users WHERE firstName = '{0}' AND lastName = '{1}'", fName, lName), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DELETE FROM ais.student WHERE studentID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DELETE FROM ais.users WHERE DBuser = '{0}'", DBuser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DROP USER '{0}'", DBuser), MainPage._userService.Username, MainPage._userService.Password);

                resetPickers();
                groupList();

                await DisplayAlert("Patvirtinimas", "Studentas istrintas is akademines informacines sistema", "Gerai");
            }
            }
        }
    }

    private async void OnAddLecturerBtnClicked(object sender, EventArgs e)
    {

        var fNameEntry = FindByName("fNameLEntry") as Entry;
        string fName = fNameEntry.Text;

        var lNameEntry = FindByName("lNameFEntry") as Entry;
        string lName = lNameEntry.Text;

        if (lName == "" && fName == "" || fName == "" || lName == "" || lName == null && fName == null || fName == null || lName == null)
        {

            await DisplayAlert("Klaida", "Patikrinkite asmens duomenis", "Gerai");
        }
        else
        {
            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite itraukti si destytoja?", "Taip", "Ne");

            if (answer)
            {

                CustomPickerItem selectedItem = (CustomPickerItem)addLecturerPicker.SelectedItem;

                int id = Int32.Parse(selectedItem.Value);

                DBConfig dB = new DBConfig();

                string newUser = dB.generateUser(MainPage._userService.Username, MainPage._userService.Password);

                dB.createQuerry(string.Format("INSERT INTO ais.lecturer (firstName, lastName, groupID) VALUES ('{0}', '{1}', '{2}')", fName, lName, id), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("INSERT INTO ais.users (username, password, DBuser, firstName, lastName, user_typeID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                    , new object[6] { fName, lName, newUser, fName, lName, 2 }), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("CREATE USER '{0}' IDENTIFIED BY '{1}'", newUser, lName), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT, UPDATE, INSERT ON ais.grades TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.lectures TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);

                resetPickers();
                groupList();

                await DisplayAlert("Patvirtinimas", "Destytojas itrauktas i akademine informacine sistema", "Gerai");
            }
        }


    }

    private async void OnRemoveLecturerBtnClicked(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)removeLecturerPicker.SelectedItem;

        if (selectedItem != null)
        {
            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite istrinti si destytoja?", "Taip", "Ne");

            if (answer)
            {


                int id = Int32.Parse(selectedItem.Value);

                DBConfig dB = new DBConfig();
                string fName = dB.createQuerryString(string.Format("SELECT firstName FROM ais.lecturer WHERE lecturerID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                string lName = dB.createQuerryString(string.Format("SELECT lastName FROM ais.lecturer WHERE lecturerID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DELETE FROM ais.lecturer WHERE lecturerID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DELETE FROM ais.users WHERE firstName = '{0}' AND lastName = '{1}'", fName, lName), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DROP USER '{0}'", fName), MainPage._userService.Username, MainPage._userService.Password);

                resetPickers();
                lecturerList();

                await DisplayAlert("Patvirtinimas", "Destytojas istrintas is akademines informacines sistema", "Gerai");
            }

        }
        else await DisplayAlert("Klaida", "Nepasirinktas joks destytojas", "Gerai");

    }

    private async void OnEditGradeBtnClicked(object sender, EventArgs e)
    {

        int resultInt;
        string result;

        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker3.SelectedItem;

        if (selectedItem != null)
        {

            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite redaguoti sio studento pazymi?", "Taip", "Ne");

            int id = Int32.Parse(selectedItem.Value);
            DBConfig dB = new DBConfig();

            if (answer)
            {

                do
                {

                    result = await DisplayPromptAsync("Pazymio keitimas", "Iveskite nauja pazymi", accept: "Patvirtinti", cancel: "Atsaukti");
                    resultInt = Int32.Parse(result);

                    if (resultInt > 0 && resultInt <= 10)
                    {

                        dB.createQuerry(string.Format("UPDATE ais.grade SET grade = '{0}' gradeID = '{1}'", resultInt, id), MainPage._userService.Username, MainPage._userService.Password);

                        await DisplayAlert("Patvirtinimas", "Destytojas istrintas is akademines informacines sistemos", "Gerai");
                    }
                    else

                    {
                        await DisplayAlert("Pranesimas", "Skaicius neivestas, arba neegzistuoja normoje nuo 1 iki 10", "Gerai");
                    }
                } while (resultInt <= 0 && resultInt > 10);

                resetPickers();
                groupList();
            }
        }   else await DisplayAlert("Klaida", "Nepasirinkta grupe, studentas, ar pazymys", "Gerai");

    }

    private async void OnAddGroupBtnClicked(object sender, EventArgs e)
    {

        DBConfig dB = new DBConfig();

        var fNameEntry = FindByName("gNameEntry") as Entry;
        string fName = fNameEntry.Text;
        string checkName = dB.createQuerryString(string.Format("SELECT groupName FROM ais.groups WHERE groupName = '{0}'", fName), MainPage._userService.Username, MainPage._userService.Password);


        if (fName == "" || fName == null)
        {
            await DisplayAlert("Klaida", "Patikrinkite grupes pavadinima", "Gerai");
            } else if (fName == checkName){

            await DisplayAlert("Klaida", "Tokia grupe jau egzistuoja", "Gerai");
            }
        else
        {
            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite itraukti sia grupe?", "Taip", "Ne");

            if (answer)
            {

                string query = string.Format("INSERT INTO ais.groups (groupName) VALUES ('{0}')", fName);
                dB.createQuerry(query, MainPage._userService.Username, MainPage._userService.Password);

                await DisplayAlert("Patvirtinimas", "Grupe itraukta i informacine sistema", "Gerai");

            }
        }

    }

    private async void OnGroupRemoveBtnClicked(object sender, EventArgs e)
    {

        DBConfig dB = new DBConfig();
        CustomPickerItem selectedItem = (CustomPickerItem)groupRemovePicker.SelectedItem;

        if (selectedItem != null)
        {

            int id = Int32.Parse(selectedItem.Value);

            string queryCheckForStudents = string.Format("SELECT COUNT(*) FROM ais.student WHERE groupID = '{0}'", id);
            string queryCheckForLecturers = string.Format("SELECT COUNT(*) FROM ais.lecturer WHERE groupID = '{0}'", id);

            if (dB.checkIfRelative(queryCheckForStudents, MainPage._userService.Username, MainPage._userService.Password))
            {
                await DisplayAlert("Klaida", "Sioje grupeje egzistuoja studentu, todel grupes trynimas negalimas", "Gerai");

            }
            else if (dB.checkIfRelative(queryCheckForLecturers, MainPage._userService.Username, MainPage._userService.Password))
            {

                await DisplayAlert("Klaida", "Sioje grupeje egzistuoja destytoju, todel grupes trynimas negalimas", "Gerai");
            }
            else
            {

                bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite istrinti sia grupe?", "Taip", "Ne");

                if (answer)
                {

                    dB.createQuerry(string.Format("DELETE FROM ais.groups WHERE groupID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);

                    resetPickers();
                    groupList();

                    await DisplayAlert("Patvirtinimas", "Grupe istrinta is informacines sistemos", "Gerai");

                }
            }
        }
        else await DisplayAlert("Klaida", "Nepasirinkta jokia grupe", "Gerai");

    }

    private void resetPickers()
    {
        groupRemovePicker.ItemsSource = null;
        removeLecturerPicker.ItemsSource = null;
        removeStudentPicker2.ItemsSource = null;
        editGradePicker1.ItemsSource = null;
        editGradePicker2.ItemsSource = null;
        editGradePicker3.ItemsSource = null;
        addStudentPicker.ItemsSource = null;
        removeStudentPicker1.ItemsSource = null;
        addLecturerPicker.ItemsSource = null;

    }

    private async void groupList()
    {
        string query = "SELECT groupID, groupName FROM ais.groups";
        DBConfig dB = new DBConfig();
        var groupListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(groupListUnusable, new List<string> { "groupID", "groupName" });


        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)

        {
            string value = row["groupID"].ToString();
            string displayText = row["groupName"].ToString();


            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        addStudentPicker.ItemsSource = pickerItems;
        removeStudentPicker1.ItemsSource = pickerItems;
        addLecturerPicker.ItemsSource = pickerItems;
        editGradePicker1.ItemsSource = pickerItems;
        groupRemovePicker.ItemsSource = pickerItems;
    }

    private async void lecturerList()
    {
        string query = "SELECT lecturerID, firstName, lastName FROM ais.lecturer";
        DBConfig dB = new DBConfig();
        var groupListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(groupListUnusable, new List<string> { "lecturerID", "firstName", "lastName" });


        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)

        {
            string value = row["lecturerID"].ToString();
            string displayText1 = row["firstName"].ToString();
            string displayText2 = row["lastName"].ToString();
            string displayText = displayText1 + " " + displayText2;


            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        removeLecturerPicker.ItemsSource = pickerItems;
    }

    //private async void studentListPerGroup()
    //{

    //    CustomPickerItem selectedItem = (CustomPickerItem)removeStudentPicker1.SelectedItem;

    //    int groupID = Int32.Parse(selectedItem.Value);

    //    string query = string.Format("SELECT studentID, firstName, lastName WHERE groupID = '{0}'", groupID);
    //    DBConfig dB = new DBConfig();
    //    var studentListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
    //    DataTable dT = dB.transformToDT(studentListUnusable, new List<string> { "studentID", "firstName", "lastName" });

    //    List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

    //    foreach ( DataRow row in dT.Rows)
    //    {

    //        string value = row["studentID"].ToString();
    //        string displayText = row["firstName" + "lastName"].ToString();

    //        pickerItems.Add(new CustomPickerItem(displayText, value));
    //    }; 

    //    removeStudentPicker2.ItemsSource = pickerItems;


    //}

    private async void OnPicker1IndexChange(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)removeStudentPicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT studentID, firstName, lastName FROM ais.student WHERE groupID = '{0}'", groupID);
            DBConfig dB = new DBConfig();
            var studentListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(studentListUnusable, new List<string> { "studentID", "firstName", "lastName" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["studentID"].ToString();
                string displayText1 = row["firstName"].ToString();
                string displayText2 = row["lastName"].ToString();
                string displayText = displayText1 + " " + displayText2;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            removeStudentPicker2.ItemsSource = pickerItems;

        }

    }

    private async void OnEGPicker1Index(object sender, EventArgs e)
    {
        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker1.SelectedItem;

        if (selectedItem != null)
        {

            int groupID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT studentID, firstName, lastName FROM ais.student WHERE groupID = '{0}'", groupID);

            DBConfig dB = new DBConfig();
            var studentListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
            DataTable dT = dB.transformToDT(studentListUnusable, new List<string> { "studentID", "firstName", "lastName" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["studentID"].ToString();
                string displayText1 = row["firstName"].ToString();
                string displayText2 = row["lastName"].ToString();
                string displayText = displayText1 + " " + displayText2;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            editGradePicker2.ItemsSource = pickerItems;
        }
    }

    private async void OnEGPicker2Index(object sender, EventArgs e)
    {
        CustomPickerItem selectedItem = (CustomPickerItem)editGradePicker2.SelectedItem;

        if (selectedItem != null)
        {

            int studentID = Int32.Parse(selectedItem.Value);

            string query = string.Format("SELECT gradeID, grade, grade_typeID FROM ais.grades WHERE studentID = '{0}'", studentID);
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

            editGradePicker3.ItemsSource = pickerItems;
        }
    }



}