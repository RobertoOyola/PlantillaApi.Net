using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.DB2.iSeries;
using log4net;
using Modelos.Entidades;

namespace Datos.Datos.Pruebas
{
    public class DatosPrueba : IDatosPrueba
    {
        private CsManejoErroresPr Lo_ErrorPr;

        protected string _connectionString = ConfigurationManager.ConnectionStrings["ConexionAS"].ToString();

        private static readonly ILog Log = LogManager.GetLogger(typeof(DatosPrueba));

        public PruebaModelo get(string TipoBanca, decimal monto)
        {
            PruebaModelo resul = new PruebaModelo();
            var nombreProcedimiento = "Procedimiento";

            Log.Info("get ==> Inicio");

            try
            {
                using (iDB2Connection cn = new iDB2Connection(_connectionString))
                {
                    cn.Open();
                    using (iDB2Command cm = new iDB2Command(nombreProcedimiento, CommandType.StoredProcedure, cn))
                    {
                        cm.Parameters.Add("P_OPERA", iDB2DbType.iDB2Char).Value = TipoBanca;
                        cm.Parameters.Add("P_MONTO", iDB2DbType.iDB2Decimal).Value = monto;

                        cm.Parameters.Add("P_CODRET", iDB2DbType.iDB2Decimal).Value = 0;
                        cm.Parameters.Add("P_MSGRET", iDB2DbType.iDB2VarChar).Value = "";

                        cm.Parameters["P_CODRET"].Direction = ParameterDirection.InputOutput;
                        cm.Parameters["P_MSGRET"].Direction = ParameterDirection.InputOutput;

                        using (IDataReader spReader = cm.ExecuteReader())
                        {
                            Lo_ErrorPr.CodigoRetorno = Convert.ToInt32(cm.Parameters["P_CODRET"].Value);
                            Lo_ErrorPr.DescMensUser = cm.Parameters["P_MSGRET"].Value.ToString();
                            Lo_ErrorPr.DescRetorno = cm.Parameters["P_MSGRET"].Value.ToString();

                            if (Lo_ErrorPr.CodigoRetorno == 0)
                            {
                                resul.Codigo = Convert.ToInt32(cm.Parameters["P_CODRET"].Value);
                                resul.Nombre = cm.Parameters["P_MSGRET"].Value.ToString();
                            }
                            if (!spReader.IsClosed) { spReader.Close(); }
                        }

                    }
                }
            }
            catch (FieldAccessException exa)
            {
                Lo_ErrorPr.DescMensUser = "Error en campos";
                Lo_ErrorPr.DescRetorno = exa.Message;
                Lo_ErrorPr.CodigoRetorno = 100;
                Log.Error("get.Excepcion ==> " + exa.Message);
            }
            catch (FormatException exe)
            {
                Lo_ErrorPr.DescMensUser = "Error en formato";
                Lo_ErrorPr.DescRetorno = exe.Message;
                Lo_ErrorPr.CodigoRetorno = 100;
                Log.Error("get.Excepcion ==> " + exe.Message);
            }
            catch (TimeoutException ext)
            {
                Lo_ErrorPr.DescMensUser = "Error en el proceso";
                Lo_ErrorPr.DescRetorno = ext.Message;
                Lo_ErrorPr.CodigoRetorno = 100;
                Log.Error("get.Excepcion ==> " + ext.Message);
            }
            catch (iDB2ConnectionFailedException exd)
            {
                Lo_ErrorPr.DescMensUser = "Error en el proceso";
                Lo_ErrorPr.DescRetorno = exd.Message;
                Lo_ErrorPr.CodigoRetorno = 100;
                Log.Error("get.Excepcion ==> " + exd.Message);
            }
            catch (iDB2ConnectionTimeoutException ex)
            {
                Lo_ErrorPr.DescMensUser = "Error en el proceso";
                Lo_ErrorPr.DescRetorno = ex.Message;
                Lo_ErrorPr.CodigoRetorno = 100;
                Log.Error("get.Exception ==> " + ex.Message);
            }

            Log.Info("get.fin ");
            return resul;
        }

    }
}
