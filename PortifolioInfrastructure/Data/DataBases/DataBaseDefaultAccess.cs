using Dapper;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortifolioInfrastructure.Data.DataBases
{
    public class DataBaseDefaultAccess
    {
        private IDbConnection? _con = null;
        #region Relational Data Base

        public IDbConnection conectar(DataBaseConnection bd)
        {
            _con = bd.Type.ToUpper().Trim() switch
            {
                "SQLSERVER" => new SqlConnection(bd.ConnectionString),
                "ORACLE" => new OracleConnection(bd.ConnectionString),
                "MYSQL" => new MySqlConnection(bd.ConnectionString),
                "POSTGRESQL" => new NpgsqlConnection(bd.ConnectionString),
                _ => throw new Exception("Database type not supported"),
            };

            if (_con.State == ConnectionState.Closed)
            {
                if (String.IsNullOrEmpty(_con.ConnectionString))
                {
                    _con.ConnectionString = _con.ConnectionString = bd.ConnectionString;
                }
                _con.Open();
            }

            return _con;
        }

        public async Task<T?> ProcedureFirstOrDefault<T>(string sQuery, object parameter, DataBaseConnection connection)
        {
            using (var _DBConnection = conectar(connection))
            {
                return _DBConnection.QueryFirstOrDefault<T>(sQuery, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<T>?> Procedure<T>(string sQuery, object parameter, DataBaseConnection connection)
        {
            using (var _DBConnection = conectar(connection))
            {
                return _DBConnection.Query<T>(sQuery, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public async Task<List<dynamic>?> ProcedureMultipleTable(string sQuery, object parameter, DataBaseConnection connection)
        {
            List<dynamic> objReturn = new List<dynamic>();
            using (var _DBConnection = conectar(connection))
            {
                var result = _DBConnection.QueryMultiple(sQuery, parameter, commandType: CommandType.StoredProcedure);

                while (!result.IsConsumed)
                {
                    try
                    {
                        objReturn.Add(result.Read<dynamic>());
                    }
                    catch
                    {
                        return null;
                    }

                }
            }

            return objReturn;
        }


        public async Task<T?> QueryFirstOrDefault<T>(string sQuery, object parameter, DataBaseConnection connection)
        {
            using (var _DBConnection = conectar(connection))
            {
                return _DBConnection.QueryFirstOrDefault<T>(sQuery, parameter);
            }
        }

        public async Task<List<T>?> Query<T>(string sQuery, object parameter, DataBaseConnection connection)
        {
            using (var _DBConnection = conectar(connection))
            {
                return _DBConnection.Query<T>(sQuery, parameter).ToList();
            }
        }
        #endregion
    }
}
