using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using Lwb.Crawler.Contract;
using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Service.Crawl;
using Lwb.Unitity.Data;
using System.Runtime.Remoting.Messaging;
using Haina.Base;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Lwb.Crawler.Service
{
    /// <summary>
    /// Wcf服务器数据交互接口
    /// </summary>
    public class CrawlerService : ICrawler
    {      
        public LwbResult LwbEach(LwbInput pLwbInput)
        {           
            //参数为null，不合法，返回null
            if (pLwbInput == null)
                return new LwbResult(LwbResultType.QueryNull);

            //获取调用者的Ip，并将Ip整数化
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            uint sIntIp = IpV4Converter.ToInt((string)endpoint.Address ?? "127.0.0.1");

            try
            {
                if (pLwbInput.Type == (int)CrawlCmd.获取生产线任务列表)
                {
                    var sInput获取生产线任务列表 = pLwbInput.Data as Input获取生产线任务列表;
                    if (sInput获取生产线任务列表 == null)
                        return new LwbResult(LwbResultType.Error, "获取生产线任务列表-传入实体类格式有误");

                    Dictionary<string, string> sDic = new Dictionary<string, string>();
                    List<string> sIn列表 = sInput获取生产线任务列表.RuningTaskHost;

                    if (sIn列表 != null && sIn列表.Count > 0)
                    {
                        sIn列表.ForEach(t => sDic[t.ToString()] = t);
                    }

                    return new LwbResult(LwbResultType.Success,
                        "获取生产线任务列表成功",
                        CrawlServer.GetCrawlTasks(sDic, sIntIp, sInput获取生产线任务列表.TaskMax));
                }
                else if (pLwbInput.Type == (int)CrawlCmd.发送爬行任务)
                {
                    var sCrawlResult = pLwbInput.Data as CrawlResult;
                    if (sCrawlResult == null)
                        return new LwbResult(LwbResultType.Error, "获取爬虫回送任务失败");

                    sCrawlResult.IP = sIntIp;

                    CrawlServer.ReceiveCrawlResult(sCrawlResult);

                    return new LwbResult(LwbResultType.Success, "获取爬虫回送任务成功");
                }
                else
                {
                    return new LwbResult(LwbResultType.Error, "获取生产线任务列表-传入【Type】有误");
                }
            }
            catch (Exception ee)
            {
                return new LwbResult(LwbResultType.Error, ee.Message);
            }

        }        
    }
}
