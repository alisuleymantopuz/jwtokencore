using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Shared.Contracts
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
