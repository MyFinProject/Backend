using Api.Dto.Currences;
using Api.Models;

namespace Api.Mappers
{
    public static class CurrencyMappers
    {
        public static CurrencyDto ToCurrenceDTO(this Currency currencieModel)
        {
            return new CurrencyDto
            {
                Code = currencieModel.Code,
                Rate = currencieModel.Rate,
            };
        }

        public static Currency ToCurrenceFromDto(this CurrencyDto currenceDto)
        {
            return new Currency
            {
                Code = currenceDto.Code,
                Rate = currenceDto.Rate,
            };
        }
    }
}
