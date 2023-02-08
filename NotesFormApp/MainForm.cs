using System.ComponentModel;
using NotesFormApp.Classes;
using NotesFormApp.Extensions;
using NotesFormApp.Models;
using TaskDialogLibrary;

namespace NotesFormApp
{
    public partial class MainForm : Form
    {
        private BindingList<Note> _bindingList;
        private readonly BindingSource _bindingSource = new ();
        private List<Category> _categories;
        public MainForm()
        {
            InitializeComponent();

            NotesDataGridView.AutoGenerateColumns = false;
            BogusOperations.SimpleText();
        }

        private async void CreatePopulateButton_Click(object sender, EventArgs e)
        {
            if (!Dialogs.Question(CreatePopulateButton, "Selecting Yes will recreate the database, continue?")) return;

            CreatePopulateButton.Enabled = false;
            await Task.Run(async () => { await SetupDatabase.Initialize(); });
            CreatePopulateButton.Enabled = true;
        }

        private async void LoadCategoriesButton_Click(object sender, EventArgs e)
        {
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            List<Category> list = new List<Category>();
            await Task.Run(async () => { list = await DataOperations.ReadCategories(); });

            CategoriesComboBox.DataSource = list;
            _categories = list;
        }

        private async void LoadNotesButton_Click(object sender, EventArgs e)
        {
            await LoadNotes();
        }

        private async Task LoadNotes()
        {
            Category category = (Category)CategoriesComboBox.SelectedItem;

            await Task.Run(async () =>
            {
                _bindingList = new BindingList<Note>(await DataOperations.ReadNotes(category.CategoryId));
            });

            _bindingSource.DataSource = _bindingList;
            NotesDataGridView.DataSource = _bindingSource;
            NotesDataGridView.ExpandColumns();
        }
        /// <summary>
        /// Add new note but not to the database
        /// </summary>
        private void MockedAddNoteButton_Click(object sender, EventArgs e)
        {
            _bindingList.Add(new Note() {CategoryId = 1, BodyText = "New", Completed = false, DueDate = DateTime.Now});
            _bindingSource.MoveLast();
            Note note = _bindingList[_bindingSource.Position];
            MessageBox.Show($"{note.BodyText}");
        }

        /// <summary>
        /// Add a mocked note to the database
        /// </summary>
        private void AddOneNoteButton_Click(object sender, EventArgs e)
        {
            DataOperations.MockAdd();
        }

        /// <summary>
        /// Edit current note
        /// </summary>
        private async void EditCurrentButton_Click(object sender, EventArgs e)
        {
            if (CategoriesComboBox.DataSource is null)
            {
                await LoadCategories();
            }

            if (_bindingSource.DataSource is null)
            {
                await LoadNotes();
            }

            using var form = new EditorForm(_bindingList[_bindingSource.Position], _categories);
            form.PassNote += FormOnPassNote;
            form.ShowDialog();
        }

        /// <summary>
        /// Event triggered when in the editor form with a valid save after validating is done.
        /// </summary>
        /// <param name="note"></param>
        private void FormOnPassNote(Note note)
        {

            if (DataOperations.Update(note))
            {
                _bindingList[_bindingSource.Position] = note;
                /*
                 * Rather than check if the category changed for the note,
                 * force the change even if no change.
                 */
                CategoriesComboBox.SelectedIndex = CategoriesComboBox.FindString(note.Category.CategoryName);

                /*
                 * This reflects the changes made to the DataGridView.
                 */
                _bindingSource.ResetCurrentItem();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}