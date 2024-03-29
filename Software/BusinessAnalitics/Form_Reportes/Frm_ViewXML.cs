﻿using CapaDeDatos;
using System;

namespace Business_Analitics
{
    public partial class Frm_ViewXML : DevExpress.XtraEditors.XtraForm
    {

        public string Id_Cosecha { get; set; }
        public int Id_Archivo { get; set; }
        public string UUID { get; set; }

        public Frm_ViewXML()
        {
            InitializeComponent();
        }

        private void Frm_ViewXMLSalidas_Load(object sender, EventArgs e)
        {
            if (Id_Archivo < 7)
            {
                CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
                sel.Id_Cosecha = Id_Cosecha;
                sel.Id_Archivo = Id_Archivo;
                sel.MtdSeleccionarCosechaArchivoPDFXMLView();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["FacturaXML"] != null)
                    {
                        byte[] bytes = (byte[])sel.Datos.Rows[0]["FacturaXML"];

                        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml", bytes);
                        webBrowser1.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
                    }
                }
            }
            else if (Id_Archivo == 7)
            {
                CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
                sel.Id_Cosecha = Id_Cosecha;
                sel.UUID = UUID;
                sel.MtdSeleccionarCosechaArchivoREP_PDFXMLView();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["FacturaXML"] != null)
                    {
                        byte[] bytes = (byte[])sel.Datos.Rows[0]["FacturaXML"];

                        System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml", bytes);
                        webBrowser1.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
                    }
                }
            }
        }
    }
}