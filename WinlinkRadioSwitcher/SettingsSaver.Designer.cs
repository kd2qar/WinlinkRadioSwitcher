using WinlinkRadioSwitcher.Properties;

namespace WinlinkRadioSwitcher
{
  partial class SettingsSaver
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxWinlinkIniFile = new System.Windows.Forms.TextBox();
      this.textBoxSavedRadiosFile = new System.Windows.Forms.TextBox();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.buttonReadRMSIni = new System.Windows.Forms.Button();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.buttonRemove = new System.Windows.Forms.Button();
      this.buttonCopyFromRMS = new System.Windows.Forms.Button();
      this.buttonCopyToRMS = new System.Windows.Forms.Button();
      this.listViewSavedRadios = new System.Windows.Forms.ListView();
      this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ButtonView = new System.Windows.Forms.Button();
      this.columnHeaderRadio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(78, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Winlink INI File";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(275, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(93, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Saved Radios File";
      // 
      // textBoxWinlinkIniFile
      // 
      this.textBoxWinlinkIniFile.Location = new System.Drawing.Point(8, 33);
      this.textBoxWinlinkIniFile.Name = "textBoxWinlinkIniFile";
      this.textBoxWinlinkIniFile.Size = new System.Drawing.Size(201, 20);
      this.textBoxWinlinkIniFile.TabIndex = 2;
      this.textBoxWinlinkIniFile.Text = global::WinlinkRadioSwitcher.Properties.Settings.Default.RMSIniFile;
      this.textBoxWinlinkIniFile.TextChanged += new System.EventHandler(this.TextBoxWinlinkIniFile_TextChanged);
      // 
      // textBoxSavedRadiosFile
      // 
      this.textBoxSavedRadiosFile.Location = new System.Drawing.Point(278, 32);
      this.textBoxSavedRadiosFile.Name = "textBoxSavedRadiosFile";
      this.textBoxSavedRadiosFile.Size = new System.Drawing.Size(201, 20);
      this.textBoxSavedRadiosFile.TabIndex = 3;
      this.textBoxSavedRadiosFile.Text = global::WinlinkRadioSwitcher.Properties.Settings.Default.SavedRadiosFile;
      this.textBoxSavedRadiosFile.TextChanged += new System.EventHandler(this.TextBoxSavedRadiosFile_TextChanged);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.richTextBox1.Location = new System.Drawing.Point(7, 94);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(201, 186);
      this.richTextBox1.TabIndex = 4;
      this.richTextBox1.Text = "";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(106, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Current Configuration";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(275, 71);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(150, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Select or Create Saved Config";
      // 
      // buttonReadRMSIni
      // 
      this.buttonReadRMSIni.Location = new System.Drawing.Point(122, 60);
      this.buttonReadRMSIni.Name = "buttonReadRMSIni";
      this.buttonReadRMSIni.Size = new System.Drawing.Size(75, 23);
      this.buttonReadRMSIni.TabIndex = 8;
      this.buttonReadRMSIni.Text = "Read";
      this.buttonReadRMSIni.UseVisualStyleBackColor = true;
      this.buttonReadRMSIni.Click += new System.EventHandler(this.ButtonReadRMSIni_Click);
      // 
      // buttonAdd
      // 
      this.buttonAdd.Location = new System.Drawing.Point(216, 94);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(56, 23);
      this.buttonAdd.TabIndex = 9;
      this.buttonAdd.Text = "Add";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
      // 
      // buttonRemove
      // 
      this.buttonRemove.Location = new System.Drawing.Point(216, 123);
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new System.Drawing.Size(56, 23);
      this.buttonRemove.TabIndex = 10;
      this.buttonRemove.Text = "Remove";
      this.buttonRemove.UseVisualStyleBackColor = true;
      this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
      // 
      // buttonCopyFromRMS
      // 
      this.buttonCopyFromRMS.Location = new System.Drawing.Point(216, 162);
      this.buttonCopyFromRMS.Name = "buttonCopyFromRMS";
      this.buttonCopyFromRMS.Size = new System.Drawing.Size(56, 23);
      this.buttonCopyFromRMS.TabIndex = 11;
      this.buttonCopyFromRMS.Text = ">>";
      this.buttonCopyFromRMS.UseVisualStyleBackColor = true;
      this.buttonCopyFromRMS.Click += new System.EventHandler(this.ButtonCopyFromRMS_Click);
      // 
      // buttonCopyToRMS
      // 
      this.buttonCopyToRMS.Location = new System.Drawing.Point(216, 191);
      this.buttonCopyToRMS.Name = "buttonCopyToRMS";
      this.buttonCopyToRMS.Size = new System.Drawing.Size(56, 23);
      this.buttonCopyToRMS.TabIndex = 12;
      this.buttonCopyToRMS.Text = "<<";
      this.buttonCopyToRMS.UseVisualStyleBackColor = true;
      this.buttonCopyToRMS.Click += new System.EventHandler(this.ButtonCopyToRMS_Click);
      // 
      // listViewSavedRadios
      // 
      this.listViewSavedRadios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listViewSavedRadios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderRadio});
      this.listViewSavedRadios.FullRowSelect = true;
      this.listViewSavedRadios.HideSelection = false;
      this.listViewSavedRadios.LabelWrap = false;
      this.listViewSavedRadios.Location = new System.Drawing.Point(279, 94);
      this.listViewSavedRadios.MultiSelect = false;
      this.listViewSavedRadios.Name = "listViewSavedRadios";
      this.listViewSavedRadios.Size = new System.Drawing.Size(241, 186);
      this.listViewSavedRadios.TabIndex = 13;
      this.listViewSavedRadios.UseCompatibleStateImageBehavior = false;
      this.listViewSavedRadios.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderName
      // 
      this.columnHeaderName.Text = "Name";
      // 
      // ButtonView
      // 
      this.ButtonView.Location = new System.Drawing.Point(432, 71);
      this.ButtonView.Name = "ButtonView";
      this.ButtonView.Size = new System.Drawing.Size(75, 23);
      this.ButtonView.TabIndex = 14;
      this.ButtonView.Text = "View";
      this.ButtonView.UseVisualStyleBackColor = true;
      this.ButtonView.Click += new System.EventHandler(this.ButtonView_Click);
      // 
      // columnHeaderRadio
      // 
      this.columnHeaderRadio.Text = "Radio";
      this.columnHeaderRadio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // SettingsSaver
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ButtonView);
      this.Controls.Add(this.listViewSavedRadios);
      this.Controls.Add(this.buttonCopyToRMS);
      this.Controls.Add(this.buttonCopyFromRMS);
      this.Controls.Add(this.buttonRemove);
      this.Controls.Add(this.buttonAdd);
      this.Controls.Add(this.buttonReadRMSIni);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.textBoxSavedRadiosFile);
      this.Controls.Add(this.textBoxWinlinkIniFile);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "SettingsSaver";
      this.Size = new System.Drawing.Size(529, 288);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxWinlinkIniFile;
    private System.Windows.Forms.TextBox textBoxSavedRadiosFile;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button buttonReadRMSIni;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.Button buttonCopyFromRMS;
    private System.Windows.Forms.Button buttonCopyToRMS;
    private System.Windows.Forms.ListView listViewSavedRadios;
    private System.Windows.Forms.ColumnHeader columnHeaderName;
    private System.Windows.Forms.Button ButtonView;
    private System.Windows.Forms.ColumnHeader columnHeaderRadio;
  }
}
