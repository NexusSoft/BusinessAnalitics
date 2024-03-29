﻿using System;

namespace CapaDeDatos
{
    public class CLS_Tipo_Domicilio : ConexionBase
    {

        public string Id_Tipo_Domicilio { get; set; }
        public string Nombre_Tipo_Domicilio { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarTipoDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tipo_Domicilio_Select";


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

        public void MtdInsertarTipoDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tipo_Domicilio_Insert";
                _dato.Texto = Id_Tipo_Domicilio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_TipoDomicilio");
                _dato.Texto = Nombre_Tipo_Domicilio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_TipoDomicilio");
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

        public void MtdEliminarTipoDomicilio()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Tipo_Domicilio_Delete";
                _dato.Texto = Id_Tipo_Domicilio;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_TipoDomicilio");
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
