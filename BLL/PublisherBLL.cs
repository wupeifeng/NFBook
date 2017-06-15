using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    /// <summary>
    /// 出版社信息
    /// </summary>
    public class PublisherBLL
    {
        PublisherDAL dal = new PublisherDAL();
        //获取所有出版社信息列表
        public List<Publisher> GetPublisher()
        {
            return dal.GetPublisher();
        }
        public Publisher GetPublisher(int id)
        {
            return dal.GetPublisher(" where [ID]="+id)[0];
        }
        public List<Publisher> GetPublisher(int pid = -1, bool isTrue = true)
        {
            if (pid == -1)
                return dal.GetPublisher();
            else
                return dal.GetPublisher(" where ID=" + pid);
        }

        //添加出版社
        public int InsertPublisher(Publisher pbs)
        {
            return dal.InsertPublisher(pbs);
        }
        //更新出版社信息
        public int UpdatePublisher(Publisher pbs)
        {
            return dal.UpdatePublisher(pbs);
        }
        //删除出版社
        public int DeletePublisher(string id)
        {
            return dal.DeletePublisher(id);
        }
    }
}
