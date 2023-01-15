using AutoMapper;
using MediatR;
using Pizzaria.Application.Commands.ClientAddressCommands;
using Pizzaria.Application.Commands.ClientCommands;
using Pizzaria.Application.Commands.ClientPhoneCommands;
using Pizzaria.Application.DTOs;
using Pizzaria.Application.Services.Interfaces;

namespace Pizzaria.Application.Services;

public  class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ClientService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task AddAsync(ClientDTO dto)
    {
        var client = _mapper.Map<ClientCreateCommand>(dto);
        var address = _mapper.Map<ClientAddressCommand>(dto);
        var phone = _mapper.Map<ClientPhoneCommand>(dto);
      
        var addressResult = await _mediator.Send(address);
        var phoneResult = await _mediator.Send(phone);

        client.ClientAddressId = addressResult.Id;
        client.ClientPhoneId = phoneResult.Id;

        var result = await _mediator.Send(client);
    }
}
