using System;
using System.Threading.Tasks;
using MyProject.Gifts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.Gifts
{
    public class GiftAppService : CrudAppService<Gift, GiftDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateGiftDto, CreateUpdateGiftDto>,
        IGiftAppService
    {
        private readonly IGiftRepository _repository;

        public GiftAppService(IGiftRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<GiftDto> GetByNameAsync(string name)
        {
            return ObjectMapper.Map<Gift, GiftDto>(await _repository.GetAsync(name));
        }
    }
}