﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Modelos
{
    public class Tarefa
    {
        public string Nome { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public byte Prioridade { get; set; }

    }
}
