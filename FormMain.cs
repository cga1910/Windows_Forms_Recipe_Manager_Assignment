using static System.Windows.Forms.ListBox;

namespace Assignment_04
{
    /// <summary>
    /// Partial class <c>FormMain</c> provides the main GUI window.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is responsible for user interaction, validating user input, 
    /// formatting and displaying data and error messages.
    /// </para>
    /// <para>
    /// This class holds a working-copy of the recipe currently being edited/added by the user.
    /// </para>
    /// </remarks>
    public partial class FormMain : Form
    {
        private RecipeManager recipeManager;
        private Recipe currentRecipe;

        private const int maxNumberOfRecipes = 20;
        private const int maxNumberOfIngredients = 50;

        private bool editMode = false;

        // Constructor for the class, executes when a new instance is created
        public FormMain()
        {
            recipeManager = new RecipeManager(maxNumberOfRecipes);
            currentRecipe = new Recipe(maxNumberOfIngredients);

            InitializeComponent(); // Instantiates form objects and adds controls etc.
            InitializeGUI(); // Initializes GUI with default values
        }

        // Initial setup of the GUI
        private void InitializeGUI()
        {
            InitializeCategoryComboBox();
        }

        // Fills the combobox with the available food categories
        private void InitializeCategoryComboBox()
        {
            int enumLength = Enum.GetNames(typeof(FoodCategories)).Length;

            for (int i = 0; i < enumLength; i++)
                cmbCategory.Items.Add(Enum.GetValues(typeof(FoodCategories)).GetValue(i));
        }


        // RECIPE EDIT-BOX METHODS -------------------------------------------------

        // Executes when the Add Ingredients button is clicked
        // Opens a new window for editing the ingredient list
        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            FormIngredients formIngredients = new FormIngredients(currentRecipe);

