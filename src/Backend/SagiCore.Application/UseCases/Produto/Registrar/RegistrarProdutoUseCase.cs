using SagiCore.Communication.Requests;
using SagiCore.Communication.Responses;
using SagiCore.Domain.Repositories;
using SagiCore.Exceptions.ExceptionsBase;

namespace SagiCore.Application.UseCases.Produto.Registrar
{
    public class RegistrarProdutoUseCase
    {
        private readonly IProdutoWriteRepository _produtoWriteRepository;
        private readonly IProdutoReadRepository _produtoReadRepository;

        public async Task<ResponseProdutoRegistradoJson> Executar(RequestRegistrarProdutoJson request)
        {
            // 1- Validar a request
            // 2- Mapear a request em uma entidade
            // 3- Salvar a entidade no banco de dados

            Validar(request);

            // Automapper pode ser usado aqui para mapear a request para a entidade
            // porem agora é pago, Mapster é uma opção a ser estudada
            var produto = new Domain.Entities.Produto
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
            };

            await _produtoWriteRepository.Add(produto);

            return new ResponseProdutoRegistradoJson
            {
                codpro = request.codpro,
                subcod = request.subcod,
                produto = request.produto,
            };
        }

        private void Validar(RequestRegistrarProdutoJson request)
        {
            // Validação das propriedades da request

            var validator = new RegisterProdutoValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
