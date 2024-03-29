﻿using System;

namespace CapaDeDatos
{
    public class CLS_Ciudades : ConexionBase
    {

        public string Id_Ciudad { get; set; }
        public string Nombre_Ciudad { get; set; }
        public string Id_Estado { get; set; }

        public string Usuario { get; set; }

        public void MtdSeleccionarCiudad()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Ciudades_Select";

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



        public void MtdInsertarCiudad()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Ciudades_Insert";
                _dato.Texto = Id_Ciudad;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Ciudad");
                _dato.Texto = Nombre_Ciudad;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_Ciudad");
                _dato.Texto = Id_Estado;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Estado");

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

        public void MtdEliminarCiudad()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Ciudades_Delete";
                _dato.Texto = Id_Ciudad;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_Ciudad");
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
