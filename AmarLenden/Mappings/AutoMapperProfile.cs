using AmarLenden.DTOs;
using AmarLenden.Model;
using AmarLenden.ViewModels;
using AutoMapper;

namespace AmarLendenAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<BudgetVM, Budget>();

            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<AccountVM, Account>();

            CreateMap<Voucher, VoucherDto>().ReverseMap();
            CreateMap<VoucherLine, VoucherLineDto>().ReverseMap();

            CreateMap<VoucherVM, Voucher>();
            CreateMap<VoucherLineVM, VoucherLine>();


        }
    }
}
