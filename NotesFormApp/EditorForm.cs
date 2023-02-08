using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation.Results;
using NotesFormApp.Classes;
using NotesFormApp.Models;

namespace NotesFormApp
{
    public partial class EditorForm : Form
    {
        public delegate void OnPassingNote(Note note);
        public event OnPassingNote PassNote;

        private readonly Note _note;
        private readonly List<Category> _categories;
        private NoteValidator _noteValidator = new ();

        public EditorForm()
        {
            InitializeComponent();
        }
        public EditorForm(Note note, List<Category> categories)
        {
            InitializeComponent();
   
            _note = note;
            _categories = categories;
  
            Shown += EditorForm_Shown;
        }

        /// <summary>
        /// Sadly data-binding is a bust with nullable types and not
        /// interested in a complex fix so everything is manually set values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditorForm_Shown(object sender, EventArgs e)
        {
            Note note = _note;
            IdentifierLabel.Text = note.NoteId.ToString();
            CategoryComboBox.DataSource = _categories;
            CategoryComboBox.SelectedIndex = CategoryComboBox.FindString(note.Category.CategoryName);
            DueDateDateTimePicker.Value = note!.DueDate.Value;
            BodyTextTextBox.Text = note.BodyText;
            CompletetedCheckBox.Checked = note?.Completed == true;
        }

        /// <summary>
        /// Using <see cref="FluentValidation"/> instead Data-Annotations while ASP/Razor can use either or.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            _note.DueDate = DueDateDateTimePicker.Value;
            _note.CategoryId = ((Category)CategoryComboBox.SelectedItem).CategoryId;
            _note.Category = (Category)CategoryComboBox.SelectedItem;
            _note.Completed = CompletetedCheckBox.Checked;
            _note.BodyText = BodyTextTextBox.Text;

            _noteValidator = new();
            ValidationResult result = _noteValidator.Validate(_note);
            if (result.IsValid)
            {
                PassNote?.Invoke(_note);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(result.PresentErrorMessage());
            }

        }
    }
}
