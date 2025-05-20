using System;

namespace Api.Dto.Exceprion
{
    public class ExceptionDto
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    

        public static ExceptionDto FromException(Exception ex)
        {
            return new ExceptionDto
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };
        }
    }


   
}
