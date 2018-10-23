using System;
using Gtk;
namespace Serpis.Ad
{
    public class WindowHelper
    {
		public static bool Confirm(Window windowParent, string message){
			MessageDialog messageDialog = new MessageDialog(
				windowParent,
                DialogFlags.Modal,
                MessageType.Question,
                ButtonsType.YesNo,
                message
            );

            ResponseType response = (ResponseType)messageDialog.Run();
            messageDialog.Destroy();
                 
			return response == ResponseType.Yes;
		}
    }
}
