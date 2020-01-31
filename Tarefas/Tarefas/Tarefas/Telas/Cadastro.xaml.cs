using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();

        }
        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var Stacks = slPrioridades.Children;

            foreach (var linha in Stacks)
            {
                Label lblPrioridade = ((StackLayout)linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
        }
    }
}