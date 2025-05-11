using Api.Dto.Currences;
using Api.Models;

namespace Api.Mappers
{
    public static class CurrenceMappers
    {
        public static CurrenceDto ToCurrenceDTO(this Currencie currencieModel)
        {
            return new CurrenceDto
            {
                Code = currencieModel.Code,
                Rate = currencieModel.Rate,
            };
        }

        public static Currencie ToCurrenceFromDto(this CurrenceDto currenceDto)
        {
            return new Currencie
            {
                Code = currenceDto.Code,
                Rate = currenceDto.Rate,
            };
        }
    }
}
