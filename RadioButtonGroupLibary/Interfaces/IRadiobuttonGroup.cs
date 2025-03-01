using System.Windows.Controls;

namespace RadioButtonGroupLibary.Interfaces
{
    public interface IRadiobuttonGroup
    {
        /// <summary>
        /// Creates and returns radio button
        /// </summary>
        /// <param name="content">Content to be displayed inside a button</param>
        /// <returns>Created radio button</returns>
        RadioButton CreateButton(string content);

        /// <summary>
        /// Adds button to the group and displays it
        /// </summary>
        /// <param name="button">Button to display</param>
        void DisplayButton(RadioButton button);

        /// <summary>
        /// Removes button from the group based on the content
        /// </summary>
        /// <param name="buttonContent">Content do remove button based on</param>
        void RemoveByContent(string buttonContent);
    }
}
