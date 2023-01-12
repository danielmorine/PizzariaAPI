using System.ComponentModel;

namespace Pizzaria.Domain.Enums
{
    public enum MessageValidationEnum
    {
        [Description("Id não informado")]
        InvalidId = 0,

        [Description("Nome do ingrediente é obrigatório")]
        IngredientNameIsRequired = 1,

        [Description("Nome do ingrediente é maior que 50 caracteres")]
        IngredientNameIsToLarge = 2,

        [Description("Nome do produto é obrigatório")]
        ProductNameIsRequired = 3,

        [Description("Nome do produto é maior que 50 caracteres")]
        ProductNameIsToLarge = 4,

        [Description("Nome do cliente é obrigatório")]
        ClientNameIsRequired = 5,

        [Description("Nome do cliente é maior que 250 caracteres")]
        ClientNameIsToLarge = 6,

        [Description("DDD é obrigatório")]
        ClientPhoneRegionIsRequired = 7,

        [Description("Número de telefone é obrigatório")]
        ClientPhoneNumberIsRequired = 8,

        [Description("DDD do telefone maior que 3 caracteres")]
        ClientPhoneNumberIsToLargeRequired = 9,

        [Description("Número de telefone maior 10 caracteres")]
        ClientPhoneRegionIsToLargeRequired = 10,

        [Description("Endereço é obrigatório")]
        ClientAddressAddressIsRequired = 11,

        [Description("Endereço maior que 200 caracteres")]
        ClientAddressAddressIsToLarge = 12,

        [Description("Número do endereço é obrigatório")]
        ClientAddressNumberIsRequired = 13,

        [Description("Número do endereço maior 10 caracteres")]
        ClientAddressNumberIsToLarge = 14,

        [Description("Cidade é obrigatório")]
        ClientAddressCityIsRequired = 15,

        [Description("Cidade maior que 300 caracteres")]
        ClientAddressCityIsToLarge = 16,

        [Description("CEP é obrigatório")]
        ClientAddressZipCodeIsRequired = 17,

        [Description("CEP maior que 10 caracteres")]
        ClientAddressZipCodeIsToLarge = 18

    }
}
