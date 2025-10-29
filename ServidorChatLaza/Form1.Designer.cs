namespace ServidorChatLaza
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            entradaTextbox = new TextBox();
            mostrarTextbox = new TextBox();
            IPtextbox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(556, 327);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "OBTENER IP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // entradaTextbox
            // 
            entradaTextbox.Location = new Point(153, 197);
            entradaTextbox.Multiline = true;
            entradaTextbox.Name = "entradaTextbox";
            entradaTextbox.Size = new Size(497, 34);
            entradaTextbox.TabIndex = 8;
            entradaTextbox.Click += button1_Click;
            entradaTextbox.TextChanged += entradaTextbox_TextChanged;
            entradaTextbox.KeyDown += entradaTextBox_KeyDown;
            // 
            // mostrarTextbox
            // 
            mostrarTextbox.Location = new Point(153, 62);
            mostrarTextbox.Multiline = true;
            mostrarTextbox.Name = "mostrarTextbox";
            mostrarTextbox.ReadOnly = true;
            mostrarTextbox.Size = new Size(497, 103);
            mostrarTextbox.TabIndex = 9;
            // 
            // IPtextbox
            // 
            IPtextbox.Location = new Point(153, 327);
            IPtextbox.Name = "IPtextbox";
            IPtextbox.Size = new Size(123, 27);
            IPtextbox.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 450);
            Controls.Add(IPtextbox);
            Controls.Add(mostrarTextbox);
            Controls.Add(entradaTextbox);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Servidor";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox entradaTextbox;
        private TextBox mostrarTextbox;
        private TextBox IPtextbox;
    }
}
