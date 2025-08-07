namespace WinlinkRadioSwitcher
{
  partial class SettingsForm
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
      this.radioSettingsControl1 = new WinlinkRadioSwitcher.RadioSettingsControl();
      this.ButtonOK = new System.Windows.Forms.Button();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // radioSettingsControl1
      // 
      this.radioSettingsControl1.Location = new System.Drawing.Point(-3, 3);
      this.radioSettingsControl1.Name = "radioSettingsControl1";
      this.radioSettingsControl1.Size = new System.Drawing.Size(573, 320);
      this.radioSettingsControl1.TabIndex = 0;
      // 
      // ButtonOK
      // 
      this.ButtonOK.Location = new System.Drawing.Point(12, 329);
      this.ButtonOK.Name = "ButtonOK";
      this.ButtonOK.Size = new System.Drawing.Size(75, 23);
      this.ButtonOK.TabIndex = 1;
      this.ButtonOK.Text = "OK";
      this.ButtonOK.UseVisualStyleBackColor = true;
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButtonCancel.Location = new System.Drawing.Point(106, 329);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.ButtonCancel.TabIndex = 2;
      this.ButtonCancel.Text = "Cancel";
      this.ButtonCancel.UseVisualStyleBackColor = true;
      // 
      // SettingsForm
      // 
      this.AcceptButton = this.ButtonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.ClientSize = new System.Drawing.Size(561, 357);
      this.Controls.Add(this.ButtonCancel);
      this.Controls.Add(this.ButtonOK);
      this.Controls.Add(this.radioSettingsControl1);
      this.Name = "SettingsForm";
      this.Text = "Radio Settings";
      this.ResumeLayout(false);

    }

    #endregion

    private RadioSettingsControl radioSettingsControl1;
    private System.Windows.Forms.Button ButtonOK;
    private System.Windows.Forms.Button ButtonCancel;
  }
}