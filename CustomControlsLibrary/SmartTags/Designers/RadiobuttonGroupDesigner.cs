using System.ComponentModel.Design;
using System.Windows.Forms.Design;
namespace CustomControlsLibrary
{
    public class RadiobuttonGroupDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionList;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionList == null)
                {
                    actionList = new DesignerActionListCollection();
                    actionList.Add(new RadiobuttonGroupActionList(this.Component));
                }
                return actionList;
            }
        }
    }
}
