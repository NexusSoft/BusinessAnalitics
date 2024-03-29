﻿using System;

namespace CapaDeDatos
{
    public class CLS_Estado : ConexionBase
    {

        public string Id_Estado { get; set; }
        public string Nombre_Estado { get; set; }
        public string Id_Pais { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarEstado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Estado_Select";

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
        public void MtdInsertarEstado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Estado_Insert";
                _dato.Texto = Id_Estado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Estado");
                _dato.Texto = Nombre_Estado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Estado");
                _dato.Texto = Id_Pais;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Pais");

                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
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
        public void MtdEliminarEstado()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Estado_Delete";
                _dato.Texto = Id_Estado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Estado");
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
