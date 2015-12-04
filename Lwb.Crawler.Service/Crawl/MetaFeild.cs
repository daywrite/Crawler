using System;
using System.Collections;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace Lwb.Crawler.Service.Crawl
{
    [Serializable]
    public class BaseFeild
    {
        /// <summary>
        /// 1=封面图片;
        /// 2=关联图片
        /// 3=关联文档
        /// 4=关联视频
        /// 5=关联文件
        /// </summary>
        public int BindType;                   //绑定执行的关联文件下载
        public string Name;				        //字段名，对字段的命名

        /// <summary>
        /// 获取绑定名称
        /// </summary>
        /// <returns></returns>
        internal string GetBindName()
        {
            if (BindType == 1)
            {
                return "封面图片";
            }
            else if (BindType == 2)
            {
                return "关联图片";
            }
            else if (BindType == 3)
            {
                return "关联文档";
            }
            else if (BindType == 4)
            {
                return "关联视频";
            }
            else if (BindType == 5)
            {
                return "关联文件";
            }
            else if (BindType >= 10000)
            {
                return "绑定生产线";
            }
            return null;
        }
        /// <summary>
        /// 绑定的LineID
        /// </summary>
        internal int BindLineID
        {
            get
            {
                if (BindType > 10000)
                {
                    return BindType - 10000;
                }
                return 0;
            }
            set
            {
                BindType = 10000 + value;
            }
        }
    }
	/// <summary>
	/// 字段映射，定义了元数据分离方式、和命名及涵义说明。
	/// </summary>
    [Serializable]
    public class MetaFeild : BaseFeild
    {
         public int ID;				            //字段位置索引
         public string Script;				    //取值脚本
        /// <summary>
        /// 字段的有效性
        /// </summary>
        /// <returns></returns>
        internal bool Valid()
        {
            return Script != null && Script.Trim().Length>0;
        }

        internal MetaFeild Clone()
        {
            MetaFeild sMetaFeild=new MetaFeild();
            sMetaFeild.BindType=BindType;
            sMetaFeild.ID=ID;
            sMetaFeild.Name=Name;
            sMetaFeild.Script = Script;
            return sMetaFeild;
        }
    }

    /// <summary>
    ///  提取字段集合。
    /// </summary>
    [Serializable]
    public class FeildCollection : List<MetaFeild>
    {
        /// <summary>
        /// 通过字段名称获取字段
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public MetaFeild GetByName(string pName)
        {
            if (pName != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (pName.Equals(base[i].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return base[i];
                    }
                }
            }
            return null;
        }

        internal FeildCollection Clone()
        {
            FeildCollection sFeildCollection = new FeildCollection();
            for (int i = 0; i < Count; i++)
            {
                sFeildCollection.Add(this[i].Clone());
            }
            return sFeildCollection;
        }
    }
}
