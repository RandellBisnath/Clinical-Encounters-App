namespace ClinicalEncountersApp
{
    partial class Mainform
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
            this.btnMakeNewNote = new System.Windows.Forms.Button();
            this.lstPatientNotes = new System.Windows.Forms.ListBox();
            this.lblMsgs = new System.Windows.Forms.Label();
            this.grpboxPatientInfo = new System.Windows.Forms.GroupBox();
            this.btnDeleteNote = new System.Windows.Forms.Button();
            this.btnUpdateNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lblVitals = new System.Windows.Forms.Label();
            this.lstVitals = new System.Windows.Forms.ListBox();
            this.lblProblems = new System.Windows.Forms.Label();
            this.lstProblems = new System.Windows.Forms.ListBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblNewProblem = new System.Windows.Forms.Label();
            this.txtNewProblem = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.btnDeleteProblem = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtNoteID = new System.Windows.Forms.TextBox();
            this.btnAddProblem = new System.Windows.Forms.Button();
            this.lblNoteID = new System.Windows.Forms.Label();
            this.grpboxPatientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeNewNote
            // 
            this.btnMakeNewNote.Location = new System.Drawing.Point(50, 26);
            this.btnMakeNewNote.Name = "btnMakeNewNote";
            this.btnMakeNewNote.Size = new System.Drawing.Size(119, 23);
            this.btnMakeNewNote.TabIndex = 0;
            this.btnMakeNewNote.Text = "Make New Note";
            this.btnMakeNewNote.UseVisualStyleBackColor = true;
            this.btnMakeNewNote.Click += new System.EventHandler(this.btnMakeNewNote_Click);
            // 
            // lstPatientNotes
            // 
            this.lstPatientNotes.FormattingEnabled = true;
            this.lstPatientNotes.ItemHeight = 15;
            this.lstPatientNotes.Location = new System.Drawing.Point(29, 55);
            this.lstPatientNotes.Name = "lstPatientNotes";
            this.lstPatientNotes.Size = new System.Drawing.Size(170, 439);
            this.lstPatientNotes.TabIndex = 1;
            this.lstPatientNotes.SelectedIndexChanged += new System.EventHandler(this.lstPatientNotes_SelectedIndexChanged);
            // 
            // lblMsgs
            // 
            this.lblMsgs.AutoSize = true;
            this.lblMsgs.Location = new System.Drawing.Point(29, 538);
            this.lblMsgs.Name = "lblMsgs";
            this.lblMsgs.Size = new System.Drawing.Size(35, 15);
            this.lblMsgs.TabIndex = 2;
            this.lblMsgs.Text = "Msgs";
            // 
            // grpboxPatientInfo
            // 
            this.grpboxPatientInfo.Controls.Add(this.btnDeleteNote);
            this.grpboxPatientInfo.Controls.Add(this.btnUpdateNote);
            this.grpboxPatientInfo.Controls.Add(this.btnAddNote);
            this.grpboxPatientInfo.Controls.Add(this.lblVitals);
            this.grpboxPatientInfo.Controls.Add(this.lstVitals);
            this.grpboxPatientInfo.Controls.Add(this.lblProblems);
            this.grpboxPatientInfo.Controls.Add(this.lstProblems);
            this.grpboxPatientInfo.Controls.Add(this.dtpDateOfBirth);
            this.grpboxPatientInfo.Controls.Add(this.lblNewProblem);
            this.grpboxPatientInfo.Controls.Add(this.txtNewProblem);
            this.grpboxPatientInfo.Controls.Add(this.txtPatientName);
            this.grpboxPatientInfo.Controls.Add(this.btnDeleteProblem);
            this.grpboxPatientInfo.Controls.Add(this.lblNotes);
            this.grpboxPatientInfo.Controls.Add(this.rtbNotes);
            this.grpboxPatientInfo.Controls.Add(this.lblDateOfBirth);
            this.grpboxPatientInfo.Controls.Add(this.lblPatientName);
            this.grpboxPatientInfo.Controls.Add(this.txtNoteID);
            this.grpboxPatientInfo.Controls.Add(this.btnAddProblem);
            this.grpboxPatientInfo.Controls.Add(this.lblNoteID);
            this.grpboxPatientInfo.Location = new System.Drawing.Point(290, 55);
            this.grpboxPatientInfo.Name = "grpboxPatientInfo";
            this.grpboxPatientInfo.Size = new System.Drawing.Size(823, 479);
            this.grpboxPatientInfo.TabIndex = 3;
            this.grpboxPatientInfo.TabStop = false;
            this.grpboxPatientInfo.Text = "Add/Edit/Delete Notes";
            this.grpboxPatientInfo.Enter += new System.EventHandler(this.grpboxPatientInfo_Enter);
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.Location = new System.Drawing.Point(260, 445);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteNote.TabIndex = 19;
            this.btnDeleteNote.Text = "Delete Note";
            this.btnDeleteNote.UseVisualStyleBackColor = true;
            this.btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Location = new System.Drawing.Point(136, 445);
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateNote.TabIndex = 18;
            this.btnUpdateNote.Text = "Update Note";
            this.btnUpdateNote.UseVisualStyleBackColor = true;
            this.btnUpdateNote.Click += new System.EventHandler(this.btnUpdateNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(10, 445);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(107, 23);
            this.btnAddNote.TabIndex = 17;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // lblVitals
            // 
            this.lblVitals.AutoSize = true;
            this.lblVitals.Location = new System.Drawing.Point(610, 11);
            this.lblVitals.Name = "lblVitals";
            this.lblVitals.Size = new System.Drawing.Size(38, 15);
            this.lblVitals.TabIndex = 16;
            this.lblVitals.Text = "Vitals:";
            // 
            // lstVitals
            // 
            this.lstVitals.FormattingEnabled = true;
            this.lstVitals.ItemHeight = 15;
            this.lstVitals.Location = new System.Drawing.Point(610, 29);
            this.lstVitals.Name = "lstVitals";
            this.lstVitals.Size = new System.Drawing.Size(174, 169);
            this.lstVitals.TabIndex = 15;
            // 
            // lblProblems
            // 
            this.lblProblems.AutoSize = true;
            this.lblProblems.Location = new System.Drawing.Point(425, 11);
            this.lblProblems.Name = "lblProblems";
            this.lblProblems.Size = new System.Drawing.Size(60, 15);
            this.lblProblems.TabIndex = 14;
            this.lblProblems.Text = "Problems:";
            // 
            // lstProblems
            // 
            this.lstProblems.FormattingEnabled = true;
            this.lstProblems.ItemHeight = 15;
            this.lstProblems.Location = new System.Drawing.Point(425, 29);
            this.lstProblems.Name = "lstProblems";
            this.lstProblems.Size = new System.Drawing.Size(163, 169);
            this.lstProblems.TabIndex = 13;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(116, 134);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(230, 23);
            this.dtpDateOfBirth.TabIndex = 12;
            // 
            // lblNewProblem
            // 
            this.lblNewProblem.AutoSize = true;
            this.lblNewProblem.Location = new System.Drawing.Point(24, 169);
            this.lblNewProblem.Name = "lblNewProblem";
            this.lblNewProblem.Size = new System.Drawing.Size(82, 15);
            this.lblNewProblem.TabIndex = 11;
            this.lblNewProblem.Text = "New Problem:";
            // 
            // txtNewProblem
            // 
            this.txtNewProblem.Location = new System.Drawing.Point(116, 166);
            this.txtNewProblem.Name = "txtNewProblem";
            this.txtNewProblem.Size = new System.Drawing.Size(230, 23);
            this.txtNewProblem.TabIndex = 10;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(116, 102);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(230, 23);
            this.txtPatientName.TabIndex = 9;
            // 
            // btnDeleteProblem
            // 
            this.btnDeleteProblem.Location = new System.Drawing.Point(451, 204);
            this.btnDeleteProblem.Name = "btnDeleteProblem";
            this.btnDeleteProblem.Size = new System.Drawing.Size(109, 23);
            this.btnDeleteProblem.TabIndex = 8;
            this.btnDeleteProblem.Text = "Delete Problem";
            this.btnDeleteProblem.UseVisualStyleBackColor = true;
            this.btnDeleteProblem.Click += new System.EventHandler(this.btnDeleteProblem_Click);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(10, 245);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notes:";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(10, 263);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(807, 176);
            this.rtbNotes.TabIndex = 6;
            this.rtbNotes.Text = "";
            this.rtbNotes.TextChanged += new System.EventHandler(this.rtbNotes_TextChanged);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(28, 140);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(78, 15);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Date Of Birth:";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(28, 105);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(82, 15);
            this.lblPatientName.TabIndex = 4;
            this.lblPatientName.Text = "Patient Name:";
            // 
            // txtNoteID
            // 
            this.txtNoteID.Enabled = false;
            this.txtNoteID.Location = new System.Drawing.Point(116, 66);
            this.txtNoteID.Name = "txtNoteID";
            this.txtNoteID.Size = new System.Drawing.Size(33, 23);
            this.txtNoteID.TabIndex = 3;
            // 
            // btnAddProblem
            // 
            this.btnAddProblem.Location = new System.Drawing.Point(136, 204);
            this.btnAddProblem.Name = "btnAddProblem";
            this.btnAddProblem.Size = new System.Drawing.Size(125, 23);
            this.btnAddProblem.TabIndex = 2;
            this.btnAddProblem.Text = "Add Problem";
            this.btnAddProblem.UseVisualStyleBackColor = true;
            this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);
            // 
            // lblNoteID
            // 
            this.lblNoteID.AutoSize = true;
            this.lblNoteID.Location = new System.Drawing.Point(60, 69);
            this.lblNoteID.Name = "lblNoteID";
            this.lblNoteID.Size = new System.Drawing.Size(50, 15);
            this.lblNoteID.TabIndex = 0;
            this.lblNoteID.Text = "Note ID:";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 601);
            this.Controls.Add(this.grpboxPatientInfo);
            this.Controls.Add(this.lblMsgs);
            this.Controls.Add(this.lstPatientNotes);
            this.Controls.Add(this.btnMakeNewNote);
            this.Name = "Mainform";
            this.Text = "Clinical Encounters App";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.grpboxPatientInfo.ResumeLayout(false);
            this.grpboxPatientInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnMakeNewNote;
        private ListBox lstPatientNotes;
        private Label lblMsgs;
        private GroupBox grpboxPatientInfo;
        private Label lblDateOfBirth;
        private Label lblPatientName;
        private TextBox txtNoteID;
        private Button btnAddProblem;
        private Label lblNoteID;
        private Button btnDeleteNote;
        private Button btnUpdateNote;
        private Button btnAddNote;
        private Label lblVitals;
        private ListBox lstVitals;
        private Label lblProblems;
        private ListBox lstProblems;
        private DateTimePicker dtpDateOfBirth;
        private Label lblNewProblem;
        private TextBox txtNewProblem;
        private TextBox txtPatientName;
        private Button btnDeleteProblem;
        private Label lblNotes;
        private RichTextBox rtbNotes;
    }
}