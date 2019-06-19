using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.CommandHandlers
{
    public class BaseHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;

        public BaseHandler(IUnitOfWork unitOfWork, IMediatorHandler bus)
        {
            this._unitOfWork = unitOfWork;
            this._bus = bus;
        }

        public bool Commit()
        {

            if (_unitOfWork.Commit())
            {
                return true;
            }
            else
            {
                //提交失败
                //todo 发送提交失败的领域事件
                return false;
            }
        }
    }
}
