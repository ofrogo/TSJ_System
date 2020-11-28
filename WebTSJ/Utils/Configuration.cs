using AbstractBLL;
using AbstractDAL;
using AutoMapper;
using BillBL;
using BillDAL;
using DistrictBL;
using DistrictDAL;
using Entities;
using FloatCounterBL;
using FloatCounterDAL;
using HouseBL;
using HouseCounterBL;
using HouseCounterDAL;
using HouseDAL;
using JilezBL;
using JilezDAL;
using ListServicesBL;
using ListServicesDAL;
using ManageCompanyBL;
using ManageCompanyDAL;
using Ninject.Modules;
using ReceiptBL;
using ReceiptDAL;
using TsjServiceBL;
using TsjServiceDAL;

namespace WebTSJ.Utils
{
    public class Configuration:NinjectModule
    {
        public override void Load()
        {
            Bind<IDao<Bill>>().To<BillDao>().InSingletonScope();
            Bind<IDao<District>>().To<DistrictDao>().InSingletonScope();
            Bind<IDao<FloatCounter>>().To<FloatCounterDao>().InSingletonScope();
            Bind<IDao<House>>().To<HouseDao>().InSingletonScope();
            Bind<IDao<HouseCounter>>().To<HouseCounterDao>().InSingletonScope();
            Bind<IDao<Jilez>>().To<JilezDao>().InSingletonScope();
            Bind<IDao<ListServices>>().To<ListServicesDao>().InSingletonScope();
            Bind<IDao<ManageCompany>>().To<ManageCompanyDao>().InSingletonScope();
            Bind<IDao<Receipt>>().To<ReceiptDao>().InSingletonScope();
            Bind<IDao<TsjService>>().To<TsjServiceDao>().InSingletonScope();

            Bind<IBl<ManageCompany>>().To<ManageCompanyLogic>().InSingletonScope();
            Bind<IBl<Jilez>>().To<JilezLogic>().InSingletonScope();
            Bind<IBl<Bill>>().To<BillLogic>().InSingletonScope();
            Bind<IBl<Receipt>>().To<ReceiptLogic>().InSingletonScope();
            Bind<IBl<ListServices>>().To<ListServicesLogic>().InSingletonScope();
            Bind<IBl<TsjService>>().To<TsjServiceLogic>().InSingletonScope();
            Bind<IBl<House>>().To<HouseLogic>().InSingletonScope();
            Bind<IBl<FloatCounter>>().To<FloatCounterLogic>().InSingletonScope();
            Bind<IBl<HouseCounter>>().To<HouseCounterLogic>().InSingletonScope();
            Bind<IBl<District>>().To<DistrictLogic>().InSingletonScope();
            
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig.BillMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.DistrictMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.HouseMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.JilezMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.ReceiptMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.FloatCounterMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.HouseCounterMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.ListServicesMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.ManageCompanyMappingProfile>();
                cfg.AddProfile<AutoMapperConfig.TsjServiceMappingProfile>();
            });
            Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfig)).InSingletonScope();
        }
    }
}