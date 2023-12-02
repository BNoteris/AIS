using MySql.Data.MySqlClient;

namespace AIS;

public partial class Template : ContentPage
{
	public Template()
	{
		InitializeComponent();
	}


    //public async Task<List<List<object>>> getData(string v, string u_, string p_)
    //{

    //    openConnectionExists(u_, p_);

    //    MySqlCommand cmd = new MySqlCommand(v, conn);
    //    var rdr = await cmd.ExecuteReaderAsync(); // ERA - igalina ReadAsync skaityma duomenu

    //    var mainList = new List<List<object>>();

    //    while (await rdr.ReadAsync()) // ReadAsync - nuskaito tolimesne eilute (row)
    //    {
    //        List<object> data = new List<object>();
    //        for (int i = 0; i < rdr.FieldCount; i++)
    //        {  // FieldCount - column count

    //            data.Add(rdr.GetValue(i)); // GetValue paima column'o duomeni ir ideda i "temporary" data sarasa
    //        }

    //        mainList.Add(data); // temporary sarasas su vieno row duomenimis idedamas i main sarasa, kuriame visi duomenys accessible
    //    }

    //    closeConnection();

    //    return mainList;//list;
    //}
}