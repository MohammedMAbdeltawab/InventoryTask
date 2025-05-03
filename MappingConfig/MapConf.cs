using InventoryTask.Entities;
using AutoMapper;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Dtos.User;

namespace InventoryTask.MappingConfig
{
    public class MapConf:Profile
    {
        public MapConf()
        {
            CreateMap<Transaction, TransactionRequest>().ReverseMap();
            CreateMap<Transaction, TransactionResponse>().ReverseMap();
            CreateMap<LoginUser, AppUser>().ReverseMap();
            CreateMap<CreateUser, AppUser>().ReverseMap();
        }
    }
}