            // Interaction with parent form is disabled when using .ShowDialog()
            DialogResult dialogResult = formIngredients.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (currentRecipe.NumberOfIngredients <= 0)
                    MessageBox.Show("No ingredients specified", "Info");
            }
        }

        // Initiates reading of input fields; tries to add recipe to list
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            bool isRecipeRead = ReadRecipeInputFields();
            string outcome;

            if (isRecipeRead)
            {
                bool isRecipeAdded = recipeManager.AddRecipe(currentRecipe, out outcome);

                if (isRecipeAdded)
                {
                    FinishEditMode();
                    lstRecipes.SelectedIndex = recipeManager.NumOfElements - 1;
                }
                else if (outcome == "occupied")
                    MessageBox.Show("Recipe name is already in use, please try another name.");
                else if (outcome == "full")
                    MessageBox.Show("Recipe list is full, try removing a recipe.");
            }
        }

        // Initiates checking and reading of recipe information from GUI
        // Stores data and returns true if all input validated successfully
        private bool ReadRecipeInputFields()
        {
            string recipeName;
            FoodCategories recipeCategory;
            string recipeDescription;

            if (ReadRecipeName(out recipeName))
            {
                if (ReadRecipeCategory(out recipeCategory))
                {
                    if (ReadRecipeDescription(out recipeDescription))
                    {
                        currentRecipe.Name = recipeName;
                        currentRecipe.Category = recipeCategory;
                        currentRecipe.Description = recipeDescription;
                        return true;
                    }
                }
            }
            return false;
        }

        // Reads user-provided recipe name from GUI
        // Returns true if name validated successfully
        private bool ReadRecipeName(out string recipeName)
        {
            if (TextInputValid(txtRecipeName.Text))
            {
                recipeName = txtRecipeName.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.", "Missing data");
                recipeName = string.Empty;
                txtRecipeName.Focus();
                return false;
            }
        }

        // Reads user-selected recipe category from GUI
        // Returns true if category validated successfully
        private bool ReadRecipeCategory(out FoodCategories recipeCategory)
        {
            if (cmbCategory.SelectedItem != null)
            {
                recipeCategory = (FoodCategories)cmbCategory.SelectedItem;
                return true;
            }
            else
            {
                MessageBox.Show("Please select a food category for the recipe.", "Missing data");
                recipeCategory = FoodCategories.Other;
                cmbCategory.Focus();
                return false;
            }
            
        }

        // Reads user-provided recipe description from GUI
        // Returns true if the description validated successfully
        private bool ReadRecipeDescription(out string recipeDescription)
        {
            if (TextInputValid(txtRecipeDescription.Text))
            {
                recipeDescription = txtRecipeDescription.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Your recipe will be saved without a description.", "Missing data");
                recipeDescription = string.Empty;
                txtRecipeName.Focus();
                //return false;
                return true;
            }
        }

        // Returns true if string is not empty / only spaces / null
        // TODO: Put this method in a utility class with public access
        private bool TextInputValid(string str)
        {
            if (str.Trim().Length != 0 && str != null) return true;
            else return false;
        }


        // RECIPE LIST METHODS ------------------------------------------------

        // Executes when the Edit-Begin button is clicked
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            // Get a collection of all selected indexes of the list
            SelectedIndexCollection indexes = lstRecipes.SelectedIndices;

            if (indexes.Count > 1)
            {
                MessageBox.Show("Please select only one recipe for editing.", "I'm confused");
            }
            else if (indexes.Count == 1)
            {
                // Show confirm dialog if data is already present in input fields
                if (txtRecipeName.Text != string.Empty || txtRecipeDescription.Text != string.Empty
                    || currentRecipe.NumberOfIngredients > 0 || cmbCategory.SelectedItem != null)
                {
                    DialogResult confirmEditBegin = 
                        MessageBox.Show("Any changes made in the currently loaded recipe will be lost.", "Warning",
                        MessageBoxButtons.OKCancel);

                    if (confirmEditBegin == DialogResult.Cancel) return;
                }
                BeginEditMode(indexes[0]);
            }
        }

        // Loads the recipe to be edited, saves its name, configures the GUI for recipe editing
        private void BeginEditMode(int index)
        {
            Recipe oldRecipe = recipeManager.GetRecipeAtIndex(index);

            CopyRecipeToNewCurrentRecipe(oldRecipe);

            // Keep the old name for later reference
            currentRecipe.OldName = oldRecipe.Name;

            FillInputs(currentRecipe);

            // Configure the GUI for edit mode
            btnEditFinish.Enabled = true;
            groupboxAddOrEdit.Text = "Edit recipe";

            editMode = true;
        }

        // Updates the current (working-copy) recipe with data from the object to be edited
        private void CopyRecipeToNewCurrentRecipe(Recipe oldRecipe)
        {            
            currentRecipe = new Recipe(maxNumberOfIngredients)
            {
                Name = oldRecipe.Name,
                Category = oldRecipe.Category,
                Description = oldRecipe.Description,
                IngredientList = oldRecipe.IngredientList,
                NumberOfIngredients = oldRecipe.NumberOfIngredients
            };
        }

        // Reads recipe data and updates the GUI input fields
        private void FillInputs(Recipe recipe)
        {
            txtRecipeName.Text = recipe.Name;
            cmbCategory.SelectedIndex = (int)recipe.Category;
            txtRecipeDescription.Text = recipe.Description;
        }

        // Attempts to change or add the edited recipe, if there wasn't a name conflict
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            bool isNameOccupied;
            string oldName = currentRecipe.OldName; // Will be used to find the correct recipe when updating
            string currentName = txtRecipeName.Text;

            if (oldName != currentName) // If the recipe name was changed
            {
                // Check that the new name is not already used by another recipe
                isNameOccupied = recipeManager.IsNameOccupied(currentName);

                if (isNameOccupied)
                {
                    MessageBox.Show("Name is already in use.", "Error");
                    return;
                }
            }

            if (ReadRecipeInputFields())
            {
                // Change the recipe; find it by the name it had when editing began
                bool ok = recipeManager.ChangeElement(oldName, currentRecipe);

                // If it couldn't be found (maybe it was deleted during edit), add as new recipe instead
                if (!ok) btnAddRecipe_Click(sender, EventArgs.Empty);
            }
            else return;

            FinishEditMode();
        }

        // Attempts to delete all selected recipes
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SelectedIndexCollection indexes = lstRecipes.SelectedIndices;

            bool ok = recipeManager.DeleteElements(indexes);

            if (!ok) MessageBox.Show("Deletion failed somehow.", "Program error");

            UpdateRecipeList();
        }

        // Executes when the Clear Selection button is clicked
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            lstRecipes.ClearSelected();
            if (editMode) FinishEditMode();
        }

        // Displays a summary of the recipe
        private void lstRecipes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstRecipes.SelectedIndex;

            string recipeName = recipeManager.GetRecipeAtIndex(index).Name;
            string recipeDescription = recipeManager.GetRecipeAtIndex(index).Description;
            string[] ingredientList = recipeManager.GetRecipeAtIndex(index).IngredientList;
            string ingredients = "";

            foreach (string ingredient in ingredientList) ingredients += ingredient;

            string recipeInfo = $"INGREDIENTS\n {ingredients}\n\n" + recipeDescription;

            MessageBox.Show(recipeInfo, recipeName);
        }

        // Reads recipe data and displays it in the GUI listbox
        private void UpdateRecipeList()
        {
            Recipe recipe;
            string format = "{0, -31} {1, -23} {2, 2}";
            string recipeRow;

            lstRecipes.Items.Clear();

            for (int index = 0; index < recipeManager.NumOfElements; index++)
            {
                recipe = recipeManager.GetRecipeAtIndex(index);

                if (recipe != null)
                {
                    recipeRow = string.Format(format,
                        recipe.Name,
                        recipe.Category,
                        recipe.NumberOfIngredients);
                }
                else
                    recipeRow = "Error reading recipe";

                lstRecipes.Items.Add(recipeRow);
            }
        }
        // Updates GUI efter recipe editing
        private void FinishEditMode()
        {
            UpdateListAndResetRecipe();

            groupboxAddOrEdit.Text = "Add new recipe";
            btnEditFinish.Enabled = false;

            editMode = false;
        }

        private void UpdateListAndResetRecipe()
        {
            UpdateRecipeList();
            ClearInputs();

            // Select the last edited or added recipe
            int lastEditedIndex = recipeManager.GetIndexOfRecipeByName(currentRecipe.Name);
            int lastAddedIndex  = recipeManager.NumOfElements - 1;

            if (lastEditedIndex == -1) lstRecipes.SelectedIndex = lastAddedIndex;
            else                       lstRecipes.SelectedIndex = lastEditedIndex;

            // To keep the working-copy separate, renew the object reference by reinstantiation
            currentRecipe = new Recipe(maxNumberOfIngredients);
        }

        // Clears textboxes and resets the combobox
        private void ClearInputs()
        {
            txtRecipeName.Text = string.Empty;
            cmbCategory.SelectedIndex = -1;
            txtRecipeDescription.Text = string.Empty;
        }

    }
}