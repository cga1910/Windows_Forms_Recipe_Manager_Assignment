namespace Assignment_04
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupboxAddOrEdit = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.txtRecipeDescription = new System.Windows.Forms.TextBox();
            this.btnAddIngredients = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstRecipes = new System.Windows.Forms.ListBox();
            this.btnEditBegin = new System.Windows.Forms.Button();
            this.btnEditFinish = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.groupboxAddOrEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxAddOrEdit
            // 
            this.groupboxAddOrEdit.Controls.Add(this.btnAddRecipe);
            this.groupboxAddOrEdit.Controls.Add(this.txtRecipeDescription);
            this.groupboxAddOrEdit.Controls.Add(this.btnAddIngredients);
            this.groupboxAddOrEdit.Controls.Add(this.cmbCategory);
            this.groupboxAddOrEdit.Controls.Add(this.label2);
            this.groupboxAddOrEdit.Controls.Add(this.txtRecipeName);
            this.groupboxAddOrEdit.Controls.Add(this.label1);
            this.groupboxAddOrEdit.Location = new System.Drawing.Point(12, 12);
            this.groupboxAddOrEdit.Name = "groupboxAddOrEdit";
            this.groupboxAddOrEdit.Size = new System.Drawing.Size(417, 444);
            this.groupboxAddOrEdit.TabIndex = 0;
            this.groupboxAddOrEdit.TabStop = false;
            this.groupboxAddOrEdit.Text = "Add new recipe";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(15, 413);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(383, 23);
            this.btnAddRecipe.TabIndex = 5;
            this.btnAddRecipe.Text = "Add Recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // txtRecipeDescription
            // 
            this.txtRecipeDescription.Location = new System.Drawing.Point(15, 96);
            this.txtRecipeDescription.Multiline = true;
            this.txtRecipeDescription.Name = "txtRecipeDescription";
            this.txtRecipeDescription.Size = new System.Drawing.Size(383, 311);
            this.txtRecipeDescription.TabIndex = 4;
            // 
            // btnAddIngredients
            // 
            this.btnAddIngredients.Location = new System.Drawing.Point(287, 61);
            this.btnAddIngredients.Name = "btnAddIngredients";
            this.btnAddIngredients.Size = new System.Drawing.Size(111, 23);
            this.btnAddIngredients.TabIndex = 3;
            this.btnAddIngredients.Text = "Add Ingredients";
            this.btnAddIngredients.UseVisualStyleBackColor = true;
            this.btnAddIngredients.Click += new System.EventHandler(this.btnAddIngredients_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(82, 61);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(189, 23);
            this.cmbCategory.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(118, 27);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(280, 23);
            this.txtRecipeName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name of recipe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(885, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "No. of ingredients";
            // 
            // lstRecipes
            // 
            this.lstRecipes.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstRecipes.FormattingEnabled = true;
            this.lstRecipes.ItemHeight = 17;
            this.lstRecipes.Location = new System.Drawing.Point(446, 42);
            this.lstRecipes.Name = "lstRecipes";
            this.lstRecipes.ScrollAlwaysVisible = true;
            this.lstRecipes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRecipes.Size = new System.Drawing.Size(547, 344);
            this.lstRecipes.TabIndex = 6;
            this.lstRecipes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstRecipes_MouseDoubleClick);
            // 
            // btnEditBegin
            // 
            this.btnEditBegin.Location = new System.Drawing.Point(446, 397);
            this.btnEditBegin.Name = "btnEditBegin";
            this.btnEditBegin.Size = new System.Drawing.Size(75, 23);
            this.btnEditBegin.TabIndex = 7;
            this.btnEditBegin.Text = "Edit-Begin";
            this.btnEditBegin.UseVisualStyleBackColor = true;
            this.btnEditBegin.Click += new System.EventHandler(this.btnEditBegin_Click);
            // 
            // btnEditFinish
            // 
            this.btnEditFinish.Enabled = false;
            this.btnEditFinish.Location = new System.Drawing.Point(527, 397);
            this.btnEditFinish.Name = "btnEditFinish";
            this.btnEditFinish.Size = new System.Drawing.Size(75, 23);
            this.btnEditFinish.TabIndex = 8;
            this.btnEditFinish.Text = "Edit-Finish";
            this.btnEditFinish.UseVisualStyleBackColor = true;
            this.btnEditFinish.Click += new System.EventHandler(this.btnEditFinish_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(804, 397);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(885, 397);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(108, 23);
            this.btnClearSelection.TabIndex = 10;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 468);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditFinish);
            this.Controls.Add(this.btnEditBegin);
            this.Controls.Add(this.lstRecipes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupboxAddOrEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apu Recipe Book by Gustav Björklind";
            this.groupboxAddOrEdit.ResumeLayout(false);
            this.groupboxAddOrEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupboxAddOrEdit;
        private Label label1;
        private TextBox txtRecipeName;
        private ComboBox cmbCategory;
        private Label label2;
        private Button btnAddIngredients;
        private TextBox txtRecipeDescription;
        private Button btnAddRecipe;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox lstRecipes;
        private Button btnEditBegin;
        private Button btnEditFinish;
        private Button btnDelete;
        private Button btnClearSelection;
    }
}