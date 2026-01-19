using SagiCore.Communication.Requests.Cadastro.Produto;
using SagiCore.Communication.Responses.Cadastro.Produto;
using SagiCore.Domain.Repositories;
using SagiCore.Domain.Repositories.Cadastro.Produto;
using SagiCore.Exceptions;
using SagiCore.Exceptions.ExceptionsBase;

namespace SagiCore.Application.UseCases.Cadastro.Produto.Register
{
    public class RegisterProdutoUseCase : IRegisterProdutoUseCase
    {
        private readonly IProdutoWriteRepository _produtoWriteRepository;
        private readonly IProdutoReadRepository _produtoReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterProdutoUseCase(
            IProdutoWriteRepository produtoWriteRepository, 
            IProdutoReadRepository produtoReadRepository,
            IUnitOfWork unitOfWork)
        {
            _produtoWriteRepository = produtoWriteRepository;
            _produtoReadRepository = produtoReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredProdutoJson> Execute(RequestRegisterProdutoJson request)
        {
            // 1- Validar a request
            // 2- Mapear a request em uma entidade
            // 3- Salvar a entidade no banco de dados

            await Validate(request);

            // Automapper pode ser usado aqui para mapear a request para a entidade
            // porem agora é pago, Mapster é uma opção a ser estudada
            var produto = new Domain.Entities.Cadastro.Produto
            {
                codpro = request.codpro,
                subcod = request.subcod,
                produto = request.produto,
                un = request.un,
                tp_prod = request.tp_prod,
                ncm = request.ncm,
                diverso = request.diverso,
                codcat = request.codcat,
                tipo_pesquisa = request.tipo_pesquisa,
                codref1 = request.codref1,
                codref2 = request.codref2,
            };

            await _produtoWriteRepository.Add(produto);
            await _unitOfWork.Commit();

            return new ResponseRegisteredProdutoJson
            {
                codpro = request.codpro,
                subcod = request.subcod,
                produto = request.produto,
            };
        }

        private async Task Validate(RequestRegisterProdutoJson request)
        {
            // Validação das propriedades da request

            var validator = new RegisterProdutoValidator();

            var result = validator.Validate(request);

            var produtoExiste = await _produtoReadRepository.ExisteProdutoComCodproRepetido(request.codpro, request.subcod);
            if (produtoExiste)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.PRODUCT_ALREADY_REGISTERED));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
