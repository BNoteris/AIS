using AIS.Back.Service;
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

        Debug.WriteLine("Testing userSerive visibility, username is " + MainPage._userService.Username + " password is: " + MainPage._userService.Password);

		//Alignment transform

		interfaceButtons.HorizontalOptions = LayoutOptions.Fill;
		
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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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
        

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Fill;

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

        //Alignment transform

        interfaceButtons.HorizontalOptions = LayoutOptions.Center;
    }
}