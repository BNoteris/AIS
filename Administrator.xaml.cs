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
    private void OnASClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        EditGrade.IsVisible = false;
        CreateGroup.IsVisible = false;
        RemoveGroup.IsVisible = false;
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddStudent.IsVisible = true;
        AddStudent.IsEnabled = false;

        groupList();

        //Debug.WriteLine("Testing userSerive visibility, username is " + MainPage._userService.Username + " password is: " + MainPage._userService.Password);

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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
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
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        AddLecture.IsVisible = false;
        interfaceRemoveGroup.IsVisible = true;
        RemoveGroup.IsEnabled = false;

        groupList();


        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceRemoveGroup.HorizontalOptions = LayoutOptions.Center;

    }

    private void OnAddLectureClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        CreateGroup.IsVisible = false;
        EditGrade.IsVisible = false;
        RemoveLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        AddLecture.IsEnabled = false;

        interfaceAddLecture.IsVisible = true;

        //Alignment transform

        interfaceAddLecture.HorizontalOptions = LayoutOptions.Center;
    }

    private void OnRemoveLectureClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        CreateGroup.IsVisible = false;
        EditGrade.IsVisible = false;
        AddLecture.IsVisible = false;
        AssignLecture.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        RemoveLecture.IsEnabled = false;

        interfaceRemoveLecture.IsVisible = true;

        lecturesList();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceRemoveLecture.HorizontalOptions = LayoutOptions.Center;
    }

    private void OnAssignLectureClicked(object sender, EventArgs e)
    {

        //Editing visibility

        RemoveStudent.IsVisible = false;
        AddLecturer.IsVisible = false;
        RemoveLecturer.IsVisible = false;
        AddStudent.IsVisible = false;
        CreateGroup.IsVisible = false;
        EditGrade.IsVisible = false;
        AddLecture.IsVisible = false;
        RemoveLecture.IsVisible = false;
        RemoveGroup.IsVisible = false;
        Back.IsVisible = true;
        AssignLecture.IsEnabled = false;

        interfaceAssignLecture.IsVisible = true;

        lecturesList();
        groupList();
        lecturerList();

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
        interfaceAssignLecture.HorizontalOptions = LayoutOptions.Center;
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
        AddLecture.IsVisible = true;
        RemoveLecture.IsVisible = true;
        AssignLecture.IsVisible = true;
        Back.IsVisible = false;

        //Editing functionality

        AddStudent.IsEnabled = true;
        RemoveStudent.IsEnabled = true;
        AddLecturer.IsEnabled = true;
        RemoveLecturer.IsEnabled = true;
        EditGrade.IsEnabled = true;
        CreateGroup.IsEnabled = true;
        RemoveGroup.IsEnabled = true;
        AddLecture.IsEnabled = true;
        RemoveLecture.IsEnabled = true;
        AssignLecture.IsEnabled = true;


        //Interfaces visibility

        interfaceAddStudent.IsVisible = false;
        interfaceRemoveStudent.IsVisible = false;
        interfaceAddLecturer.IsVisible = false;
        interfaceRemoveLecturer.IsVisible = false;
        interfaceEditGrade.IsVisible = false;
        interfaceAddGroup.IsVisible = false;
        interfaceRemoveGroup.IsVisible = false;
        interfaceAddLecture.IsVisible = false;
        interfaceRemoveLecture.IsVisible = false;
        interfaceAssignLecture.IsVisible = false;

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Center;

        //Reset pickers

        resetPickers();


    }

                                                                                            // BUTTONS IN INTERFACE FUNCTIONALITY \/ BEGIN

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

                    //Debug.WriteLine("Testuojami duomenys. Studento vardas: " + fName + " studento pavarde: " + lName + " studento grupe: " + id);

                    DBConfig dB = new DBConfig();

                    string newUser = dB.generateUser(MainPage._userService.Username, MainPage._userService.Password);

                    string query = string.Format("INSERT INTO ais.users (username, password, DBuser, firstName, lastName, user_typeID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", new object[6] { fName, lName, newUser, fName, lName, 3 });
                    dB.createQuerry(string.Format("INSERT INTO ais.student (firstName, lastName, groupID) VALUES ('{0}', '{1}', '{2}')", fName, lName, id), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(query, MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("CREATE USER '{0}' IDENTIFIED BY '{1}'", newUser, lName), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.grades TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.lectures TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.lecturer TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.grade_type TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.student TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                    dB.createQuerry(string.Format("GRANT SELECT ON ais.lecturergroups TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);

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

                DBConfig dB = new DBConfig();

                string newUser = dB.generateUser(MainPage._userService.Username, MainPage._userService.Password);

                dB.createQuerry(string.Format("INSERT INTO ais.lecturer (firstName, lastName) VALUES ('{0}', '{1}')", fName, lName), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("INSERT INTO ais.users (username, password, DBuser, firstName, lastName, user_typeID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                    , new object[6] { fName, lName, newUser, fName, lName, 2 }), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("CREATE USER '{0}' IDENTIFIED BY '{1}'", newUser, lName), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT, UPDATE, INSERT ON ais.grades TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.lectures TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.student TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.lecturer TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.groups TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.lecturergroups TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("GRANT SELECT ON ais.grade_type TO '{0}'", newUser), MainPage._userService.Username, MainPage._userService.Password);

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

                        dB.createQuerry(string.Format("UPDATE ais.grades SET grade = '{0}' WHERE gradeID = '{1}'", resultInt, id), MainPage._userService.Username, MainPage._userService.Password);

                        await DisplayAlert("Patvirtinimas", "Pazymys atnaujintas", "Gerai");
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

            if (dB.checkIfRelative(queryCheckForStudents, MainPage._userService.Username, MainPage._userService.Password))
            {
                await DisplayAlert("Klaida", "Sioje grupeje egzistuoja studentu, todel grupes trynimas negalimas", "Gerai");

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

    private async void OnLectureCreateBtnClicked(object sender, EventArgs e)
    {

        var lNameEntry = FindByName("lectureNameEntry") as Entry;
        string lName = lNameEntry.Text;

        DBConfig dB = new DBConfig();
        bool checkName = dB.checkIfRelative(string.Format("SELECT COUNT(*) FROM ais.lectures WHERE lectureName = '{0}'", lName), MainPage._userService.Username, MainPage._userService.Password);
        
        if (lName == null || lName == "") {

            await DisplayAlert("Klaida", "Neivestas paskaitos pavadinimas", "Gerai");
        }

        else if (checkName)
        {

            await DisplayAlert("Klaida", "Tokia paskaita jau egzistuoja", "Gerai");
        }
        else {

            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite sukurti sia paskaita?", "Taip", "Ne");

            if (answer)
            {

                dB.createQuerry(string.Format("INSERT INTO ais.lectures (lectureName) VALUES ('{0}')", lName), MainPage._userService.Username, MainPage._userService.Password);

                await DisplayAlert("Patvirtinimas", "Paskaita sukurta", "Gerai");
            }
        }
    }

    private async void OnLectureRemoveBtnClicked(object sender, EventArgs e)
    {

        CustomPickerItem pickedItem = (CustomPickerItem)lectureRemovePicker.SelectedItem;


        if (pickedItem != null)
        {
            bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite istrinti sia paskaita? Istrindami ja, istrinsite ir visiems studentams, priskirtiems jai", "Taip", "Ne");

            if (answer)
            {

                int id = Int32.Parse(pickedItem.Value);

                DBConfig dB = new DBConfig();
                dB.createQuerry(string.Format("DELETE FROM ais.lectures WHERE lectureID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);
                dB.createQuerry(string.Format("DELETE FROM ais.lecturergroups WHERE lectureID = '{0}'", id), MainPage._userService.Username, MainPage._userService.Password);

                await DisplayAlert("Patvirtinimas", "Paskaita istrinta", "Gerai");

                resetPickers();
                lecturesList();
            }
        }
        else await DisplayAlert("Klaida", "Nepasirinkta jokia paskaita", "Gerai");
    }

    private async void OnAssignLectureBtnClicked(object sender, EventArgs e)
    {

        CustomPickerItem selectedLecture = (CustomPickerItem)assignLecturePicker1.SelectedItem;
        CustomPickerItem selectedGroup = (CustomPickerItem)assignLecturePicker2.SelectedItem;
        CustomPickerItem selectedLecturer = (CustomPickerItem)assignLecturePicker3.SelectedItem;

        if (selectedLecture != null && selectedGroup != null && selectedLecturer != null)
        {

            int lectureID = Int32.Parse(selectedLecture.Value);
            int groupID = Int32.Parse(selectedGroup.Value);
            int lecturerID = Int32.Parse(selectedLecturer.Value);
            DBConfig dB = new DBConfig();

            bool checkForRepeating = dB.checkIfRelative(string.Format("SELECT COUNT(*) FROM ais.lecturergroups WHERE lectureID = '{0}' AND lecturerID = '{1}' AND groupID = '{2}'", lectureID, lecturerID, groupID), 
                MainPage._userService.Username, MainPage._userService.Password);

            if (!checkForRepeating)
            {

                bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite sia paskaita priskirti pasirinktai grupei bei destytojui?", "Taip", "Ne");

                if (answer)
                {


                    dB.createQuerry(string.Format("INSERT INTO ais.lecturergroups (lectureID, lecturerID, groupID) VALUES ('{0}', '{1}', '{2}')", lectureID, lecturerID, groupID), MainPage._userService.Username, MainPage._userService.Password);

                    await DisplayAlert("Patvirtinimas", "Paskaita priskirta grupei bei destytojui", "Gerai");
                }
            } else if (checkForRepeating)
            {

                await DisplayAlert("Klaida", "Destytojas jau paskirtas siai paskaitai siai grupei", "Gerai");
            }
        }
        else await DisplayAlert("Klaida", "Kazkuris laukas yra tuscias, perziurekite parametrus", "Gerai");
    }

                                                                            // BUTTONS IN INTERFACE FUNCTIONALITY /\ END

                                                                            // FUNCTIONALITY, DROP-DOWN LISTS, DATATABLE CONVERSIONS \/ BEGIN

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
        editGradePicker1.ItemsSource = pickerItems;
        groupRemovePicker.ItemsSource = pickerItems;
        assignLecturePicker2.ItemsSource = pickerItems;
    }

    private async void lecturesList()
    {
        string query = "SELECT lectureID, lectureName FROM ais.lectures";
        DBConfig dB = new DBConfig();
        var lectureListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(lectureListUnusable, new List<string> { "lectureID", "lectureName" });


        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)

        {
            string value = row["lectureID"].ToString();
            string displayText = row["lectureName"].ToString();


            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        lectureRemovePicker.ItemsSource = pickerItems;
        assignLecturePicker1.ItemsSource = pickerItems;
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
        assignLecturePicker3.ItemsSource = pickerItems;
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

            string query = string.Format("SELECT gradeID, grade, grade_typeID, lectureID FROM ais.grades WHERE studentID = '{0}'", studentID);
            DBConfig dB = new DBConfig();
            var gradeListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);

            DataTable dT = dB.transformToDT(gradeListUnusable, new List<string> { "gradeID", "grade", "grade_typeID", "lectureID" });

            List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

            foreach (DataRow row in dT.Rows)
            {

                string value = row["gradeID"].ToString();
                string displayText1 = row["grade"].ToString();
                string displayText2 = row["grade_typeID"].ToString();
                string lectureName = dB.createQuerryString(string.Format("SELECT lectureName FROM ais.lectures WHERE lectureID = '{0}'", Int32.Parse(row["lectureID"].ToString())), 
                    MainPage._userService.Username, MainPage._userService.Password);

                int gradeID = Int32.Parse(displayText2);
                displayText2 = dB.getGradeTypeString(gradeID, MainPage._userService.Username, MainPage._userService.Password);
                string displayText = lectureName + " - " + displayText2 + " " + displayText1;

                pickerItems.Add(new CustomPickerItem(displayText, value));
            };

            editGradePicker3.ItemsSource = pickerItems;
        }
    }



}