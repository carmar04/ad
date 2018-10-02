using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;

using CCategoria;
using Serpis.Ad;

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

		App.Instance.DbConnection = new MySqlConnection(
                "server=localhost;" +
                "database=dbprueba;" +
                "user=root;" +
                "password=sistemas;" +
                "ssl-mode=none;"
            );

		new CategoriaWindow();

		//dbConnection = new MySqlConnection(
            //    "server=localhost;" +
            //    "database=dbprueba;" +
            //    "user=root;" +
            //    "password=sistemas;" +
            //    "ssl-mode=none;"
            //);

		App.Instance.DbConnection.Open();
        
	//	CellRendererText cellRendererText = new CellRendererText();

	//	//insert();
 //       //update();
        update(new Categoria(3, "categoría 3 " + DateTime.Now));
	//	//delete();

		TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);

	//	//	treeView.AppendColumn(
	//	//		"ID",
	//	//		cellRendererText,
	//	//		delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
	//	//    Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
	//	//    cellRendererText.Text = categoria.Id + "";
	//	//			object model = tree_model.GetValue(iter, 0);
	//	//			object value = model.GetType().GetProperty("Id").GetValue(model);
	//	//			cellRendererText.Text = value + "";
	//	//		}
	//	//	);

	//	//TreeViewHelper.Fill(treeView, CategoriaDao.List);
              
	//	string[] properties = new string[] { "Id", "Nombre" };
	//	foreach (string property in properties) {
			
	//		string propertyName = property;
	//		treeView.AppendColumn (
				
 //               property,
 //               cellRendererText,
 //               delegate (
					
	//				  TreeViewColumn tree_column,
	//			      CellRenderer cell,
	//			      TreeModel tree_model,
	//			      TreeIter iter) {
 //               //   Categoria categoria = (Categoria) tree_model.GetValue(iter, 0);
 //               //   cellRendererText.Text = categoria.Nombre + "";
 //               object model = tree_model.GetValue(iter, 0);
	//			object value = model.GetType().GetProperty(property).GetValue(model);
 //               cellRendererText.Text = value + "";
 //               }
 //           );
	//	}
		                                
	////	for (int index = 0; index < dataReader.FieldCount;index++){
	////		treeView.AppendColumn(getFieldNames(dataReader)[index], new CellRendererText(), "text", index);
	////	} 
	////	treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
	////	treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
	////	ListStore listStore = new ListStore(typeof(ulong), typeof(string));

		//ListStore listStore = new ListStore(typeof(Categoria));
  //      treeView.Model = listStore;
		//foreach (Categoria categoria in CategoriaDao.Categorias){
		//	listStore.AppendValues(categoria);
		//}      

		//IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
  //      dbCommand.CommandText = "select * from categoria order by 1";
  //      IDataReader dataReader = dbCommand.ExecuteReader();

		//while(dataReader.Read()){
		//	listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
		//}

		//	listStore.AppendValues("1", "categoria 1");
		//	listStore.AppendValues("2", "categoria 2");
        
        
    }
	private void insert()
    {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "insert into categoria (nombre) values ('categoría 4')";
        int filas = dbCommand.ExecuteNonQuery();
    }

    private void update()
    {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "update categoria set nombre='categoría 4 modificada' where id=4";
        dbCommand.ExecuteNonQuery();
    }

    private void update(Categoria categoria)
    {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";

		DbCommandHelper.AddParameter(dbCommand, "nombre", categoria.Nombre);
		DbCommandHelper.AddParameter(dbCommand, "id", categoria.Id);
		dbCommand.ExecuteNonQuery();

		//IDbDataParameter dbDataParameterNombre = dbCommand.CreateParameter();
		//dbDataParameterNombre.ParameterName = "nombre";
		//dbDataParameterNombre.Value = categoria.Nombre;
		//dbCommand.Parameters.Add(dbDataParameterNombre);
      
        //IDbDataParameter dbDataParameterId = dbCommand.CreateParameter();
        //dbDataParameterId.ParameterName = "id";
        //dbDataParameterId.Value = categoria.Id;
        //dbCommand.Parameters.Add(dbDataParameterId);
           
    }

    private void delete()
    {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
        dbCommand.CommandText = "delete from categoria where id=5";
        dbCommand.ExecuteNonQuery();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
		App.Instance.DbConnection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
