using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public string Prioridade { get; set; }
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
            FileImageSource source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            string prioridade = source.File.ToString().Replace("Resources/", "").Replace(".png", "");

            Prioridade = prioridade;
        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool erro = false;

            if (txtNome.Text == null || txtNome.Text.Trim().Length <= 0)
            {
                erro = true;
                DisplayAlert("Erro", "Nome não preenchido!", "Ok");
            }

            if (Prioridade == null || Prioridade.Trim().Length <= 0)
            {
                erro = true;
                DisplayAlert("Erro", "Prioridade não foi selecionada!", "Ok");
            }

            if (erro == false)
            {
                Tarefa tarefa = new Tarefa()
                {
                    Nome = txtNome.Text.Trim(),
                    Prioridade = Prioridade
                };
                new GerenciadorTarefa().Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}