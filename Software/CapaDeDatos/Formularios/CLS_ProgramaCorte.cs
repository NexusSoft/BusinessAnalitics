﻿using System;

namespace CapaDeDatos
{
    public class CLS_ProgramaCorte : ConexionBase
    {
        public string c_codigo_pco { get; set; }
        public string c_codigo_tem { get; set; }

        public void MtdSeleccionarPrograma()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_ProgramaCorte_Select";
                _dato.Texto = c_codigo_tem;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "c_codigo_tem");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
    }
}
