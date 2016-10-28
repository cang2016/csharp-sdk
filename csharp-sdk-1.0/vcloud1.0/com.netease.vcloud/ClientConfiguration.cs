using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vcloud1._0.com.netease.vcloud
{
    public class ClientConfiguration
    {
        /// <summary>
        /// 默认的连接超时时限  10秒
        /// </summary>
        public const int DEFAULT_CONNECTION_TIMEOUT = 10 * 1000;

        /// <summary>
        /// 连接超时时限 
        /// </summary>
        private int connectionTimeout = DEFAULT_CONNECTION_TIMEOUT;

        public int ConnectionTimeout
        {
            get { return connectionTimeout; }
            set { connectionTimeout = value; }
        }

        public ClientConfiguration()
        {

        }
        /// <summary>
        /// 传入连接超时时限
        /// </summary>
        /// <param name="connectionTimeout"></param>
        public ClientConfiguration(int connectionTimeout)
        {
            this.connectionTimeout = connectionTimeout;
        }
    }
}
