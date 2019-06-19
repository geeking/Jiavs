using FluentValidation.Results;
using MediatR;
using System;

namespace Jiavs.Domain.Core.Commands
{
    /// <summary>
    /// 命令抽象基类，单播
    /// </summary>
    public abstract class BaseCommand : IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected BaseCommand()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}