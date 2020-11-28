using AutoMapper;
using Entities;
using WebTSJ.Models;

namespace WebTSJ
{
    public class AutoMapperConfig
    {
        public class BillMappingProfile : Profile
        {
            public BillMappingProfile()
            {
                CreateMap<Bill, BillModel>()
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.IdCompany, opt => opt.MapFrom(src => src.IdCompany))
                    .ForMember(copy => copy.IdJilez, opt => opt.MapFrom(src => src.IdJilez));

                CreateMap<BillModel, Bill>()
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.IdCompany, opt => opt.MapFrom(src => src.IdCompany))
                    .ForMember(copy => copy.IdJilez, opt => opt.MapFrom(src => src.IdJilez));
            }
        }

        public class JilezMappingProfile : Profile
        {
            public JilezMappingProfile()
            {
                CreateMap<Jilez, JilezModel>()
                    .ForMember(copy => copy.Fsl, opt => opt.MapFrom(src => src.Fsl))
                    .ForMember(copy => copy.HouseAddress, opt => opt.MapFrom(src => src.HouseAddress))
                    .ForMember(copy => copy.NumberFlat, opt => opt.MapFrom(src => src.NumberFlat))
                    .ForMember(copy => copy.PassportId, opt => opt.MapFrom(src => src.PassportId));

                CreateMap<JilezModel, Jilez>()
                    .ForMember(copy => copy.Fsl, opt => opt.MapFrom(src => src.Fsl))
                    .ForMember(copy => copy.HouseAddress, opt => opt.MapFrom(src => src.HouseAddress))
                    .ForMember(copy => copy.NumberFlat, opt => opt.MapFrom(src => src.NumberFlat))
                    .ForMember(copy => copy.PassportId, opt => opt.MapFrom(src => src.PassportId));
            }
        }

        public class DistrictMappingProfile : Profile
        {
            public DistrictMappingProfile()
            {
                CreateMap<District, DistrictModel>()
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName));

                CreateMap<DistrictModel, District>()
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName));
            }
        }

        public class FloatCounterMappingProfile : Profile
        {
            public FloatCounterMappingProfile()
            {
                CreateMap<FloatCounter, FloatCounterModel>()
                    .ForMember(copy => copy.Electricity, opt => opt.MapFrom(src => src.Electricity))
                    .ForMember(copy => copy.Gas, opt => opt.MapFrom(src => src.Gas))
                    .ForMember(copy => copy.Water, opt => opt.MapFrom(src => src.Water))
                    .ForMember(copy => copy.IdOwner, opt => opt.MapFrom(src => src.IdOwner));

                CreateMap<FloatCounterModel, FloatCounter>()
                    .ForMember(copy => copy.Electricity, opt => opt.MapFrom(src => src.Electricity))
                    .ForMember(copy => copy.Gas, opt => opt.MapFrom(src => src.Gas))
                    .ForMember(copy => copy.Water, opt => opt.MapFrom(src => src.Water))
                    .ForMember(copy => copy.IdOwner, opt => opt.MapFrom(src => src.IdOwner));
            }
        }

        public class HouseMappingProfile : Profile
        {
            public HouseMappingProfile()
            {
                CreateMap<House, HouseModel>()
                    .ForMember(copy => copy.CountFloor, opt => opt.MapFrom(src => src.CountFloor))
                    .ForMember(copy => copy.CountPodezd, opt => opt.MapFrom(src => src.CountPodezd))
                    .ForMember(copy => copy.IdAddress, opt => opt.MapFrom(src => src.IdAddress))
                    .ForMember(copy => copy.IdCompany, opt => opt.MapFrom(src => src.IdCompany))
                    .ForMember(copy => copy.IdDistrict, opt => opt.MapFrom(src => src.IdDistrict));

                CreateMap<HouseModel, House>()
                    .ForMember(copy => copy.CountFloor, opt => opt.MapFrom(src => src.CountFloor))
                    .ForMember(copy => copy.CountPodezd, opt => opt.MapFrom(src => src.CountPodezd))
                    .ForMember(copy => copy.IdAddress, opt => opt.MapFrom(src => src.IdAddress))
                    .ForMember(copy => copy.IdCompany, opt => opt.MapFrom(src => src.IdCompany))
                    .ForMember(copy => copy.IdDistrict, opt => opt.MapFrom(src => src.IdDistrict));
            }
        }

        public class HouseCounterMappingProfile : Profile
        {
            public HouseCounterMappingProfile()
            {
                CreateMap<HouseCounter, HouseCounterModel>()
                    .ForMember(copy => copy.Electricity, opt => opt.MapFrom(src => src.Electricity))
                    .ForMember(copy => copy.Gas, opt => opt.MapFrom(src => src.Gas))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.Water, opt => opt.MapFrom(src => src.Water));
                
                CreateMap<HouseCounterModel, HouseCounter>()
                    .ForMember(copy => copy.Electricity, opt => opt.MapFrom(src => src.Electricity))
                    .ForMember(copy => copy.Gas, opt => opt.MapFrom(src => src.Gas))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.Water, opt => opt.MapFrom(src => src.Water));

            }
        }

        public class ListServicesMappingProfile : Profile
        {
            public ListServicesMappingProfile()
            {
                CreateMap<ListServices, ListServicesModel>()
                    .ForMember(copy => copy.Amount, opt => opt.MapFrom(src => src.Amount))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.IdBill, opt => opt.MapFrom(src => src.IdBill))
                    .ForMember(copy => copy.IdService, opt => opt.MapFrom(src => src.IdService));
                
                CreateMap<ListServicesModel, ListServices>()
                    .ForMember(copy => copy.Amount, opt => opt.MapFrom(src => src.Amount))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(copy => copy.IdBill, opt => opt.MapFrom(src => src.IdBill))
                    .ForMember(copy => copy.IdService, opt => opt.MapFrom(src => src.IdService));

            }
        }

        public class ManageCompanyMappingProfile : Profile
        {
            public ManageCompanyMappingProfile()
            {
                CreateMap<ManageCompany, ManageCompanyModel>()
                    .ForMember(copy => copy.CountHouse, opt => opt.MapFrom(src => src.CountHouse))
                    .ForMember(copy => copy.FslOwner, opt => opt.MapFrom(src => src.FslOwner))
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName))
                    .ForMember(copy => copy.OfficeAddress, opt => opt.MapFrom(src => src.OfficeAddress));
                
                CreateMap<ManageCompanyModel, ManageCompany>()
                    .ForMember(copy => copy.CountHouse, opt => opt.MapFrom(src => src.CountHouse))
                    .ForMember(copy => copy.FslOwner, opt => opt.MapFrom(src => src.FslOwner))
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName))
                    .ForMember(copy => copy.OfficeAddress, opt => opt.MapFrom(src => src.OfficeAddress));

            }
        }

        public class ReceiptMappingProfile : Profile
        {
            public ReceiptMappingProfile()
            {
                CreateMap<Receipt, ReceiptModel>()
                    .ForMember(copy => copy.Amount, opt => opt.MapFrom(src => src.Amount))
                    .ForMember(copy => copy.Balance, opt => opt.MapFrom(src => src.Balance))
                    .ForMember(copy => copy.Debt, opt => opt.MapFrom(src => src.Debt))
                    .ForMember(copy => copy.BillDate, opt => opt.MapFrom(src => src.BillDate))
                    .ForMember(copy => copy.IdBill, opt => opt.MapFrom(src => src.IdBill))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id));
                
                CreateMap<ReceiptModel, Receipt>()
                    .ForMember(copy => copy.Amount, opt => opt.MapFrom(src => src.Amount))
                    .ForMember(copy => copy.Balance, opt => opt.MapFrom(src => src.Balance))
                    .ForMember(copy => copy.Debt, opt => opt.MapFrom(src => src.Debt))
                    .ForMember(copy => copy.BillDate, opt => opt.MapFrom(src => src.BillDate))
                    .ForMember(copy => copy.IdBill, opt => opt.MapFrom(src => src.IdBill))
                    .ForMember(copy => copy.Id, opt => opt.MapFrom(src => src.Id));

            }
        }

        public class TsjServiceMappingProfile : Profile
        {
            public TsjServiceMappingProfile()
            {
                CreateMap<TsjService, TsjServiceModel>()
                    .ForMember(copy => copy.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName));
                
                CreateMap<TsjServiceModel, TsjService>()
                    .ForMember(copy => copy.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(copy => copy.IdName, opt => opt.MapFrom(src => src.IdName));

            }
        }
    }
}