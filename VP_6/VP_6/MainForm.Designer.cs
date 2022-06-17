namespace VP_6
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new VP_6.DraggableLabel();
            this.label5 = new VP_6.DraggableLabel();
            this.label4 = new VP_6.DraggableLabel();
            this.label1 = new VP_6.DraggableLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(846, 282);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ElementType = VP_6.DraggableElementTypes.TraceOperator;
            this.label6.Location = new System.Drawing.Point(17, 155);
            this.label6.Matrix = null;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Trace";
            this.label6.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.labels_QueryContinueDrag);
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operationsLabel_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ElementType = VP_6.DraggableElementTypes.MultiplyOperator;
            this.label5.Location = new System.Drawing.Point(17, 109);
            this.label5.Matrix = null;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Multiply";
            this.label5.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.labels_QueryContinueDrag);
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operationsLabel_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ElementType = VP_6.DraggableElementTypes.AddOperator;
            this.label4.Location = new System.Drawing.Point(17, 61);
            this.label4.Matrix = null;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Add";
            this.label4.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.labels_QueryContinueDrag);
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.operationsLabel_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ElementType = VP_6.DraggableElementTypes.Matrix;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Matrix = null;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrix";
            this.label1.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.labels_QueryContinueDrag);
            this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labels_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labels_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labels_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labels_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 282);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labels_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "View result";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(79, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 95);
            this.panel1.TabIndex = 0;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empty";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.label2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.label2.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 282);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private DraggableLabel label5;
        private DraggableLabel label4;
        private DraggableLabel label1;
        private DraggableLabel label6;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private ErrorProvider errorProvider1;
        private Button button2;
        private Button button1;
    }
}