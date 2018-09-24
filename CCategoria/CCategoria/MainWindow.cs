using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CCategoria;
using System.Reflection;

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

		CellRendererText cellRendererText = new CellRendererText();
        
	//	treeView.AppendColumn(
	//		"ID",
	//		cellRendererText,
	//		delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				//    Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
				//    cellRendererText.Text = categoria.Id + "";
	//			object model = tree_model.GetValue(iter, 0);
	//			object value = model.GetType().GetProperty("Id").GetValue(model);
	//			cellRendererText.Text = value + "";
	//		}
	//	);
              
		string[] properties = new string[] { "Id", "Nombre" };
		foreach (string property in properties) {
			
			string propertyName = property;
			treeView.AppendColumn (
				
                property,
                cellRendererText,
                delegate (
					
					  TreeViewColumn tree_column,
				      CellRenderer cell,
				      TreeModel tree_model,
				      TreeIter iter) {
                //   Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
                //   cellRendererText.Text = categoria.Nombre + "";
                object model = tree_model.GetValue(iter, 0);
				object value = model.GetType().GetProperty(property).GetValue(model);
                cellRendererText.Text = value + "";
                }
            );
		}
		                                

	//	for (int index = 0; index < dataReader.FieldCount;index++){
	//		treeView.AppendColumn(getFieldNames(dataReader)[index], new CellRendererText(), "text", index);
	//	} 
	//	treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
	//	treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

	//	ListStore listStore = new ListStore(typeof(ulong), typeof(string));
		ListStore listStore = new ListStore(typeof(Categoria));
		treeView.Model = listStore;
		while(dataReader.Read()){
			listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
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
