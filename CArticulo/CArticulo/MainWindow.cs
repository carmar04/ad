using System;
using Gtk;
using Serpis.Ad;
using Serpis.Ad.Ventas;
using CArticulo
//public class EntityDaoArticulo : EntityDao<CArticulo> { }


public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        EntityDao<Articulo> articuloDao = new EntityDao<Articulo>();
        TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre", "Precio", "Categoria" }, articuloDao.Enumerable);

		newAction.Activated += delegate
		{
			new ArticuloWindow(articulo);

		};
		editAction.Activated += delegate
        {
            object id = TreeViewHelper.GetId(treeView);
            Articulo articulo = articuloDao.Load();
            new ArticuloWindow(articulo);

        };
		deleteAction.Activated += delegate
        {
			if (WindowHelper.Confirm("Quieres eliminar el registro?")){
				object id = TreeViewHelper.GetId(treeView);
				articuloDao.Delete(id);
			}
        };
		refreshAction.Activated += delegate {
			TreeViewHelper.

		};


    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}