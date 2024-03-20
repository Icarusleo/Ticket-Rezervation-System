namespace ProlabProjesi2
{
    partial class GirişPaneli
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.adminpanel = new System.Windows.Forms.Button();
            this.kullanici = new System.Windows.Forms.Button();
            this.firmapanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminpanel
            // 
            this.adminpanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.adminpanel.Location = new System.Drawing.Point(80, 102);
            this.adminpanel.Name = "adminpanel";
            this.adminpanel.Size = new System.Drawing.Size(187, 35);
            this.adminpanel.TabIndex = 10;
            this.adminpanel.Text = "Admin Panel";
            this.adminpanel.UseVisualStyleBackColor = true;
            this.adminpanel.Click += new System.EventHandler(this.adminpanel_Click);
            // 
            // kullanici
            // 
            this.kullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici.Location = new System.Drawing.Point(80, 270);
            this.kullanici.Name = "kullanici";
            this.kullanici.Size = new System.Drawing.Size(187, 37);
            this.kullanici.TabIndex = 9;
            this.kullanici.Text = "Bilet Ara";
            this.kullanici.UseVisualStyleBackColor = true;
            this.kullanici.Click += new System.EventHandler(this.kullanici_Click);
            // 
            // firmapanel
            // 
            this.firmapanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.firmapanel.Location = new System.Drawing.Point(80, 183);
            this.firmapanel.Name = "firmapanel";
            this.firmapanel.Size = new System.Drawing.Size(187, 37);
            this.firmapanel.TabIndex = 8;
            this.firmapanel.Text = "Firma Paneli";
            this.firmapanel.UseVisualStyleBackColor = true;
            this.firmapanel.Click += new System.EventHandler(this.firmapanel_Click);
            // 
            // GirişPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 450);
            this.Controls.Add(this.adminpanel);
            this.Controls.Add(this.kullanici);
            this.Controls.Add(this.firmapanel);
            this.Name = "GirişPaneli";
            this.Text = "Turizm Bilet Paneli";
            this.Load += new System.EventHandler(this.GirişPaneli_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminpanel;
        private System.Windows.Forms.Button kullanici;
        private System.Windows.Forms.Button firmapanel;
    }
}

