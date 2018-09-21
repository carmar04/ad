using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public partial class MainWindow : Gtk.Window
{
	private static string[] getFieldNames(IDataReader dataReader)
    {
        //int fieldCount = dataReader.FieldCount;
        //string [] fieldNames = new string[fieldCount];
        //for (int index = 0; index < fieldCount; index++)
        //{
        //fieldNames.SetValue(dataReader.GetName(index), index);
        //}
        //return fieldNames;
        List<string> fieldNamelist = new List<string>();
        int fieldCount = dataReader.FieldCount;
        for (int index = 0; index < dataReader.FieldCount; index++)
        {
            fieldNamelist.Add(dataReader.GetName(index));
        }
        return fieldNamelist.ToArray();
    }
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

		object obj = null;
		Console.WriteLine("" + obj);

		IDbConnection dbConnection = new MySqlConnection(
                "server=localhost;" +
                "database=dbprueba;" +
                "user=root;" +
                "password=sistemas;" +
                "ssl-mode=none;"
            );
		dbConnection.Open();

		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "select * from categoria order by 1";
		IDataReader dataReader = dbCommand.ExecuteReader();



		for (int index = 0; index < dataReader.FieldCount;index++){
			treeView.AppendColumn(getFieldNames(dataReader)[index], new CellRendererText(), "text", index);
		} 
	//	treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
	//	treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

	//	ListStore listStore = new ListStore(typeof(ulong), typeof(string));
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		treeView.Model = listStore;
		while(dataReader.Read()){
			listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"]);
		}
	//	listStore.AppendValues("1", "categoria 1");
	//	listStore.AppendValues("2", "categoria 2");

		dbConnection.Close();
        
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
