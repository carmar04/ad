using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;

using CCategoria;
using Serpis.Ad;
using Serpis.Ad.Ventas;


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

		Title = "Categoria";
      
		TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);

		newAction.Activated += delegate {
			new CategoriaWindow(new Categoria());
		};
        
		editAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			Console.WriteLine("Id = " + id);
			Categoria categoria = CategoriaDao.Load(id);
			new CategoriaWindow(categoria);
		};
		refreshAction.Activated += delegate {
            TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);
        };
		deleteAction.Activated += delegate {
			if(WindowHelper.Confirm(this, "Quieres eliminar el registro?")){
				object id = TreeViewHelper.GetId(treeView);
				CategoriaDao.Delete(id);
			}
		};



		treeView.Selection.Changed += delegate {
		
			refreshUI();
		};

		refreshUI();

    }
	private void refreshUI(){
		bool treeViewSelected = treeView.Selection.CountSelectedRows() > 0;
		editAction.Sensitive = treeViewSelected;
		deleteAction.Sensitive = treeViewSelected;
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
