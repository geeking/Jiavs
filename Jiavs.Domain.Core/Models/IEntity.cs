using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Models
{
    /// <summary>
    /// 所有领域模型的约束接口
    /// </summary>
    public interface IEntity
    {
        uint Id { get; set; }

    }
}
