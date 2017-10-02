using AutoMapper;
using Nutrimeal.Models;
using Nutrimeal.Models.Alimento;
using Nutrimeal.Models.Atributo;
using Nutrimeal.Models.Exercicio;
using Nutrimeal.Models.ExercicioAtributo;
using Nutrimeal.Models.MetaExercicio;
using Nutrimeal.Models.PerfilAlimentar;
using Nutrimeal.Models.PerfilFisico;
using Nutrimeal.Models.QuantidadeAlimentar;
using Nutrimeal.Models.Refeicao;
using Nutrimeal.Web.Models.Medidas;

namespace Nutrimeal.Web.Infrastructure
{
    public class ServicesAutoMapperConfig
    {
        private static IMapper _mapped;

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

                // OBJETIVOS MAPPING
                cfg.CreateMap<Nutrimeal.Web.Models.ObjetivosCreate, Nutrimeal.Models.Objetivos>();
                cfg.CreateMap<Nutrimeal.Models.Objetivos, Nutrimeal.Web.Models.ObjetivosCreate>();


                cfg.CreateMap<Nutrimeal.Web.Models.ObjetivosList, Nutrimeal.Models.Objetivos>();
                cfg.CreateMap<Nutrimeal.Models.Objetivos, Nutrimeal.Web.Models.ObjetivosList>();

                // MEDIDAS MAPPING
                cfg.CreateMap<MedidasInList, Nutrimeal.Models.Medidas>();
                cfg.CreateMap<Nutrimeal.Models.Medidas, MedidasInList>();

                //PERFIL ALIMENTAR MAPPING
                cfg.CreateMap<PerfilAlimentarInList, PerfilAlimentar>();
                cfg.CreateMap<PerfilAlimentar, PerfilAlimentarInList>();

                //REFEICAO MAPPING
                cfg.CreateMap<RefeicaoInList, Refeicao>();
                cfg.CreateMap<Refeicao, RefeicaoInList>();

                //ALIMENTO MAPPING
                cfg.CreateMap<AlimentoInList, Alimento>();
                cfg.CreateMap<Alimento, AlimentoInList>();

                //QUANTIDADEALIMENTAR MAPPING
                cfg.CreateMap<QuantidadeAlimentarInList, QuantidadeAlimentar>();
                cfg.CreateMap<QuantidadeAlimentar, QuantidadeAlimentarInList>();

                //PERFILFISICO MAPPING
                cfg.CreateMap<PerfilFisicoInList, PerfilFisico>();
                cfg.CreateMap<PerfilFisico, PerfilFisicoInList>();

                //EXERCICIO MAPPING
                cfg.CreateMap<ExercicioInList, Exercicio>();
                cfg.CreateMap<Exercicio, ExercicioInList>();

                //METAEXERCICIO MAPPING
                cfg.CreateMap<MetaExercicioInList, MetaExercicio>();
                cfg.CreateMap<MetaExercicio, MetaExercicioInList>();

                //ATRIBUTO MAPPING
                cfg.CreateMap<AtributoInList, Atributo>();
                cfg.CreateMap<Atributo, AtributoInList>();

                //EXERCICIOATRIBUTO MAPPING
                cfg.CreateMap<ExercicioAtributoInList, ExercicioAtributo>();
                cfg.CreateMap<ExercicioAtributo, ExercicioAtributoInList>();


            });

            Mapped = config.CreateMapper();
        }
    }
}
