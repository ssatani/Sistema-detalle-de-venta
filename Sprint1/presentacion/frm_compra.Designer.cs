namespace Sprint1.presentacion
{
    partial class frm_compra
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
            this.btn_nueva_compra = new System.Windows.Forms.Button();
            this.btn_guardar_compra = new System.Windows.Forms.Button();
            this.btn_imprimir_comprovante = new System.Windows.Forms.Button();
            this.btn_eliminar_compra = new System.Windows.Forms.Button();
            this.panel_datos = new System.Windows.Forms.Panel();
            this.txt_num_doc = new System.Windows.Forms.TextBox();
            this.cmb_tipo_doc = new System.Windows.Forms.ComboBox();
            this.btn_añadir_proveedor = new System.Windows.Forms.Button();
            this.txt_proveedor = new System.Windows.Forms.TextBox();
            this.btn_fecha = new System.Windows.Forms.Button();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_buscar = new System.Windows.Forms.Panel();
            this.datos_varios = new System.Windows.Forms.DataGridView();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_expand = new System.Windows.Forms.Panel();
            this.panel_hasta = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.calendar_hasta = new System.Windows.Forms.MonthCalendar();
            this.panel_desde = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.calendar_desde = new System.Windows.Forms.MonthCalendar();
            this.btn_listar_compras = new System.Windows.Forms.Button();
            this.btn_listar_proveedores = new System.Windows.Forms.Button();
            this.btn_listar_productos = new System.Windows.Forms.Button();
            this.panel_detalle_compra = new System.Windows.Forms.Panel();
            this.datos_detalle_compra = new System.Windows.Forms.DataGridView();
            this.btn_contraer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_total_compra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_descuento = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_datos.SuspendLayout();
            this.panel_buscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos_varios)).BeginInit();
            this.panel_expand.SuspendLayout();
            this.panel_hasta.SuspendLayout();
            this.panel_desde.SuspendLayout();
            this.panel_detalle_compra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos_detalle_compra)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_nueva_compra
            // 
            this.btn_nueva_compra.Location = new System.Drawing.Point(11, 9);
            this.btn_nueva_compra.Name = "btn_nueva_compra";
            this.btn_nueva_compra.Size = new System.Drawing.Size(98, 23);
            this.btn_nueva_compra.TabIndex = 0;
            this.btn_nueva_compra.Text = "Nueva Compra";
            this.btn_nueva_compra.UseVisualStyleBackColor = true;
            this.btn_nueva_compra.Click += new System.EventHandler(this.btn_nueva_compra_Click);
            // 
            // btn_guardar_compra
            // 
            this.btn_guardar_compra.Enabled = false;
            this.btn_guardar_compra.Location = new System.Drawing.Point(115, 9);
            this.btn_guardar_compra.Name = "btn_guardar_compra";
            this.btn_guardar_compra.Size = new System.Drawing.Size(98, 23);
            this.btn_guardar_compra.TabIndex = 1;
            this.btn_guardar_compra.Text = "Guardar Compra";
            this.btn_guardar_compra.UseVisualStyleBackColor = true;
            this.btn_guardar_compra.Click += new System.EventHandler(this.btn_guardar_compra_Click);
            // 
            // btn_imprimir_comprovante
            // 
            this.btn_imprimir_comprovante.Location = new System.Drawing.Point(219, 9);
            this.btn_imprimir_comprovante.Name = "btn_imprimir_comprovante";
            this.btn_imprimir_comprovante.Size = new System.Drawing.Size(116, 23);
            this.btn_imprimir_comprovante.TabIndex = 2;
            this.btn_imprimir_comprovante.Text = "Imprimir Comprovante";
            this.btn_imprimir_comprovante.UseVisualStyleBackColor = true;
            this.btn_imprimir_comprovante.Click += new System.EventHandler(this.btn_imprimir_comprovante_Click);
            // 
            // btn_eliminar_compra
            // 
            this.btn_eliminar_compra.Location = new System.Drawing.Point(341, 9);
            this.btn_eliminar_compra.Name = "btn_eliminar_compra";
            this.btn_eliminar_compra.Size = new System.Drawing.Size(98, 23);
            this.btn_eliminar_compra.TabIndex = 3;
            this.btn_eliminar_compra.Text = "Eliminar Compra";
            this.btn_eliminar_compra.UseVisualStyleBackColor = true;
            this.btn_eliminar_compra.Click += new System.EventHandler(this.btn_eliminar_compra_Click);
            // 
            // panel_datos
            // 
            this.panel_datos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_datos.Controls.Add(this.txt_num_doc);
            this.panel_datos.Controls.Add(this.cmb_tipo_doc);
            this.panel_datos.Controls.Add(this.btn_añadir_proveedor);
            this.panel_datos.Controls.Add(this.txt_proveedor);
            this.panel_datos.Controls.Add(this.btn_fecha);
            this.panel_datos.Controls.Add(this.txt_fecha);
            this.panel_datos.Controls.Add(this.label4);
            this.panel_datos.Controls.Add(this.label3);
            this.panel_datos.Controls.Add(this.label2);
            this.panel_datos.Controls.Add(this.label1);
            this.panel_datos.Enabled = false;
            this.panel_datos.Location = new System.Drawing.Point(11, 38);
            this.panel_datos.Name = "panel_datos";
            this.panel_datos.Size = new System.Drawing.Size(259, 130);
            this.panel_datos.TabIndex = 5;
            // 
            // txt_num_doc
            // 
            this.txt_num_doc.Location = new System.Drawing.Point(78, 99);
            this.txt_num_doc.Name = "txt_num_doc";
            this.txt_num_doc.Size = new System.Drawing.Size(167, 20);
            this.txt_num_doc.TabIndex = 9;
            this.txt_num_doc.Text = "0";
            this.txt_num_doc.TextChanged += new System.EventHandler(this.txt_num_doc_TextChanged);
            // 
            // cmb_tipo_doc
            // 
            this.cmb_tipo_doc.FormattingEnabled = true;
            this.cmb_tipo_doc.Items.AddRange(new object[] {
            "Factura",
            "Recibo"});
            this.cmb_tipo_doc.Location = new System.Drawing.Point(78, 72);
            this.cmb_tipo_doc.Name = "cmb_tipo_doc";
            this.cmb_tipo_doc.Size = new System.Drawing.Size(167, 21);
            this.cmb_tipo_doc.TabIndex = 8;
            this.cmb_tipo_doc.Text = "Factura";
            this.cmb_tipo_doc.TextChanged += new System.EventHandler(this.cmb_tipo_doc_TextChanged);
            // 
            // btn_añadir_proveedor
            // 
            this.btn_añadir_proveedor.Location = new System.Drawing.Point(222, 41);
            this.btn_añadir_proveedor.Name = "btn_añadir_proveedor";
            this.btn_añadir_proveedor.Size = new System.Drawing.Size(23, 23);
            this.btn_añadir_proveedor.TabIndex = 7;
            this.btn_añadir_proveedor.Text = "+";
            this.btn_añadir_proveedor.UseVisualStyleBackColor = true;
            this.btn_añadir_proveedor.Click += new System.EventHandler(this.btn_añadir_proveedor_Click);
            // 
            // txt_proveedor
            // 
            this.txt_proveedor.Location = new System.Drawing.Point(78, 43);
            this.txt_proveedor.Name = "txt_proveedor";
            this.txt_proveedor.Size = new System.Drawing.Size(138, 20);
            this.txt_proveedor.TabIndex = 6;
            this.txt_proveedor.TextChanged += new System.EventHandler(this.txt_proveedor_TextChanged);
            // 
            // btn_fecha
            // 
            this.btn_fecha.Location = new System.Drawing.Point(208, 12);
            this.btn_fecha.Name = "btn_fecha";
            this.btn_fecha.Size = new System.Drawing.Size(37, 23);
            this.btn_fecha.TabIndex = 5;
            this.btn_fecha.UseVisualStyleBackColor = true;
            this.btn_fecha.Click += new System.EventHandler(this.btn_fecha_Click);
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(78, 14);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(124, 20);
            this.txt_fecha.TabIndex = 4;
            this.txt_fecha.TextChanged += new System.EventHandler(this.txt_fecha_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Num. Doc.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Doc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "´Proveedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // panel_buscar
            // 
            this.panel_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_buscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_buscar.Controls.Add(this.datos_varios);
            this.panel_buscar.Controls.Add(this.txt_buscar);
            this.panel_buscar.Controls.Add(this.label5);
            this.panel_buscar.Location = new System.Drawing.Point(276, 38);
            this.panel_buscar.Name = "panel_buscar";
            this.panel_buscar.Size = new System.Drawing.Size(492, 130);
            this.panel_buscar.TabIndex = 6;
            // 
            // datos_varios
            // 
            this.datos_varios.AllowUserToAddRows = false;
            this.datos_varios.AllowUserToDeleteRows = false;
            this.datos_varios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datos_varios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos_varios.Location = new System.Drawing.Point(3, 37);
            this.datos_varios.Name = "datos_varios";
            this.datos_varios.Size = new System.Drawing.Size(483, 90);
            this.datos_varios.TabIndex = 2;
            this.datos_varios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos_varios_CellDoubleClick);
            this.datos_varios.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.datos_varios_UserDeletingRow);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.Location = new System.Drawing.Point(54, 11);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(432, 20);
            this.txt_buscar.TabIndex = 1;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Buscar:";
            // 
            // panel_expand
            // 
            this.panel_expand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_expand.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_expand.Controls.Add(this.panel_hasta);
            this.panel_expand.Controls.Add(this.panel_desde);
            this.panel_expand.Controls.Add(this.btn_listar_compras);
            this.panel_expand.Controls.Add(this.btn_listar_proveedores);
            this.panel_expand.Controls.Add(this.btn_listar_productos);
            this.panel_expand.Location = new System.Drawing.Point(774, 38);
            this.panel_expand.Name = "panel_expand";
            this.panel_expand.Size = new System.Drawing.Size(211, 502);
            this.panel_expand.TabIndex = 7;
            // 
            // panel_hasta
            // 
            this.panel_hasta.Controls.Add(this.label7);
            this.panel_hasta.Controls.Add(this.calendar_hasta);
            this.panel_hasta.Location = new System.Drawing.Point(3, 299);
            this.panel_hasta.Name = "panel_hasta";
            this.panel_hasta.Size = new System.Drawing.Size(205, 197);
            this.panel_hasta.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Hasta:";
            // 
            // calendar_hasta
            // 
            this.calendar_hasta.Location = new System.Drawing.Point(6, 26);
            this.calendar_hasta.Name = "calendar_hasta";
            this.calendar_hasta.TabIndex = 0;
            this.calendar_hasta.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_hasta_DateChanged);
            // 
            // panel_desde
            // 
            this.panel_desde.Controls.Add(this.label6);
            this.panel_desde.Controls.Add(this.calendar_desde);
            this.panel_desde.Location = new System.Drawing.Point(3, 95);
            this.panel_desde.Name = "panel_desde";
            this.panel_desde.Size = new System.Drawing.Size(205, 198);
            this.panel_desde.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Desde:";
            // 
            // calendar_desde
            // 
            this.calendar_desde.Location = new System.Drawing.Point(7, 29);
            this.calendar_desde.Name = "calendar_desde";
            this.calendar_desde.TabIndex = 0;
            this.calendar_desde.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_desde_DateChanged);
            // 
            // btn_listar_compras
            // 
            this.btn_listar_compras.Location = new System.Drawing.Point(3, 66);
            this.btn_listar_compras.Name = "btn_listar_compras";
            this.btn_listar_compras.Size = new System.Drawing.Size(205, 23);
            this.btn_listar_compras.TabIndex = 2;
            this.btn_listar_compras.Text = "Compras";
            this.btn_listar_compras.UseVisualStyleBackColor = true;
            this.btn_listar_compras.Click += new System.EventHandler(this.btn_compras_Click);
            // 
            // btn_listar_proveedores
            // 
            this.btn_listar_proveedores.Location = new System.Drawing.Point(3, 37);
            this.btn_listar_proveedores.Name = "btn_listar_proveedores";
            this.btn_listar_proveedores.Size = new System.Drawing.Size(205, 23);
            this.btn_listar_proveedores.TabIndex = 1;
            this.btn_listar_proveedores.Text = "Listar Proveedores";
            this.btn_listar_proveedores.UseVisualStyleBackColor = true;
            this.btn_listar_proveedores.Click += new System.EventHandler(this.btn_listar_proveedores_Click);
            // 
            // btn_listar_productos
            // 
            this.btn_listar_productos.Location = new System.Drawing.Point(3, 8);
            this.btn_listar_productos.Name = "btn_listar_productos";
            this.btn_listar_productos.Size = new System.Drawing.Size(205, 23);
            this.btn_listar_productos.TabIndex = 0;
            this.btn_listar_productos.Text = "Listar Productos";
            this.btn_listar_productos.UseVisualStyleBackColor = true;
            this.btn_listar_productos.Click += new System.EventHandler(this.btn_listar_productos_Click);
            // 
            // panel_detalle_compra
            // 
            this.panel_detalle_compra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_detalle_compra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_detalle_compra.Controls.Add(this.datos_detalle_compra);
            this.panel_detalle_compra.Location = new System.Drawing.Point(11, 174);
            this.panel_detalle_compra.Name = "panel_detalle_compra";
            this.panel_detalle_compra.Size = new System.Drawing.Size(757, 366);
            this.panel_detalle_compra.TabIndex = 8;
            // 
            // datos_detalle_compra
            // 
            this.datos_detalle_compra.AllowUserToAddRows = false;
            this.datos_detalle_compra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datos_detalle_compra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos_detalle_compra.Location = new System.Drawing.Point(3, 6);
            this.datos_detalle_compra.Name = "datos_detalle_compra";
            this.datos_detalle_compra.Size = new System.Drawing.Size(748, 353);
            this.datos_detalle_compra.TabIndex = 0;
            this.datos_detalle_compra.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos_detalle_compra_CellEnter);
            this.datos_detalle_compra.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos_detalle_compra_CellValueChanged);
            this.datos_detalle_compra.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos_detalle_compra_RowEnter);
            this.datos_detalle_compra.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.datos_detalle_compra_RowsRemoved);
            // 
            // btn_contraer
            // 
            this.btn_contraer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_contraer.Location = new System.Drawing.Point(777, 9);
            this.btn_contraer.Name = "btn_contraer";
            this.btn_contraer.Size = new System.Drawing.Size(205, 23);
            this.btn_contraer.TabIndex = 9;
            this.btn_contraer.Text = "Contraer >";
            this.btn_contraer.UseVisualStyleBackColor = true;
            this.btn_contraer.Click += new System.EventHandler(this.btn_contraer_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lbl_total_compra);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lbl_descuento);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(11, 546);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 38);
            this.panel2.TabIndex = 1;
            // 
            // lbl_total_compra
            // 
            this.lbl_total_compra.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_total_compra.AutoSize = true;
            this.lbl_total_compra.Location = new System.Drawing.Point(872, 16);
            this.lbl_total_compra.Name = "lbl_total_compra";
            this.lbl_total_compra.Size = new System.Drawing.Size(28, 13);
            this.lbl_total_compra.TabIndex = 3;
            this.lbl_total_compra.Text = "0 (u)";
            this.lbl_total_compra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(760, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Precio Total Compra:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_descuento
            // 
            this.lbl_descuento.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_descuento.AutoSize = true;
            this.lbl_descuento.Location = new System.Drawing.Point(639, 16);
            this.lbl_descuento.Name = "lbl_descuento";
            this.lbl_descuento.Size = new System.Drawing.Size(28, 13);
            this.lbl_descuento.TabIndex = 1;
            this.lbl_descuento.Text = "0 (u)";
            this.lbl_descuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(524, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Descuento Total:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_contraer);
            this.Controls.Add(this.panel_detalle_compra);
            this.Controls.Add(this.panel_expand);
            this.Controls.Add(this.panel_buscar);
            this.Controls.Add(this.panel_datos);
            this.Controls.Add(this.btn_eliminar_compra);
            this.Controls.Add(this.btn_imprimir_comprovante);
            this.Controls.Add(this.btn_guardar_compra);
            this.Controls.Add(this.btn_nueva_compra);
            this.Name = "frm_compra";
            this.Tag = "1";
            this.Text = "frm_compra";
            this.Load += new System.EventHandler(this.frm_compra_Load);
            this.panel_datos.ResumeLayout(false);
            this.panel_datos.PerformLayout();
            this.panel_buscar.ResumeLayout(false);
            this.panel_buscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos_varios)).EndInit();
            this.panel_expand.ResumeLayout(false);
            this.panel_hasta.ResumeLayout(false);
            this.panel_hasta.PerformLayout();
            this.panel_desde.ResumeLayout(false);
            this.panel_desde.PerformLayout();
            this.panel_detalle_compra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datos_detalle_compra)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_nueva_compra;
        private System.Windows.Forms.Button btn_guardar_compra;
        private System.Windows.Forms.Button btn_imprimir_comprovante;
        private System.Windows.Forms.Button btn_eliminar_compra;
        private System.Windows.Forms.Panel panel_datos;
        private System.Windows.Forms.Panel panel_buscar;
        private System.Windows.Forms.Panel panel_expand;
        private System.Windows.Forms.Panel panel_detalle_compra;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_num_doc;
        private System.Windows.Forms.ComboBox cmb_tipo_doc;
        private System.Windows.Forms.Button btn_añadir_proveedor;
        private System.Windows.Forms.TextBox txt_proveedor;
        private System.Windows.Forms.Button btn_fecha;
        private System.Windows.Forms.DataGridView datos_varios;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_desde;
        private System.Windows.Forms.Button btn_listar_compras;
        private System.Windows.Forms.Button btn_listar_proveedores;
        private System.Windows.Forms.Button btn_listar_productos;
        private System.Windows.Forms.DataGridView datos_detalle_compra;
        private System.Windows.Forms.Panel panel_hasta;
        private System.Windows.Forms.MonthCalendar calendar_hasta;
        private System.Windows.Forms.MonthCalendar calendar_desde;
        private System.Windows.Forms.Button btn_contraer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_total_compra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_descuento;
        private System.Windows.Forms.Label label8;
    }
}