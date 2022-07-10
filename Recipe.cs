using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04
{
    /// <summary>
    /// Class <c>Recipe</c> constitutes a user-defined recipe.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class provides fields for storing recipe information, and methods
    /// for storing, retrieving and manipulating recipe data.
    /// </para>
    /// <para>
    /// The class is independent from the GUI.
    /// </para>
    /// </remarks>
    public class Recipe
    {
        private string name;
        private string oldName;
        private FoodCategories category;
        private string description;
        private string[] ingredientList;
        private int numOfIngredients;
        private int maxNumberOfIngredients;

        // Constructor for the class, executes when a new instance is created
        // Initializes the fields with default values
        public Recipe(int maxNumberOfIngredients)
        {
            name = string.Empty;
            oldName = string.Empty;
            category = FoodCategories.Other;
            description = string.Empty;
            ingredientList = new string[maxNumberOfIngredients];
            numOfIngredients = 0;
            this.maxNumberOfIngredients = maxNumberOfIngredients;
        }

        // Creates a property for accessing the field "name"
        public string Name
        {
            get { return name; }
            set
            {
                // Avoids setting an invalid value
                if (value.Trim().Length == 0 || value == null) return;
                name = value;
            }
        }

        public string OldName
        {
            get { return oldName; }
            set { oldName = value; }
        }

        public FoodCategories Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string[] IngredientList
        {
            get { return ingredientList; }
            set { ingredientList = value; }
        }

        public int NumberOfIngredients
        {
            get { return numOfIngredients;}
            set 
            {
                if (value < 0) //TODO: Program will crash if exception is not handled
                    throw new ArgumentException("The number of ingredients must be positive.");
                numOfIngredients = value; 
            }
        }

        public int MaxNumberOfIngredients
        {
            // Omitting the set accessor will make the property read-only
            get { return maxNumberOfIngredients;}
        }

        // Returns an ingredient string from the array
        public string GetIngredientAtIndex(int index)
        {
            if (CheckIndex(index)) return ingredientList[index];
            else return "[I'm not an ingredient]";
        }

        // Returns true if index is within the currently stored number of ingredients
        public bool CheckIndex(int index)
        {
            return (index >= 0) && (index < numOfIngredients);
        }

        // Inserts an ingredient string into the array and updates the number of ingredients
        public void AddIngredient(string ingredient)
        {
            if (numOfIngredients < ingredientList.Length)
            {
                ingredientList[numOfIngredients] = ingredient;
                numOfIngredients++;
            }
        }

        // Removes an ingredient from the array (by overwrite)
        public bool RemoveIngredientAt(int index)
        {
            if (CheckIndex(index))
            {
                //TODO: Use null instead of an empty string
                //TODO: Using a string was good for debugging and understanding the procedure though
                ingredientList[index] = string.Empty;
                numOfIngredients--;
                MoveElementsOneStepToLeft(index);
                return true;
            }
            else return false;
        }

        // Moves all elements one step up the array, starting from the provided index + 1,
        // filling the supposed blank slot at the provided index
        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index + 1; i < ingredientList.Length; i++)
            {
                ingredientList[i-1] = ingredientList[i]; // Move 1 step to left
                ingredientList[i] = string.Empty; //TODO: Use null instead
            }
        }

        // Overwrites the ingredient string at the provided index
        // Returns true if successful
        internal bool ChangeIngredientAt(int editingIndex, string newName)
        {
            if (CheckIndex(editingIndex))
            {
                ingredientList[editingIndex] = newName;
                return true;
            }
            else return false;
        }

        // Reinstantiates the ingredient array and resets the item counter
        public void ClearIngredientList()
        {
            ingredientList = new string[maxNumberOfIngredients];
            numOfIngredients = 0;
        }
    }
}
