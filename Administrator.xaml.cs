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

        addStudentDropDown();

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
        

    }

    private async void OnAddStudentBtnClicked (object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Patvirtinimas", "Ar tikrai norite itraukti nauja studenta i sarasa?", "Taip", "Ne");

        if (answer)
        {

            CustomPickerItem selectedItem = (CustomPickerItem)addStudentPicker.SelectedItem;

            int id = Int32.Parse(selectedItem.Value);

            var fNameEntry = FindByName("fNameEntry") as Entry;
            string fName = fNameEntry.Text;

            var lNameEntry = FindByName("lNameEntry") as Entry;
            string lName = lNameEntry.Text;

            Debug.WriteLine("Testuojami duomenys. Studento vardas: " + fName + " studento pavarde: " + lName + " studento grupe: " + id);

            DBConfig dB = new DBConfig();
            dB.createQuerry(string.Format("INSERT INTO ais.student (firstName, lastName, groupID) VALUES ('{0}', '{1}', '{2}')", fName, lName, id), MainPage._userService.Username, MainPage._userService.Password);

            await DisplayAlert("Patvirtinimas", "Studentas itrauktas i akademine informacine sistema", "Gerai");

        }
    }

    private async void addStudentDropDown()
    {
        string query = "SELECT groupID, groupName FROM ais.groups";
        DBConfig dB = new DBConfig();
        var groupListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);
        DataTable dT = dB.transformToDT(groupListUnusable, new List<string> { "groupID", "groupName" } );


        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach ( DataRow row in dT.Rows )

        {
            string value = row["groupID"].ToString();
            string displayText = row["groupName"].ToString();
            

            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        addStudentPicker.ItemsSource = pickerItems;
    }

    


}