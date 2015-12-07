using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    public class Result<TEntity> where TEntity : new()
    {
        public Result()
        {
            Code = 0;
            Msg = "获取成功";
            Content = new TEntity();
        }
        public int Code { get; set; }
        public string Msg { get; set; }
        public TEntity Content { get; set; }
    }
}
