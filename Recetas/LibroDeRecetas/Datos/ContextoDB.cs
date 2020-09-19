using System;
using System.IO;
using System.Collections.Generic;
using LiteDB;
using LibroDeRecetas.Models;

namespace LibroDeRecetas.Datos
{
    public static class ContextoDB
    {
        public static string ArchivosDeDatos { get; set; }
        public const string Coleccion_UnidadesDeMedida = "UnidadDeMedida";
        public const string Coleccion_IngredientesSimples = "IngredienteSimple";  
        
        public static void ConectarArchivoDeDatos()
        {
            ArchivosDeDatos = Properties.Settings.Default.BaseLiteDB;

            if (!File.Exists(ArchivosDeDatos))
            {
                CrearDatosDefault();
            }

        }

        private static void CrearDatosDefault()
        {
            UnidadDeMedida_CrearDefaults();
        }

        #region "Unidades de Medida"
        private static void UnidadDeMedida_CrearDefaults()
        {
            using (var db = new LiteDatabase(ArchivosDeDatos))
            {
                UnidadDeMedida udm;
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>(Coleccion_UnidadesDeMedida);

                udm = new UnidadDeMedida("Gramo", "GR", TipoUnidadDeMedida.Peso, true);
                unidadesDeMedida.Insert(udm);

                udm = new UnidadDeMedida("Kilogramo", "KG", TipoUnidadDeMedida.Peso, true);
                unidadesDeMedida.Insert(udm);

                udm = new UnidadDeMedida("Litro", "LT", TipoUnidadDeMedida.Volumen, true);
                unidadesDeMedida.Insert(udm);

                udm = new UnidadDeMedida("Mililitro", "ML", TipoUnidadDeMedida.Volumen, true);
                unidadesDeMedida.Insert(udm);

                udm = new UnidadDeMedida("Unidad", "UN", TipoUnidadDeMedida.Unidad, true);
                unidadesDeMedida.Insert(udm);
            }
        }

        public static List<UnidadDeMedida> UnidadDeMedida_DevolverTodas()
        {
            List<UnidadDeMedida> rtaLista = new List<UnidadDeMedida>();
            using (var db = new LiteDatabase(ArchivosDeDatos))
            {
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>(Coleccion_UnidadesDeMedida);

                foreach (var item in unidadesDeMedida.FindAll())
                {
                    rtaLista.Add(item);
                }

                return rtaLista;
            }
        }

        public static bool UnidadDeMedida_Insertar(UnidadDeMedida udm)
        {
            bool rtaResultado;

            try
            {
                using (var db = new LiteDatabase(ArchivosDeDatos))
                {
                    var unidadesDeMedida = db.GetCollection<UnidadDeMedida>(Coleccion_UnidadesDeMedida);
                    unidadesDeMedida.Insert(udm);
                    rtaResultado = true;
                }
            }
            catch (Exception ex)
            {
                rtaResultado = false;
                throw ex;
            }

            return rtaResultado;
        }

        public static bool UnidadDeMedida_Actualizar(UnidadDeMedida udm)
        {
            bool rtaResultado;

            try
            {
                using (var db = new LiteDatabase(ArchivosDeDatos))
                {
                    var unidadesDeMedida = db.GetCollection<UnidadDeMedida>(Coleccion_UnidadesDeMedida);
                    unidadesDeMedida.Update(udm);
                    rtaResultado = true;
                }
            }
            catch (Exception ex)
            {
                rtaResultado = false;
                throw ex;
            }

            return rtaResultado;
        }
        #endregion
    }
}
