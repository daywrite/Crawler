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
        /// 1=����ͼƬ;
        /// 2=����ͼƬ
        /// 3=�����ĵ�
        /// 4=������Ƶ
        /// 5=�����ļ�
        /// </summary>
        public int BindType;                   //��ִ�еĹ����ļ�����
        public string Name;				        //�ֶ��������ֶε�����

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        internal string GetBindName()
        {
            if (BindType == 1)
            {
                return "����ͼƬ";
            }
            else if (BindType == 2)
            {
                return "����ͼƬ";
            }
            else if (BindType == 3)
            {
                return "�����ĵ�";
            }
            else if (BindType == 4)
            {
                return "������Ƶ";
            }
            else if (BindType == 5)
            {
                return "�����ļ�";
            }
            else if (BindType >= 10000)
            {
                return "��������";
            }
            return null;
        }
        /// <summary>
        /// �󶨵�LineID
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
	/// �ֶ�ӳ�䣬������Ԫ���ݷ��뷽ʽ��������������˵����
	/// </summary>
    [Serializable]
    public class MetaFeild : BaseFeild
    {
         public int ID;				            //�ֶ�λ������
         public string Script;				    //ȡֵ�ű�
        /// <summary>
        /// �ֶε���Ч��
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
    ///  ��ȡ�ֶμ��ϡ�
    /// </summary>
    [Serializable]
    public class FeildCollection : List<MetaFeild>
    {
        /// <summary>
        /// ͨ���ֶ����ƻ�ȡ�ֶ�
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
