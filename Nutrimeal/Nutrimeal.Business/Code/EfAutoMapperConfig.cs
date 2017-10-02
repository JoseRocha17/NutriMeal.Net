using AutoMapper;

namespace Nutrimeal.Business.Code
{
    public class EfAutoMapperConfig
    {
        private static IMapper _mapped = null;

        public static IMapper Mapped
        {
            get
            {
                if (_mapped != null) return _mapped;
                CreateMaps();
                return _mapped;
            }
            set { _mapped = value; }
        }


        private static void CreateMaps()
        {

            var config = new MapperConfiguration(cfg =>
            {

                // Candidate Mapper;
                cfg.CreateMap<Nutrimeal.Domain.Entities.Objetivos, Nutrimeal.Models.Objetivos>();
                cfg.CreateMap<Nutrimeal.Models.Objetivos, Nutrimeal.Domain.Entities.Objetivos>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.Medidas, Nutrimeal.Models.Medidas>();
                cfg.CreateMap<Nutrimeal.Models.Medidas, Nutrimeal.Domain.Entities.Medidas>();


                cfg.CreateMap<Nutrimeal.Domain.Entities.PerfilAlimentar, Nutrimeal.Models.PerfilAlimentar>();
                cfg.CreateMap<Nutrimeal.Models.PerfilAlimentar, Nutrimeal.Domain.Entities.PerfilAlimentar>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.Refeicao, Nutrimeal.Models.Refeicao>();
                cfg.CreateMap<Nutrimeal.Models.Refeicao, Nutrimeal.Domain.Entities.Refeicao>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.Alimento, Nutrimeal.Models.Alimento>();
                cfg.CreateMap<Nutrimeal.Models.Alimento, Nutrimeal.Domain.Entities.Alimento>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.QuantidadeAlimentar, Nutrimeal.Models.QuantidadeAlimentar>();
                cfg.CreateMap<Nutrimeal.Models.QuantidadeAlimentar, Nutrimeal.Domain.Entities.QuantidadeAlimentar>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.PerfilFisico, Nutrimeal.Models.PerfilFisico>();
                cfg.CreateMap<Nutrimeal.Models.PerfilFisico, Nutrimeal.Domain.Entities.PerfilFisico>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.Exercicio, Nutrimeal.Models.Exercicio>();
                cfg.CreateMap<Nutrimeal.Models.Exercicio, Nutrimeal.Domain.Entities.Exercicio>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.MetaExercicio, Nutrimeal.Models.MetaExercicio>();
                cfg.CreateMap<Nutrimeal.Models.MetaExercicio, Nutrimeal.Domain.Entities.MetaExercicio>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.Atributo, Nutrimeal.Models.Atributo>();
                cfg.CreateMap<Nutrimeal.Models.Atributo, Nutrimeal.Domain.Entities.Atributo>();

                cfg.CreateMap<Nutrimeal.Domain.Entities.ExercicioAtributo, Nutrimeal.Models.ExercicioAtributo>();
                cfg.CreateMap<Nutrimeal.Models.ExercicioAtributo, Nutrimeal.Domain.Entities.ExercicioAtributo>();


            });

            Mapped = config.CreateMapper();
        }
    }
}
