using System.ComponentModel.Design;
using System.Windows.Forms.Design;
namespace CustomControlsLibrary
{
    // DOES NOT WORK IN WPF
    public class RadiobuttonGroupDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists = null;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new RadiobuttonGroupActionList(this.Component));
                }
                return actionLists;
            }
        }
    }
}
