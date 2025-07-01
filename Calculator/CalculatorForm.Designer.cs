using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox displayTextBox;
        private Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnAdd, btnSubtract, btnMultiply, btnDivide;
        private Button btnEquals, btnClear, btnDecimal;

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
            this.displayTextBox = new TextBox();
            this.btn0 = new Button();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btnAdd = new Button();
            this.btnSubtract = new Button();
            this.btnMultiply = new Button();
            this.btnDivide = new Button();
            this.btnEquals = new Button();
            this.btnClear = new Button();
            this.btnDecimal = new Button();
            this.SuspendLayout();

            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new Point(12, 12);
            this.displayTextBox.Size = new Size(260, 30);
            this.displayTextBox.Font = new Font("Microsoft Sans Serif", 14F);
            this.displayTextBox.TextAlign = HorizontalAlignment.Right;
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Text = "0";
            this.displayTextBox.TabIndex = 0;

            // 
            // Number buttons
            // 
            this.btn7.Location = new Point(12, 60);
            this.btn7.Size = new Size(60, 40);
            this.btn7.Text = "7";
            this.btn7.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new EventHandler(this.NumberButton_Click);

            this.btn8.Location = new Point(77, 60);
            this.btn8.Size = new Size(60, 40);
            this.btn8.Text = "8";
            this.btn8.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new EventHandler(this.NumberButton_Click);

            this.btn9.Location = new Point(142, 60);
            this.btn9.Size = new Size(60, 40);
            this.btn9.Text = "9";
            this.btn9.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new EventHandler(this.NumberButton_Click);

            this.btn4.Location = new Point(12, 105);
            this.btn4.Size = new Size(60, 40);
            this.btn4.Text = "4";
            this.btn4.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new EventHandler(this.NumberButton_Click);

            this.btn5.Location = new Point(77, 105);
            this.btn5.Size = new Size(60, 40);
            this.btn5.Text = "5";
            this.btn5.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new EventHandler(this.NumberButton_Click);

            this.btn6.Location = new Point(142, 105);
            this.btn6.Size = new Size(60, 40);
            this.btn6.Text = "6";
            this.btn6.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new EventHandler(this.NumberButton_Click);

            this.btn1.Location = new Point(12, 150);
            this.btn1.Size = new Size(60, 40);
            this.btn1.Text = "1";
            this.btn1.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new EventHandler(this.NumberButton_Click);

            this.btn2.Location = new Point(77, 150);
            this.btn2.Size = new Size(60, 40);
            this.btn2.Text = "2";
            this.btn2.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new EventHandler(this.NumberButton_Click);

            this.btn3.Location = new Point(142, 150);
            this.btn3.Size = new Size(60, 40);
            this.btn3.Text = "3";
            this.btn3.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new EventHandler(this.NumberButton_Click);

            this.btn0.Location = new Point(12, 195);
            this.btn0.Size = new Size(125, 40);
            this.btn0.Text = "0";
            this.btn0.Font = new Font("Microsoft Sans Serif", 12F);
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new EventHandler(this.NumberButton_Click);

            // 
            // Operation buttons
            // 
            this.btnDivide.Location = new Point(207, 60);
            this.btnDivide.Size = new Size(60, 40);
            this.btnDivide.Text = "÷";
            this.btnDivide.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new EventHandler(this.OperationButton_Click);

            this.btnMultiply.Location = new Point(207, 105);
            this.btnMultiply.Size = new Size(60, 40);
            this.btnMultiply.Text = "×";
            this.btnMultiply.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new EventHandler(this.OperationButton_Click);

            this.btnSubtract.Location = new Point(207, 150);
            this.btnSubtract.Size = new Size(60, 40);
            this.btnSubtract.Text = "-";
            this.btnSubtract.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new EventHandler(this.OperationButton_Click);

            this.btnAdd.Location = new Point(207, 195);
            this.btnAdd.Size = new Size(60, 40);
            this.btnAdd.Text = "+";
            this.btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.OperationButton_Click);

            // 
            // Function buttons
            // 
            this.btnClear.Location = new Point(207, 240);
            this.btnClear.Size = new Size(60, 40);
            this.btnClear.Text = "C";
            this.btnClear.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.ClearButton_Click);

            this.btnDecimal.Location = new Point(142, 195);
            this.btnDecimal.Size = new Size(60, 40);
            this.btnDecimal.Text = ".";
            this.btnDecimal.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnDecimal.UseVisualStyleBackColor = true;
            this.btnDecimal.Click += new EventHandler(this.DecimalButton_Click);

            this.btnEquals.Location = new Point(12, 240);
            this.btnEquals.Size = new Size(190, 40);
            this.btnEquals.Text = "=";
            this.btnEquals.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnEquals.UseVisualStyleBackColor = true;
            this.btnEquals.Click += new EventHandler(this.EqualsButton_Click);

            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(284, 291);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecimal);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Calculator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}