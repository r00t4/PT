namespace astr
{
    partial class frmAsteroids
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsteroids));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tmrSpaceStation = new System.Windows.Forms.Timer(this.components);
            this.tmrAsteroids = new System.Windows.Forms.Timer(this.components);
            this.tmrSpaceShip = new System.Windows.Forms.Timer(this.components);
            this.tmrRocket = new System.Windows.Forms.Timer(this.components);
            this.tmrAsterTick = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "asteroid1.png");
            this.imageList1.Images.SetKeyName(1, "rocket.png");
            this.imageList1.Images.SetKeyName(2, "rocket1.png");
            this.imageList1.Images.SetKeyName(3, "rocket3.png");
            this.imageList1.Images.SetKeyName(4, "rocket4.png");
            this.imageList1.Images.SetKeyName(5, "rocket5.png");
            this.imageList1.Images.SetKeyName(6, "rocket6.png");
            this.imageList1.Images.SetKeyName(7, "rocket7.png");
            this.imageList1.Images.SetKeyName(8, "rocket8.png");
            this.imageList1.Images.SetKeyName(9, "SpaceStation.gif");
            // 
            // tmrSpaceStation
            // 
            this.tmrSpaceStation.Tick += new System.EventHandler(this.tmrSpaceStation_Tick);
            // 
            // tmrAsteroids
            // 
            this.tmrAsteroids.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrSpaceShip
            // 
            this.tmrSpaceShip.Tick += new System.EventHandler(this.tmrSpaceShip_Tick);
            // 
            // tmrRocket
            // 
            this.tmrRocket.Tick += new System.EventHandler(this.tmrRocket_Tick);
            // 
            // tmrAsterTick
            // 
            this.tmrAsterTick.Tick += new System.EventHandler(this.tmrAsterTick_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // frmAsteroids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(947, 602);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAsteroids";
            this.Text = "Asteroids";
            this.Load += new System.EventHandler(this.frmAsteroids_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer tmrSpaceStation;
        private System.Windows.Forms.Timer tmrAsteroids;
        private System.Windows.Forms.Timer tmrSpaceShip;
        private System.Windows.Forms.Timer tmrRocket;
        private System.Windows.Forms.Timer tmrAsterTick;
        private System.Windows.Forms.Label label1;
    }
}

