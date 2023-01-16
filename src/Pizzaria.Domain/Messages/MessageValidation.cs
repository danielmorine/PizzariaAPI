namespace Pizzaria.Domain.Messges;

public static class MessageValidation
{
    public const string InvalidId = "Id não informado";
    public const string IngredientNameIsRequired = "Nome do ingrediente é obrigatório";    
    public const string IngredientNameIsToLarge = "Nome do ingrediente é maior que 50 caracteres";    
    public const string ProductNameIsRequired = "Nome do produto é obrigatório";
    public const string ProductNameIsToLarge = "Nome do produto é maior que 50 caracteres";    
    public const string ClientNameIsRequired = "Nome do cliente é obrigatório";    
    public const string ClientNameIsToLarge = "Nome do cliente é maior que 250 caracteres";    
    public const string ClientPhoneRegionIsRequired = "DDD é obrigatório";    
    public const string ClientPhoneNumberIsRequired = "Número de telefone é obrigatório";
    public const string ClientPhoneNumberIsToLargeRequired = "DDD do telefone maior que 3 caracteres";    
    public const string ClientPhoneRegionIsToLargeRequired = "Número de telefone maior 10 caracteres";    
    public const string ClientAddressAddressIsRequired = "Endereço é obrigatório";    
    public const string ClientAddressAddressIsToLarge = "Endereço maior que 200 caracteres";    
    public const string ClientAddressNumberIsRequired = "Número do endereço é obrigatório";    
    public const string ClientAddressNumberIsToLarge = "Número do endereço maior 10 caracteres";    
    public const string ClientAddressCityIsRequired = "Cidade é obrigatório";
    public const string ClientAddressCityIsToLarge = "Cidade maior que 300 caracteres";    
    public const string ClientAddressZipCodeIsRequired = "CEP é obrigatório";    
    public const string ClientAddressZipCodeIsToLarge = "CEP maior que 10 caracteres";    
    public const string UserOrPasswordInvalid = "Usuário ou senha inválido";
    public const string UserRegisterFailure = "Falha ao tentar registar o usúario";
    public const string IngredientNotFound = "Falha ao buscar um ingrediente com o id informado";
    public const string IngredientDeleteFailed = "Falha ao tentar deletar o ingrediente";
}
