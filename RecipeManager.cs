using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ListBox;

namespace Assignment_04
{
    /// <summary>
    /// Class <c>RecipeManager</c> holds an array of recipe objects, and methods to operate on the array.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class provides methods for storing, retrieving and replacing objects in the recipe list.
    /// </para>
    /// <para>
    /// The class is independent from the GUI.
    /// </para>
    /// </remarks>
    internal class RecipeManager
    {
        private Recipe[] recipeList;
        private int numOfElements = 0;
        
        // Creates a property for getting the supposed number of recipe objects in the list
        public int NumOfElements
        {
            get { return numOfElements; }
        }

        // Constructor for the class, executes when a new instance is created
        public RecipeManager(int maxNumberOfRecipes)
        {
            recipeList = new Recipe[maxNumberOfRecipes];
        }

        // Returns a recipe object reference
        public Recipe? GetRecipeAtIndex(int index)
        {
            if (CheckIndex(index)) return recipeList[index];
            else return null;
        }

        // Adds the recipe only if recipe name is unique
        // Returns true if the recipe was added
        // Sends out a one-word description of the outcome
        public bool AddRecipe(Recipe recipe, out string outcome)
        {
            if (IsNameOccupied(recipe.Name))
            {
                outcome = "occupied";
                return false; // Recipe name was occupied
            }
            else if (numOfElements < recipeList.Length)
            {
                recipeList[numOfElements] = recipe;
                numOfElements++;
                outcome = "added";
                return true;
            }
            outcome = "full"; // List was full
            return false;
        }

        // Changes the element that has a specific recipe name
        public bool ChangeElement(string recipeName, Recipe newRecipe)
        {
            int index = GetIndexOfRecipeByName(recipeName);

            if (index >= 0)
            {
                recipeList[index] = newRecipe;
                return true;
            }
            return false;
        }

        // Deletes one or several recipe objects from the list
        public bool DeleteElements(SelectedIndexCollection indexes)
        {
            int deleteQueueLength = indexes.Count;

            // Delete all selected elements
            for (int i = 0; i < deleteQueueLength; i++)
            {
                recipeList[indexes[i]] = null;
            }

            // Defragment the list
            // Repeat for the number of elements deleted
            foreach (int index in indexes)
            {
                // Go through the list and look for null (i.e. deleted elements)
                for (int i = 0; i < numOfElements; i++)
                {
                    if (recipeList[i] == null)
                    {
                        MoveElementsOneStepToLeft(i);
                        numOfElements--;
                        deleteQueueLength--; // One deletion completed
                    }
                }
            }
            if (deleteQueueLength == 0) return true;
            else return false;
        }
        
        // Moves all elements one step up the list, starting from the provided index + 1,
        // filling the supposed blank slot at the provided index
        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index + 1; i < recipeList.Length; i++)
            {
                recipeList[i - 1] = recipeList[i]; // Move 1 step to left
                recipeList[i] = null;
            }
        }

        // Returns the index of the recipe object with the specified name
        // Returns -1 if none is found
        public int GetIndexOfRecipeByName(string name)
        {
            for (int i = 0; i < numOfElements; i++)
            {
                if (recipeList[i].Name == name) return i;
            }
            return -1;
        }

        // Returns true if the specified name is found in a recipe object in the list
        public bool IsNameOccupied(string name)
        {
            if (GetIndexOfRecipeByName(name) == -1) return false;
            else return true;
        }

        // Checks that index is within the currently stored number of elements
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < numOfElements);
        }

    }
}