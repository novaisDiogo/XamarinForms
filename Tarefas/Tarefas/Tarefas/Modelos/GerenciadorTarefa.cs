using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Modelos
{
    public class GerenciadorTarefa
    {
        public List<Tarefa> Lista { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }
        public void Deletar(Tarefa tarefa)
        {
            Lista.Remove(tarefa);

            SalvarNoProperties(Lista);
        }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista.RemoveAt(index);
            Lista.Add(tarefa);
            SalvarNoProperties(Lista);
        }

        public List<Tarefa> Listagem()
        {
            return ListagemNoPropeties();
        }

        private void SalvarNoProperties(List<Tarefa> lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }
            App.Current.Properties.Add("Tarefas", lista);
        }
        private List<Tarefa> ListagemNoPropeties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }

            return new List<Tarefa>();
        }
    }
}
