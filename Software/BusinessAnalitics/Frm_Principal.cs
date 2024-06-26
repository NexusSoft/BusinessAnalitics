﻿using BusinessAnalitics;
using BusinessAnalitics.Form_Catalogos.Acarreo;
using CapaDeDatos;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Business_Analitics
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        public string c_codigo_usu { get; set; }
        public string IdPerfil { get; set; }
        public string UsuariosLogin { get; set; }
        List<string> Lista = new List<string>();

        private void CargarAccesos()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for (int x = 0; x < Clase.Datos.Rows.Count; x++)
                {
                    Lista.Add(Clase.Datos.Rows[x][0].ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }
        private Boolean TieneAcceso(String valor)
        {
            foreach (string x in Lista)
            {
                if (x == valor)
                {
                    return true;
                }

            }
            return false;
        }
        private void btn_Usuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("001"))
            {
                Frm_Usuarios Ventana = new Frm_Usuarios();
                Frm_Usuarios.DefInstance.MdiParent = this;
                Frm_Usuarios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Usuarios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [001]");
            }
        }

        private void btn_Perfil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("002"))
            {
                Frm_Perfiles Ventana = new Frm_Perfiles();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }

        private void btn_Permisos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("003"))
            {
                Frm_Permisos Ventana = new Frm_Permisos();
                Frm_Permisos.DefInstance.MdiParent = this;
                Frm_Permisos.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Permisos.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [003]");
            }
        }

        private void Frm_Principal_Shown(object sender, EventArgs e)
        {
            CargarAccesos();
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            MSRegistro RegIn = new MSRegistro();
            RegIn.SaveSetting("ConexionSQL", "Sking", SkinForm.LookAndFeel.SkinName);
        }

        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Pais_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("004"))
            {
                Frm_Pais Ventana = new Frm_Pais(false);
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }

        private void btn_Estado_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("005"))
            {
                Frm_Estado Ventana = new Frm_Estado();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [005]");
            }
        }

        private void btn_Ciudad_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("006"))
            {
                Frm_Ciudad Ventana = new Frm_Ciudad();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [006]");
            }
        }

        private void btn_TipoDomicilio_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("007"))
            {
                Frm_Tipo_Domicilio Ventana = new Frm_Tipo_Domicilio();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [007]");
            }
        }

        private void btn_EmpAcarreo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("008"))
            {
                Frm_EmpresaAcarreo Ventana = new Frm_EmpresaAcarreo();
                Frm_EmpresaAcarreo.DefInstance.MdiParent = this;
                Frm_EmpresaAcarreo.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_EmpresaAcarreo.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [008]");
            }
        }

        private void btn_EmpCorte_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("009"))
            {
                Frm_EmpresaCorte Ventana = new Frm_EmpresaCorte();
                Frm_EmpresaCorte.DefInstance.MdiParent = this;
                Frm_EmpresaCorte.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_EmpresaCorte.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [009]");
            }
        }

        private void btn_EmpBascula_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("010"))
            {
                Frm_EmpresaBasculas Ventana = new Frm_EmpresaBasculas();
                Frm_EmpresaBasculas.DefInstance.MdiParent = this;
                Frm_EmpresaBasculas.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_EmpresaBasculas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [010]");
            }
        }

        private void btn_EmpComercializadora_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("011"))
            {
                Frm_EmpresaComercializadora Ventana = new Frm_EmpresaComercializadora();
                Frm_EmpresaComercializadora.DefInstance.MdiParent = this;
                Frm_EmpresaComercializadora.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_EmpresaComercializadora.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [011]");
            }
        }

        private void btn_inventario_ventas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("012"))
            {
                Frm_Inventario_Ventas Ventana = new Frm_Inventario_Ventas();
                Frm_Inventario_Ventas.DefInstance.MdiParent = this;
                Frm_Inventario_Ventas.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Inventario_Ventas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [012]");
            }
        }

        private void btnReportInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("013"))
            {
                Frm_ReportInventarios Ventana = new Frm_ReportInventarios();
                Frm_ReportInventarios.DefInstance.MdiParent = this;
                Frm_ReportInventarios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_ReportInventarios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [013]");
            }
        }
        private void btn_Cosecha_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("015"))
            {
                Frm_Cosecha Ventana = new Frm_Cosecha();
                Frm_Cosecha.DefInstance.MdiParent = this;
                Frm_Cosecha.DefInstance.IdPerfil = IdPerfil;
                Frm_Cosecha.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Cosecha.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [015]");
            }
        }

        private void btn_TipoCorteTamaño_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("016"))
            {
                Frm_ConfigCalibres Ventana = new Frm_ConfigCalibres();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [016]");
            }
        }

        private void btn_RelacionFruta_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("017"))
            {
                Frm_Relacion_de_Fruta Ventana = new Frm_Relacion_de_Fruta();
                Frm_Relacion_de_Fruta.DefInstance.MdiParent = this;
                Frm_Relacion_de_Fruta.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Relacion_de_Fruta.DefInstance.IdPerfil = IdPerfil;
                Frm_Relacion_de_Fruta.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [017]");
            }
        }

        private void btn_RelacionECorte_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("018"))
            {
                Frm_Relacion_Empresa_Corte Ventana = new Frm_Relacion_Empresa_Corte();
                Frm_Relacion_Empresa_Corte.DefInstance.MdiParent = this;
                Frm_Relacion_Empresa_Corte.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Relacion_Empresa_Corte.DefInstance.IdPerfil = IdPerfil;
                Frm_Relacion_Empresa_Corte.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [018]");
            }
        }

        private void btn_Maquila_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("020"))
            {
                Frm_Maquila Ventana = new Frm_Maquila();
                Frm_Maquila.DefInstance.MdiParent = this;
                Frm_Maquila.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Maquila.DefInstance.IdPerfil = IdPerfil;
                Frm_Maquila.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [020]");
            }
        }

        private void btn_RelacionEAcarreo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("019"))
            {
                Frm_Relacion_Empresa_Acarreo Ventana = new Frm_Relacion_Empresa_Acarreo();
                Frm_Relacion_Empresa_Acarreo.DefInstance.MdiParent = this;
                Frm_Relacion_Empresa_Acarreo.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Relacion_Empresa_Acarreo.DefInstance.IdPerfil = IdPerfil;
                Frm_Relacion_Empresa_Acarreo.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [019]");
            }
        }

        private void btn_TipoCambio_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("021"))
            {
                Frm_TipoCambio Ventana = new Frm_TipoCambio();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [016]");
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("022"))
            {
                Frm_Relacion_Acumulada Ventana = new Frm_Relacion_Acumulada();
                Frm_Relacion_Acumulada.DefInstance.MdiParent = this;
                Frm_Relacion_Acumulada.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Relacion_Acumulada.DefInstance.IdPerfil = IdPerfil;
                Frm_Relacion_Acumulada.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [022]");
            }
        }

        private void btn_ReporteConta_Fruta_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("024"))
            {
                Frm_RelacionContabilidad_de_Fruta Ventana = new Frm_RelacionContabilidad_de_Fruta();
                Frm_RelacionContabilidad_de_Fruta.DefInstance.MdiParent = this;
                Frm_RelacionContabilidad_de_Fruta.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_RelacionContabilidad_de_Fruta.DefInstance.IdPerfil = IdPerfil;
                Frm_RelacionContabilidad_de_Fruta.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [024]");
            }
        }

        private void btn_ReporteConta_Corte_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("025"))
            {
                Frm_RelacionContabilidad_Empresa_Corte Ventana = new Frm_RelacionContabilidad_Empresa_Corte();
                Frm_RelacionContabilidad_Empresa_Corte.DefInstance.MdiParent = this;
                Frm_RelacionContabilidad_Empresa_Corte.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_RelacionContabilidad_Empresa_Corte.DefInstance.IdPerfil = IdPerfil;
                Frm_RelacionContabilidad_Empresa_Corte.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [025]");
            }
        }

        private void btn_ReporteConta_Acarreo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("026"))
            {
                Frm_RelacionContabilidad_Empresa_Acarreo Ventana = new Frm_RelacionContabilidad_Empresa_Acarreo();
                Frm_RelacionContabilidad_Empresa_Acarreo.DefInstance.MdiParent = this;
                Frm_RelacionContabilidad_Empresa_Acarreo.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_RelacionContabilidad_Empresa_Acarreo.DefInstance.IdPerfil = IdPerfil;
                Frm_RelacionContabilidad_Empresa_Acarreo.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [026]");
            }
        }

        private void btn_Cargas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("027"))
            {
                Frm_Cargas Ventana = new Frm_Cargas();
                Frm_Cargas.DefInstance.MdiParent = this;
                Frm_Cargas.DefInstance.IdPerfil = IdPerfil;
                Frm_Cargas.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Cargas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [027]");
            }
        }

        private void btn_Acarreo_Zona_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("028"))
            {
                Frm_Acarreo_Zona Ventana = new Frm_Acarreo_Zona();
                Frm_Acarreo_Zona.DefInstance.MdiParent = this;
                Frm_Acarreo_Zona.DefInstance.IdPerfil = IdPerfil;
                Frm_Acarreo_Zona.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Acarreo_Zona.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [028]");
            }
        }

        private void btn_Acarreo_Precios_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("029"))
            {
                Frm_Acarreo_Precios Ventana = new Frm_Acarreo_Precios();
                Frm_Acarreo_Precios.DefInstance.MdiParent = this;
                Frm_Acarreo_Precios.DefInstance.IdPerfil = IdPerfil;
                Frm_Acarreo_Precios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Acarreo_Precios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [029]");
            }
        }

        private void btn_PrecioFruta_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("030"))
            {
                Frm_Acopio_Precios Ventana = new Frm_Acopio_Precios();
                Frm_Acopio_Precios.DefInstance.MdiParent = this;
                Frm_Acopio_Precios.DefInstance.IdPerfil = IdPerfil;
                Frm_Acopio_Precios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Acopio_Precios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [030]");
            }
        }

        private void btn_EstibaPago_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("031"))
            {
                Frm_Precios_Estibas Ventana = new Frm_Precios_Estibas();
                Frm_Precios_Estibas.DefInstance.MdiParent = this;
                Frm_Precios_Estibas.DefInstance.IdPerfil = IdPerfil;
                Frm_Precios_Estibas.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Precios_Estibas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [030]");
            }
        }
    }
}