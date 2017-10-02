using Nutrimeal.Models.Exercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class ExercicioListViewModel : BaseViewModel
    {
        public List<ExercicioInList> Items { get; set; } = new List<ExercicioInList>();
    }
}
