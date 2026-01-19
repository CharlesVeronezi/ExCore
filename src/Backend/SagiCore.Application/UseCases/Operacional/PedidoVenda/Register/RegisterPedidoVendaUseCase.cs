using SagiCore.Communication.Requests.Operacional.PedidoVenda;
using SagiCore.Communication.Responses.Operacional.PedidoVenda;
using SagiCore.Domain.Entities.Operacional;
using SagiCore.Domain.Repositories;
using SagiCore.Domain.Repositories.Operacional.PedidoVenda;
using SagiCore.Exceptions;
using SagiCore.Exceptions.ExceptionsBase;

namespace SagiCore.Application.UseCases.Operacional.PedidoVenda.Register
{
    public class RegisterPedidoVendaUseCase : IRegisterPedidoVendaUseCase
    {
        private readonly IPedidoVendaWriteRepository _pedidoVendaWriteRepository;
        private readonly IPedidoVendaReadRepository _pedidoVendaReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterPedidoVendaUseCase(
            IPedidoVendaWriteRepository pedidoVendaWriteRepository,
            IPedidoVendaReadRepository pedidoVendaRepository,
            IUnitOfWork unitOfWork)
        {
            _pedidoVendaWriteRepository = pedidoVendaWriteRepository;
            _pedidoVendaReadRepository = pedidoVendaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredPedidoVendaJson> Execute(RequestRegisterPedidoVendaJson request)
        {
            await Validate(request);

            var pedidoVenda = new Domain.Entities.Operacional.PedidoVenda
            {
                pednum = request.pednum,
                dataped = request.dataped,
                dataval = request.dataval,
                codcli = request.codcli,
                cliente = request.cliente,
                codvnd = request.codvnd,
                vendedor = request.vendedor,
                prazo_ent = request.prazo_ent,
                obs = request.obs,
                ende_entre = request.ende_entre,
                num_entre = request.num_entre,
                bai_entre = request.bai_entre,
                cid_entre = request.cid_entre,
                uf_entre = request.uf_entre,
                cep_entre = request.cep_entre,
                usuario = request.usuario,
                data = request.data,
                hora = request.hora,
                status = request.status,
                empresa = request.empresa,
                vlrfrete = request.vlrfrete,
                seguro = request.seguro,
                moeda = request.moeda,
                unidade = request.unidade,
                Itens = request.itens.Select(item => new PedidoVendaItem
                {
                    pednum = request.pednum,
                    dataped = request.dataped,
                    codcli = request.codcli,
                    codpro = item.codpro,
                    subcod = item.subcod,
                    produto = item.produto,
                    un = item.un,
                    peso = item.peso,
                    preco = item.preco,
                    preco_nf = item.preco_nf,
                    total = item.total,
                    frete = item.frete,
                    prazo = item.prazo,
                    condicao = item.condicao,
                    vlrdesconto = item.vlrdesconto,
                    icms = item.icms,
                    ipi = item.ipi,
                    cfop = item.cfop,
                    cst = item.cst,
                    usuario = item.usuario,
                    data = item.data,
                    hora = item.hora,
                    status = item.status,
                    empresa = item.empresa,
                    obs_iten = item.obs_iten
                }).ToList()
            };

            await _pedidoVendaWriteRepository.Add(pedidoVenda);
            await _unitOfWork.Commit();

            return new ResponseRegisteredPedidoVendaJson
            {
                pednum = pedidoVenda.pednum,
                dataped = pedidoVenda.dataped,
                codcli = pedidoVenda.codcli,
                cliente = pedidoVenda.cliente,
                status = pedidoVenda.status,
                itens = pedidoVenda.Itens.Select(item => new ResponsePedidoVendaItemJson
                {
                    codpro = item.codpro,
                    produto = item.produto,
                    peso = item.peso,
                    preco = item.preco,
                    total = item.total
                }).ToList()
            };
        }

        private async Task Validate(RequestRegisterPedidoVendaJson request)
        {
            var validator = new RegisterPedidoVendaValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
