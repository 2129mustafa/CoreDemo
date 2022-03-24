using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal:IGenericDal<Message2>
    {
        List<Message2> GetInboxWithMessage2ByWriter(int id);
        List<Message2> GetSendWithMessage2ByWriter(int id);
    }
}
