using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_04
{
    /// <summary>
    /// Partial class <c>FormIngredients</c> provides a GUI window which allows the user to edit the ingredient list.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for user interaction, validating user input, 
    /// displaying data and error messages.
    /// </para>
    /// <para>
    /// This class holds a working-copy of the recipe currently being edited/added by the user.
    /// The reference to that object is provided through the constructor parameter.
    /// </para>
    /// </remarks>
    public partial class FormIngredients: Form
    {
        private Recipe currentRecipe;
        private string[] backupList;
        private int editingIndex;
        private bool editMode = false;

        // Constructor for the class, executes when a new instance is created
        public FormIngredients(Recipe recipe)
        {
            this.currentRecipe = recipe;
            backupList = new string[recipe.NumberOfIngredients];

            InitializeComponent();
            InitializeGUI();
            BackupIngredientList(); // Backup for reverting the list if Cancel button is pressed
        }

        // Initial setup of the GUI
        private void InitializeGUI()
        {
            txtEdit.Visible = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            FillIngredientList();
            UpdateIngredientsCounter();
        }

        // Populates the ingredient list with items from the recipe working-copy
        private void FillIngredientList()
        {
            lstIngredients.Items.Clear();

            for (int i = 0; i < currentRecipe.NumberOfIngredients; i++)
                lstIngredients.Items.Add(currentRecipe.GetIngredientAtIndex(i));
        }

        // Creates a backup of the initial ingredient list
        private void BackupIngredientList()
        {
            for (int i = 0; i < currentRecipe.NumberOfIngredients; i++)
                backupList[i] = currentRecipe.GetIngredientAtIndex(i);
        }
        
        // Overwrites the recipe object's ingredient list with the initial / backup version
        private void RevertIngredientList()
        {
            currentRecipe.ClearIngredientList();

            if (backupList.Length > 0)
            {
                for (int i = 0; i < backupList.Length; i++)
                    currentRecipe.AddIngredient(backupList[i]);
            }
        }

        // Executes when text is changed in the ingredient textbox
        // Enables the Add button only if validated text is present
        private void txtIngredient_TextChanged(object sender, EventArgs e)
        {
            if (TextInputValid(txtIngredient.Text))
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        // Returns true if string is not empty / only spaces / null
        // TODO: Put this method in a separate utility class with public access
        private bool TextInputValid(string str)
        {
            if (str.Trim().Length != 0 && str != null) 
                return true;
            else 
                return false;
        }

        // Executes when the list's selected index changes / the user selects an element
        // Enables the relevant buttons
        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        // Figures out where to move the textbox for editing an item, and moves it
        private void MoveEditBoxToFocusedItem()
        {
            Point listPosition = lstIngredients.Location;
            int y = lstIngredients.ItemHeight * lstIngredients.SelectedIndex;
            txtEdit.Location = listPosition;
            txtEdit.Top += y + 2; // Some minor adjustment needed to get it right
            txtEdit.Left += 2;
        }

        // Configures the GUI for editing an ingredient
        private void EnterEditMode()
        {
            editMode = true;
            //lstIngredients.BackColor = Color.White;
            editingIndex = lstIngredients.SelectedIndex;
            txtEdit.Text = lstIngredients.Items[editingIndex].ToString();
            btnEdit.Enabled = false;
            txtEdit.Visible = true;
            txtEdit.Focus();
        }

        // Updates the label showing the number of ingredients
        private void UpdateIngredientsCounter()
        {
            string counter = String.Format("{0, 23} {1, 4}", "Number of ingredients:", 
                currentRecipe.NumberOfIngredients.ToString());
            lblIngredientsCount.Text = counter;
        }

        // Executes when the Enter key is pressed in the edit textbox
        private void txtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                if (txtEdit.Text.Trim().Length > 0)
                {
                    // Attempts to update the recipe object and the GUI with the user-provided new text
                    bool ok = currentRecipe.ChangeIngredientAt(editingIndex, txtEdit.Text);
                    if (ok) lstIngredients.Items[editingIndex] = txtEdit.Text;
                    ExitEditMode();
                }
                else ExitEditMode(); // No text was entered
            }
        }

        // Configures the GUI to leave edit mode
        private void ExitEditMode()
        {
            editMode = false;
            //lstIngredients.BackColor = Color.White;
            txtEdit.Visible = false;
            btnEdit.Enabled = true;
            lstIngredients.Focus();
        }

        // Executes when the Enter key is pressed in the ingredient textbox
        // Enables adding of items by pressing Enter
        private void txtIngredient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(sender, EventArgs.Empty);
        }

        // Executes when the ingredient textbox is focused
        private void txtIngredient_Enter(object sender, EventArgs e)
        {
            lstIngredients.ClearSelected();

            // Disable buttons no longer relevant
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        // Executes when the edit textbox is unfocused
        private void txtEdit_Leave(object sender, EventArgs e)
        {
            ExitEditMode();
        }

        // Executes when the Add button is clicked
        // Makes sure that the maximum number of ingredients is not exceeded
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstIngredients.Items.Count < currentRecipe.MaxNumberOfIngredients)
            {
                if (TextInputValid(txtIngredient.Text))
                {
                    string ingredient = txtIngredient.Text.Trim();
                    currentRecipe.AddIngredient(ingredient); // Add ingredient to the recipe working-copy
                    lstIngredients.Items.Add(ingredient); // Add ingredient to GUI
                    UpdateIngredientsCounter();
                    txtIngredient.Focus();
                    txtIngredient.SelectAll();
                }
                else
                {
                    txtIngredient.ResetText();
                    txtIngredient.Focus();
                }
            }
            else MessageBox.Show("Max number of ingredients reached.", "List is full");
        }

        // Executes when the Edit button is clicked
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MoveEditBoxToFocusedItem();
            EnterEditMode();
        }

        // Executes when the Delete button is clicked
        // Removes the ingredient from GUI, if removal from the recipe working-copy succeeded
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (editMode) ExitEditMode();

            bool ok = currentRecipe.RemoveIngredientAt(lstIngredients.SelectedIndex);

            if (ok) lstIngredients.Items.RemoveAt(lstIngredients.SelectedIndex);

            UpdateIngredientsCounter();
            
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        // Executes when the OK button is clicked
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Executes when the Cancel button is clicked
        // Discards any changes made to the ingredients list before closing the window
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirmCancel = 
                MessageBox.Show("Any changes will be lost!", "Warning", 
                MessageBoxButtons.OKCancel);

            if (confirmCancel == DialogResult.OK)
            {
                RevertIngredientList();
                this.Dispose();
            }
        }

    }
}
