using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jwtokencore.Api.Core.Shared.Contracts
{
    public interface IProcessorRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IProcessorRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
