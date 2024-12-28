using SimpleEnterpriseFramework.Builders.UIBuilder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEnterpriseFramework
{
    public partial class BaseFormBuilder : Form, IFormBuilder
    {
        protected Panel main;

        protected string title;
        protected List<FormTextField> textFields = new List<FormTextField>();
        protected List<Button> buttons = new List<Button>();

        public IFormBuilder SetTitle(string new_title)
        {
            title = new_title;
            return this;
        }

        public IFormBuilder AddFormText(TextBox box, string labelName)
        {
            FormTextField textField = new FormTextField
            {
                ControlLabel = new Label { Text = labelName },
                ControlTextBox = box
            };
            textFields.Add(textField);
            return this;
        }


        public Panel Build()
        {
            PanelSet panelSet = new PanelSet();
            
            main = panelSet.CreateFLPanelControls("main", new Size(468, 452), new Point(335, 0), 1, SystemColors.ButtonHighlight);
            foreach (var button in buttons)
            {
                main.Controls.Add(button);
            }
            TableLayoutPanel tlb = panelSet.CreateTLP("tlb", textFields);
            main.Controls.Add(tlb);

            

            return main;
        }

        public IFormBuilder AddButton(Button button)
        {
            buttons.Add(button);
            return this;
        }

        public IFormBuilder CreateFLP(string name, int tabIndex)
        {
            throw new NotImplementedException();
        }
    }
}
