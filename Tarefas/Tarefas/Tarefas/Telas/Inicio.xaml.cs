using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarefas.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");
            string data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);

            DataHoje.Text = string.Format(data, "de");
            CarregarTarefas();
        }
        public void ActionGoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }
        private void CarregarTarefas()
        {
            slTarefas.Children.Clear();

            List<Tarefa> tarefas = new GerenciadorTarefa().Listagem();
            int i = 0;
            foreach(Tarefa tarefa in tarefas)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }

        }

        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                delete.Source = ImageSource.FromFile("Resources/Delete.png");
            }
            TapGestureRecognizer tapDelete = new TapGestureRecognizer();
            tapDelete.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(index);
                CarregarTarefas();
            };
            delete.GestureRecognizers.Add(tapDelete);

            Image prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(tarefa.Prioridade + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                prioridade.Source = ImageSource.FromFile("Resources/" + tarefa.Prioridade + ".png");
            }

            View stackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {
                stackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                stackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)stackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                ((StackLayout)stackCentral).Children.Add(new Label() { Text = "Finalizado em " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }


            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }
            if (tarefa.DataFinalizacao != null)
            {
                Check.Source = ImageSource.FromFile("CheckOn.png");

                if (Device.RuntimePlatform == Device.UWP)
                {
                    Check.Source = ImageSource.FromFile("Resources/CheckOn.png");
                }
            }
            TapGestureRecognizer tapCheck = new TapGestureRecognizer();
            tapCheck.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                CarregarTarefas();
            };
            Check.GestureRecognizers.Add(tapCheck);

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);
            Linha.Children.Add(stackCentral);
            Linha.Children.Add(prioridade);
            Linha.Children.Add(delete);

            slTarefas.Children.Add(Linha);
        }
    }
}