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
	}

    private void OnAGClicked(object sender, EventArgs e)
    {

        //Editing visibility

        EditGrade.IsVisible = false;
        Back.IsVisible = true;
        interfaceAddGrade.IsVisible = true;
        AddGrade.IsEnabled = false;

        groupList();
        gradeTypes();
        availableGrades();

        Debug.WriteLine("Testing userSerive visibility, username is " + MainPage._userService.Username + " password is: " + MainPage._userService.Password);

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

        groupList();


        //studentListPerGroup();

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



        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Center;

        //Reset pickers


    }

    private void OnAddGradeBtnClicked(object sender, EventArgs e)
    {

        CustomPickerItem selectedGroup = (CustomPickerItem)addGradePicker1.SelectedItem;
        CustomPickerItem selectedStudent = (CustomPickerItem)addGradePicker2.SelectedItem;
        CustomPickerItem selectedType = (CustomPickerItem)addGradePicker3.SelectedItem;
        CustomPickerItem selectedGrade = (CustomPickerItem)addGradePicker4.SelectedItem;
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

        addGradePicker1.ItemsSource = pickerItems;
        
    }

    private async void gradeTypes()
    {

        string query = "SELECT grade_typeID FROM ais.grades";
        DBConfig dB = new DBConfig();
        var gradeListUnusable = await dB.getData(query, MainPage._userService.Username, MainPage._userService.Password);

        DataTable dT = dB.transformToDT(gradeListUnusable, new List<string> { "grade_typeID" });

        List<CustomPickerItem> pickerItems = new List<CustomPickerItem>();

        foreach (DataRow row in dT.Rows)
        {

            string value = row["grade_typeID"].ToString();
            string displayText = row["grade_typeID"].ToString();

            int gradeID = Int32.Parse(displayText);
            displayText = dB.getGradeTypeString(gradeID, MainPage._userService.Username, MainPage._userService.Password);

            pickerItems.Add(new CustomPickerItem(displayText, value));
        };

        addGradePicker3.ItemsSource = pickerItems;
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

        addGradePicker4.ItemsSource = pickerItems;
    }

    private async void OnAddGradePicker1Index(object sender, EventArgs e)
    {

        CustomPickerItem selectedItem = (CustomPickerItem)addGradePicker1.SelectedItem;

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

            addGradePicker2.ItemsSource = pickerItems;

        }
    }


}