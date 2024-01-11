using AutoMapper;
using FluentValidation;
using hshmedstats.Application.Dtos;
using hshmedstats.Application.Interfaces;
using System.Threading.Tasks;

namespace hshmedstats.Application.Handlers
{
    public class HRequest<T> where T : IBaseDto
    {
        protected readonly IHshDbContext _DbContext;
        protected readonly IMapper _Mapper;
        protected IValidator<T> _Validator;

        public HRequest(IHshDbContext dbContext = null, IMapper mapper = null, IValidator<T> validator = null)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
            _Validator = validator;
        }

        public async Task<bool> Validate(T entity)
        {
            var validationResult = await _Validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                entity.SetValidationResult(validationResult);
            }

            return validationResult.IsValid;
        }
    }
}
