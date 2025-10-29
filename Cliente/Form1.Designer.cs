namespace Cliente
{
    partial class Form1
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
            entradaTextbox = new TextBox();
            mostrarTextbox = new TextBox();
            button1 = new Button();
            IPtextbox = new TextBox();
            SuspendLayout();
            // 
            // entradaTextbox
            // 
            entradaTextbox.Location = new Point(148, 316);
            entradaTextbox.Name = "entradaTextbox";
            entradaTextbox.Size = new Size(464, 27);
            entradaTextbox.TabIndex = 0;
            entradaTextbox.TextChanged += entradaTextbox_TextChanged;
            entradaTextbox.KeyDown += entradaTextBox_KeyDown;
            // 
            // mostrarTextbox
            // 
            mostrarTextbox.Location = new Point(148, 66);
            mostrarTextbox.Multiline = true;
            mostrarTextbox.Name = "mostrarTextbox";
            mostrarTextbox.ReadOnly = true;
            mostrarTextbox.Size = new Size(464, 203);
            mostrarTextbox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(518, 383);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "CONECTAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // IPtextbox
            // 
            IPtextbox.Location = new Point(148, 383);
            IPtextbox.Name = "IPtextbox";
            IPtextbox.Size = new Size(125, 27);
            IPtextbox.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(IPtextbox);
            Controls.Add(button1);
            Controls.Add(mostrarTextbox);
            Controls.Add(entradaTextbox);
            Name = "Form1";
            Text = "Cliente";
            Load += Form1_Load;
            KeyDown += entradaTextBox_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox entradaTextbox;
        private TextBox mostrarTextbox;
        private Button button1;
        private TextBox IPtextbox;
    }
}
