namespace Calculator.UI.WinApp
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Calculation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_OperationResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Argument2 = new System.Windows.Forms.TextBox();
            this.txt_Argument1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list_OperationTypes = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_OperationDescriptionListBox = new System.Windows.Forms.Button();
            this.list_OperationDescriptions = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(337, 236);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_Calculation);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_OperationResult);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_Argument2);
            this.tabPage1.Controls.Add(this.txt_Argument1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.list_OperationTypes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(329, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расчет";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Calculation
            // 
            this.btn_Calculation.Location = new System.Drawing.Point(127, 181);
            this.btn_Calculation.Name = "btn_Calculation";
            this.btn_Calculation.Size = new System.Drawing.Size(75, 23);
            this.btn_Calculation.TabIndex = 17;
            this.btn_Calculation.Text = "Рассчитать";
            this.btn_Calculation.UseVisualStyleBackColor = true;
            this.btn_Calculation.Click += new System.EventHandler(this.btn_Calculation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Результат";
            // 
            // txt_OperationResult
            // 
            this.txt_OperationResult.Location = new System.Drawing.Point(127, 116);
            this.txt_OperationResult.Name = "txt_OperationResult";
            this.txt_OperationResult.ReadOnly = true;
            this.txt_OperationResult.Size = new System.Drawing.Size(198, 20);
            this.txt_OperationResult.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Второй аргумент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Первый аргумент";
            // 
            // txt_Argument2
            // 
            this.txt_Argument2.Location = new System.Drawing.Point(127, 81);
            this.txt_Argument2.Name = "txt_Argument2";
            this.txt_Argument2.Size = new System.Drawing.Size(198, 20);
            this.txt_Argument2.TabIndex = 12;
            // 
            // txt_Argument1
            // 
            this.txt_Argument1.Location = new System.Drawing.Point(127, 46);
            this.txt_Argument1.Name = "txt_Argument1";
            this.txt_Argument1.Size = new System.Drawing.Size(198, 20);
            this.txt_Argument1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Тип операции";
            // 
            // list_OperationTypes
            // 
            this.list_OperationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_OperationTypes.FormattingEnabled = true;
            this.list_OperationTypes.Location = new System.Drawing.Point(127, 10);
            this.list_OperationTypes.Name = "list_OperationTypes";
            this.list_OperationTypes.Size = new System.Drawing.Size(121, 21);
            this.list_OperationTypes.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_OperationDescriptionListBox);
            this.tabPage2.Controls.Add(this.list_OperationDescriptions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(329, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "История";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_OperationDescriptionListBox
            // 
            this.btn_OperationDescriptionListBox.Location = new System.Drawing.Point(124, 181);
            this.btn_OperationDescriptionListBox.Name = "btn_OperationDescriptionListBox";
            this.btn_OperationDescriptionListBox.Size = new System.Drawing.Size(75, 23);
            this.btn_OperationDescriptionListBox.TabIndex = 1;
            this.btn_OperationDescriptionListBox.Text = "Показать";
            this.btn_OperationDescriptionListBox.UseVisualStyleBackColor = true;
            this.btn_OperationDescriptionListBox.Click += new System.EventHandler(this.btn_OperationDescriptionListBox_Click);
            // 
            // list_OperationDescriptions
            // 
            this.list_OperationDescriptions.FormattingEnabled = true;
            this.list_OperationDescriptions.Location = new System.Drawing.Point(7, 7);
            this.list_OperationDescriptions.Name = "list_OperationDescriptions";
            this.list_OperationDescriptions.Size = new System.Drawing.Size(316, 95);
            this.list_OperationDescriptions.TabIndex = 0;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "CalculatorForm";
            this.Text = "CalculatorForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_Calculation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_OperationResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Argument2;
        private System.Windows.Forms.TextBox txt_Argument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox list_OperationTypes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_OperationDescriptionListBox;
        private System.Windows.Forms.ListBox list_OperationDescriptions;
    }
}