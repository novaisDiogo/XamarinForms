using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Tarefas.Modelos
{
    public class GerenciadorTarefa
    {
        public List<Tarefa> Lista { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }
        public void Deletar(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

            SalvarNoProperties(Lista);
        }
        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

            tarefa.DataFinalizacao = DateTime.Now;
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

            string jsonVal = JsonConvert.SerializeObject(lista);

            App.Current.Properties.Add("Tarefas", jsonVal);
        }
        private List<Tarefa> ListagemNoPropeties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string jsonVal = (String)App.Current.Properties["Tarefas"];
                List<Tarefa> lista = JsonConvert.DeserializeObject<List<Tarefa>>(jsonVal);

                return lista;
            }

            return new List<Tarefa>();
        }
    }
}
