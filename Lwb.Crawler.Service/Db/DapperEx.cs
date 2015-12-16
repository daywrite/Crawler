using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperEx
{
    public static class DapperEx
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="lt"></param>
        /// <param name="useTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static bool InsertBatch<T>(this DbBase dbs, IList<T> lt, bool useTransaction = false, int? commandTimeout = null) where T : class,new()
        {
            var db = dbs.DbConnecttion;
            IDbTransaction tran = null;
            if (useTransaction)
                tran = db.BeginTransaction();
            var result = false;
            var tbName = Common.GetTableName<T>();
            var columns = Common.GetExecColumns<T>();
            var flag = db.Execute(CreateInertSql(tbName, columns, dbs.ParamPrefix), lt, tran, commandTimeout);
            if (tran != null)
            {
                try
                {
                    tran.Commit();
                    result = true;
                }
                catch
                {
                    tran.Rollback();
                }
            }
            else
            {
                return flag == lt.Count;
            }
            return result;
        }
    }
}
