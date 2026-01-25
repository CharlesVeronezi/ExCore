using AutoMapper;
using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Cadastros.Domain.Repositories;
using SagiCore.Communication.Responses.Cadastro.Produto;
using SagiCore.Exceptions;
using SagiCore.Exceptions.ExceptionsBase;
using SagiCore.Shared.Application.Abstractions;
using SagiCore.Shared.Domain.Repositories;

namespace SagiCore.Cadastros.Application.Produtos.Register
{
    public class RegisterProdutoUseCase : IUseCaseHandler<RegisterProdutoCommand, ResponseRegisteredProdutoJson>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisteredProdutoJson> Handle(
            RegisterProdutoCommand request,
            CancellationToken cancellationToken)
        {
            // Validação de negócio (produto duplicado)
            var produtoExiste = await _produtoRepository.ExisteComMesmoCodigo(
                request.Codpro,
                request.Subcod,
                cancellationToken);

            if (produtoExiste)
            {
                throw new ErrorOnValidationException(
                    new List<string> { ResourceMessagesException.PRODUCT_ALREADY_REGISTERED });
            }

            var produto = _mapper.Map<Produto>(request);

            await _produtoRepository.AddAsync(produto, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<ResponseRegisteredProdutoJson>(produto);
        }
    }
}
