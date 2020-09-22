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

        private static String DevolverNombreColeccion(Type T)
        {
            switch (T.Name)
            {
                case "UnidadDeMedida":
                    return Coleccion_UnidadesDeMedida;
                case "IngredienteSimple":
                    return Coleccion_IngredientesSimples;
                default:
                    throw new Exception("La entidad " + T.Name + " no es reconocida por la aplicacion");
            }
        }

        #region Entidades Genericas
        public static List<T> Entidad_DevolverTodos<T>()
        {
            List<T> rtaLista = new List<T>();
            using (var db = new LiteDatabase(ArchivosDeDatos))
            {
                var entidades = db.GetCollection<T>(DevolverNombreColeccion(typeof(T)));

                foreach (var item in entidades.FindAll())
                {
                    rtaLista.Add(item);
                }
                return rtaLista;
            }
        }

        public static bool Entidad_Insertar<T>(T entidad)
        {
            bool rtaResultado;

            try
            {
                using (var db = new LiteDatabase(ArchivosDeDatos))
                {
                    var entidades = db.GetCollection<T>(DevolverNombreColeccion(typeof(T)));
                    entidades.Insert(entidad);
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

        public static bool Entidad_Modificar<T>(T entidad)
        {
            bool rtaResultado;

            try
            {
                using (var db = new LiteDatabase(ArchivosDeDatos))
                {
                    var entidades = db.GetCollection<T>(DevolverNombreColeccion(typeof(T)));
                    entidades.Update(entidad);
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

        #region Unidades de Medida
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
            return UnidadDeMedida_DevolverTodas(false);
        }

        public static List<UnidadDeMedida> UnidadDeMedida_DevolverTodas(bool SoloActivas)
        {
            List<UnidadDeMedida> rtaLista = new List<UnidadDeMedida>();
            using (var db = new LiteDatabase(ArchivosDeDatos))
            {
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>(Coleccion_UnidadesDeMedida);

                foreach (var item in unidadesDeMedida.FindAll())
                {
                    if (SoloActivas && !item.Activa)
                        continue;
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

        public static bool UnidadDeMedida_Eliminar(UnidadDeMedida udm)
        {
            bool rtaResultado;

            try
            {
                udm.Activa = false;
                UnidadDeMedida_Actualizar(udm);
                rtaResultado = true;
            }
            catch (Exception ex)
            {
                rtaResultado = false;
                throw ex;
            }

            return rtaResultado;
        }
        #endregion

        #region IngredienteSimple
        public static List<IngredienteSimple> IngredienteSimple_DevolverTodos()
        {
            List<IngredienteSimple> rtaLista = new List<IngredienteSimple>();
            using (var db = new LiteDatabase(ArchivosDeDatos))
            {
                var iiss = db.GetCollection<IngredienteSimple>(DevolverNombreColeccion(typeof(IngredienteSimple)));



                foreach (var ingsim in iiss.Include(x => x.UdM).FindAll())
                {
                    rtaLista.Add(ingsim);
                }
                return rtaLista;
            }
        }
        #endregion
    }
}
