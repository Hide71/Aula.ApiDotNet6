using FluentValidation.Results;

namespace Aula.ApiDotNet6.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; private set; } = true;
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public string Message { get; set; }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public ICollection<ErrorValidation> Errors { get; set; }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation
                {
                    Field = x
                .PropertyName,
                    Message = x.ErrorMessage
                }).ToList()
            };
        }
        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation
                {
                    Field = x
                .PropertyName,
                    Message = x.ErrorMessage
                }).ToList()
            };
        }
        public static ResultService Fail(string message) => new ResultService
        {
            IsSuccess = false,
            Message = message
        };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };
        public static ResultService Ok(string message) => new ResultService
        {
            IsSuccess = true,
            Message = message
        };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T>
        {
            IsSuccess = true,
            Data = data
        };

    }
    public class ResultService<T> : ResultService
    {
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public T Data { get; set; }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.


    }
}
