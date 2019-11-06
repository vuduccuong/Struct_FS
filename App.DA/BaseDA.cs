using App.Base.MyAppModel;
using App.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace App.DA
{
    public class BaseDA: IDisposable
    {
        protected MyAppContext _appContext;
        public BaseDA(MyAppContext appContext)
        {
            this._appContext = appContext;
        }

        /// <summary>
        /// Execute Stored with store name to model
        /// </summary>
        /// <typeparam name="T">Type model</typeparam>
        /// <param name="storedProcName">Store name </param>
        /// <returns></returns>
        public IList<T> GetListDataByStoredProc<T>(string storedProcName)
        {
            var listData = _appContext.LoadStoredProc(storedProcName).ExecuteStoredProc<T>();
            return listData;
        }

        /// <summary>
        /// Creates an initial DbCommand object based on a stored procedure name
        /// </summary>
        /// <param name="storedProcName">target procedure name</param>
        /// <param name="prependDefaultSchema">Prepend the default schema name to <paramref name="storedProcName"/> if explicitly defined in <paramref name="context"/></param>
        /// <param name="commandTimeout">Command timeout in seconds. Default is 30.</param>
        /// <returns></returns>
        public DbCommand LoadStoredProc(string storedProcName, bool prependDefaultSchema = true, short commandTimeout = 30, bool isCreateNewConnection = false)
        {
            //var cmd = FPTShopDB.Database.GetDbConnection().CreateCommand();
            //cmd.CommandText = storedProcName;
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //return cmd;
            return _appContext.LoadStoredProc(storedProcName, prependDefaultSchema, commandTimeout, isCreateNewConnection);
        }

        #region cơ chế dọn rác
        private bool IsDisposed = false;

        public void Free()
        {
            if (IsDisposed)
                throw new System.ObjectDisposedException("Object Name");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseDA()
        {
            //Pass false as param because no need to free managed resources when you call finalize it
            //by GC itself as its work of finalize to manage managed resources.
            Dispose(false);
        }

        //Implement dispose to free resources
        protected virtual void Dispose(bool disposedStatus)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                _appContext.Dispose(); // Released unmanaged Resources
                if (disposedStatus)
                {
                    // Released managed Resources
                }
            }
        }
        #endregion
    }
}
